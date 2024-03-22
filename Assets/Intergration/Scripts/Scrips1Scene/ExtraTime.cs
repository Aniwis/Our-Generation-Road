using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraTime : MonoBehaviour
{
    private Cronometer cronometer;

    // Start is called before the first frame update
    void Start()
    {
        cronometer = FindObjectOfType<Cronometer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            cronometer.tiempoRestante = cronometer.tiempoRestante + 8;
        }

    }
    
}
