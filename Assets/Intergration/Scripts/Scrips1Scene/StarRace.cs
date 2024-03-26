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

        textoInstrucciones.text = "Hola, soy Speede, seré  tu maestro correlón";
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);


        textoInstrucciones.text = "Si logras llegar a tiempo en la carrera";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Te daré la habilidad de correr";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "No tienes que ganarme, igual Soy Muy Rápido";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Recuerda tomar las barras de tiempo!!";

        yield return new WaitForSeconds(tiempoEntreInstrucciones2);

        textoInstrucciones.text = "Si logras llegar antes de que acabe el tiempo, te esperaré en la Meta";

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
