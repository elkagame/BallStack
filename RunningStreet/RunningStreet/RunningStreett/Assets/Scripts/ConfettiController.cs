using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiController : MonoBehaviour
{

    public GameObject confettiFx;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("endline"))
        {
            GameObject ob = Instantiate(confettiFx);
            Destroy(ob, 2.5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
