using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class movement : MonoBehaviour
{


    [SerializeField] private GameObject _ballPrefabs;
    [SerializeField] private TMP_Text ballcountText = null;

    [SerializeField] private List<GameObject> balls = new List<GameObject>();
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float ilerigit;
    [SerializeField] private float _horizontalLimit;
    public GameObject durekrani;
    public GameObject tiklaoyna;
    private float _horizontal;
    private int _gateNumber;
    private int _targetCount;
  
   

    private void Start()
    {
        
        Time.timeScale = 0;

    }

    private void Update()
    {
        
        ilerigitme();
        HorizontalBallMove();
        ballcounttext();

    }

    private void HorizontalBallMove()
    {
        float _newX;

        if (Input.GetMouseButton(0))
        {
            Time.timeScale = 1;
            _horizontal = Input.GetAxisRaw("Mouse X");
            tiklaoyna.SetActive(false);
        }
        else
        {
            _horizontal = 0;
        }
        _newX = transform.position.x + _horizontal * _horizontalSpeed * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -_horizontalLimit, _horizontalLimit);

        transform.position = new Vector3(_newX, transform.position.y, transform.position.z);


    }

    private void ilerigitme()
    {
        transform.Translate(Vector3.forward * ilerigit * Time.deltaTime);
    }

    private void ballcounttext()
    {
        ballcountText.text = balls.Count.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("top"))
        {

            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, balls[balls.Count - 1].transform.localPosition.z - 1f);
            balls.Add(other.gameObject);
        }
        if (other.gameObject.CompareTag("gate"))
        {
            _gateNumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            _targetCount = balls.Count + _gateNumber;
            
            if (_gateNumber > 0)
            {
                IncreseBallCount();
            }
            else if (_gateNumber < 0)
            {
                DecreaseBallCount();
            }
            

        }
        if (other.gameObject.CompareTag("endline"))
        {

            ilerigit = 0;
            durekrani.SetActive(true);
        }
    }

    private void IncreseBallCount()
    {
        for (int i = 0; i < _gateNumber; i++)
        {
            GameObject _newBall = Instantiate(_ballPrefabs);
            _newBall.transform.SetParent(transform);
            _newBall.GetComponent<SphereCollider>().enabled = false;
            _newBall.gameObject.transform.localPosition = new Vector3(0f, 0f, balls[balls.Count - 1].transform.localPosition.z - 1f);
            balls.Add(_newBall);
        }
    }


    private void DecreaseBallCount()
    {
        for (int i = balls.Count - 1; i >= _targetCount; i--)
        {
            balls[i].SetActive(false);
            balls.RemoveAt(i);

        }
    }
}
