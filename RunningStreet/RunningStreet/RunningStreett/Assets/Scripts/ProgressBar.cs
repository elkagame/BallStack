
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressBar : MonoBehaviour
{

    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private TextMeshProUGUI uiStartText;
    [SerializeField] private TextMeshProUGUI uiEndText;

    [Header("Player & Endline references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;



    private Vector3 endLinePosition;

    private float fullDistance;

    public void SetLevelTexts(int level)
    {
        uiStartText.text = level.ToString();
        uiEndText.text = (level + 1).ToString();
    }

    private float GetDistance()
    {
        return Vector3.Distance(playerTransform.position, endLinePosition);

    }

    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;

    }



    // Start is called before the first frame update
    void Start()
    {
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(0f, fullDistance, newDistance);
        UpdateProgressFill(progressValue);

    }
}
