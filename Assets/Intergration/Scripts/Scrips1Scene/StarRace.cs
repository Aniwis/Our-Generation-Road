using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarRace : MonoBehaviour
{
    private Cronometer cronometer;
    SpeedeMove speedeMaster;
    PlayerController playerController;
    public float tiempoEntreInstrucciones2 = 2f;
    public bool canCronometer;
    public TextMeshProUGUI textoInstrucciones;
    private Camera miCamara;
    CameraFollow cameraFollow;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        miCamara = FindObjectOfType<Camera>();
        cameraFollow = miCamara.GetComponent<CameraFollow>();
        cronometer = FindObjectOfType<Cronometer>();
        //instrucciones2 = FindObjectOfType<Instrucciones>();
        speedeMaster = FindFirstObjectByType<SpeedeMove>();
        playerController = FindFirstObjectByType<PlayerController>();
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Instrucciones2");
            ActivarInstrucciones();
        }
      
    }


    void ActivarInstrucciones()
    {
        StartCoroutine(SegundasInstrucciones2()); 
    }
    IEnumerator SegundasInstrucciones2()
    {
        cronometer.tiempoRestante = 10;
        //playerController.transform.position = new Vector3(9,0,50);
        //playerController.transform.rotation = Quaternion.Euler(0, 180, 0);
        //miCamara.transform.rotation = Quaternion.Euler(35, 180, 0);

        //cameraFollow.offset = new Vector3(-7, 15, 16);
        // Cambiar el texto del TextMeshPro con la nueva instrucción
        textoInstrucciones.text = "Hola, soy Speede, seré tu maestro correlón";

        // Esperar cierto tiempo antes de mostrar la siguiente instrucción
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Si logras llegar a tiempo en la carrera";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Te daré la habilidad de correr";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "No tienes que ganarme, igual Soy Muy Rápido";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Sólo llega antes de que acabe el tiempo, te esperaré en la Meta";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "GO! GO! GO!";
        wall.gameObject.SetActive(false);
        cronometer.canCronometer();
        speedeMaster.velocidad = 7;
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = "";
    }
}
