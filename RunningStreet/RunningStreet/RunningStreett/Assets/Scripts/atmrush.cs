using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atmrush : MonoBehaviour
{

    public static atmrush instance;

    public List<GameObject> cubes = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
