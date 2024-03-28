using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarRace : MonoBehaviour
{
    private Cronometer cronometer;
    SpeedeMove speedeMaster;
    public float tiempoEntreInstrucciones2 = 3f;
    public bool canCronometer;
    public TextMeshProUGUI textoInstrucciones;
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        cronometer = FindObjectOfType<Cronometer>();
        speedeMaster = FindFirstObjectByType<SpeedeMove>();
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
        cronometer.tiempoRestante = 12;
        yield return new WaitForSeconds(0.5f);
        wall.gameObject.SetActive(true);

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
        speedeMaster.velocidad =10;
        yield return new WaitForSeconds(tiempoEntreInstrucciones2);
        textoInstrucciones.text = ""; 
        Destroy(gameObject);
                
    }
}
