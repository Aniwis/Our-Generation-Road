using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarRace : MonoBehaviour
{
    private Cronometer cronometer;
    SpeedeMove speedeMaster;
    PlayerController playerController;
    public float tiempoEntreInstrucciones2 = 3f;
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

        textoInstrucciones.text = "Hola, soy Speede, ser  tu maestro correl n";
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);


        textoInstrucciones.text = "Si logras llegar a tiempo en la carrera";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Te dar  la habilidad de correr";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "No tienes que ganarme, igual Soy Muy R pido";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "S lo llega antes de que acabe el tiempo, te esperar  en la Meta";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "GO! GO! GO!";

        wall.gameObject.SetActive(false);
        cronometer.canCronometer();
        speedeMaster.velocidad = 8;
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = "";
        Destroy(gameObject);
    }
}
