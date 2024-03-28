using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MetaChallenge2 : MonoBehaviour
{
    SpeedeMove speedeMaster;
    private OpenDoor openDoor2;
    Cronometer cronometer;
    public GameObject wall;
    public TextMeshProUGUI textoInstrucciones;
    public float tiempoEntreInstrucciones2 = 4f;

    PlayerController1 player;
    
    // Start is called before the first frame update
    void Start()
    {
        openDoor2 = FindObjectOfType<OpenDoor>();
        speedeMaster = FindFirstObjectByType<SpeedeMove>();
        cronometer = FindFirstObjectByType<Cronometer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController1>();
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
            StartCoroutine(OpenDoor2Courrutine());

        }
        else if (cronometer.tiempoRestante <= 0f)
        {
            Debug.Log("Pierde reto 2");
            UIManager.Instance.panelLose.SetActive(true);
        }
        
    }

    IEnumerator OpenDoor2Courrutine()
    {
        cronometer.cantCronometer();
        yield return new WaitForSeconds(1);
        textoInstrucciones.text = "Felicitaciones, ahora eres un maestro Correlón";
        wall.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = "Ahora podrás ir de prisa a todas partes";
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = "Solo tendrás que oprimir 'Shift' cuando te muevas";
        player.canRun = true;
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = "Sigue descubriendo este maravilloso mundo";
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = "";
        openDoor2.OpenDoor2();
        Destroy(gameObject);
        wall.gameObject.SetActive(false);
    }
}
