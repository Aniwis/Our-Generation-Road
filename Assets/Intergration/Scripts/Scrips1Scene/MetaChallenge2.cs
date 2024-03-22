using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaChallenge2 : MonoBehaviour
{
    SpeedeMove speedeMaster;
    private OpenDoor openDoor2;
    Cronometer cronometer;
    // Start is called before the first frame update
    void Start()
    {
        openDoor2 = FindObjectOfType<OpenDoor>();
        speedeMaster = FindFirstObjectByType<SpeedeMove>();
        cronometer = FindFirstObjectByType<Cronometer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Puerta 2");
            cronometer.cantCronometer();
            ActivaPuerta();
        }
        else if (other.CompareTag("Speede")){
            speedeMaster.velocidad = 0;
        }
    }

   
    void ActivaPuerta()
    {
        if (cronometer.tiempoRestante > 0f)
        {
            openDoor2.OpenDoor2();

        }
        else if (cronometer.tiempoRestante <= 0f)
        {
            Debug.Log("Pierde reto 2");
        }
        
    }
}
