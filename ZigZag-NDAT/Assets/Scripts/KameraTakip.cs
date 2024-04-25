using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform topunkonumu;
    Vector3 fark;
    // Start is called before the first frame update
    void Start()
    {
        fark = transform.position - topunkonumu.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TopHareketi.dustuMu == false)
        {
            transform.position = topunkonumu.position + fark;
        }
        
    }
}
