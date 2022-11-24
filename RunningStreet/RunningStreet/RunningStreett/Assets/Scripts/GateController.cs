using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GateController : MonoBehaviour
{

    [SerializeField] private TMP_Text _gateNumberText = null;
    [SerializeField]
    private enum GateType
    {
        PositiveGate,
        NegativeGate
    }

    [SerializeField] private GateType _gatetype;
    [SerializeField] private int _gateNumber;

    public int GetGateNumber()
    {
        return _gateNumber;
    }


    // Start is called before the first frame update
    void Start()
    {
        RandomGateNumber();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RandomGateNumber()
    {
        switch (_gatetype)
        {
            case GateType.PositiveGate:
                _gateNumber = Random.Range(1, 10);
                _gateNumberText.text = _gateNumber.ToString();
                break;
            case GateType.NegativeGate:
                _gateNumber = Random.Range(-10, -1);
                _gateNumberText.text = _gateNumber.ToString();
                break;
        }
    }
}
