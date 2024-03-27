using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarScene3 : MonoBehaviour
{
    private Cronometer cronometer;
    public float tiempoEntreInstrucciones = 3f;
    public bool canCronometer;
    public TextMeshProUGUI textoInstrucciones;
    public GameObject wall;

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
            Debug.Log("Instrucciones3");
            ActivarInstrucciones();
        }
    }

    void ActivarInstrucciones()
    {
        StartCoroutine(Instructions3());
    }
    IEnumerator Instructions3()
    {
        cronometer.tiempoRestante = 30;
        yield return new WaitForSeconds(0.5f);
        wall.gameObject.SetActive(true);

        textoInstrucciones.text = "Hola, soy Rainbow, seré  tu maestro del Color";
        yield return new WaitForSeconds(tiempoEntreInstrucciones);


        textoInstrucciones.text = "Te enseñaré a ponerle color a tu mundo";

        yield return new WaitForSeconds(tiempoEntreInstrucciones);

        textoInstrucciones.text = "Deberas ir por cada color y activarlo";

        yield return new WaitForSeconds(tiempoEntreInstrucciones);

        textoInstrucciones.text = "Solo tienes que seguir las instrucciones";

        yield return new WaitForSeconds(tiempoEntreInstrucciones);

        textoInstrucciones.text = "Tienes poco tiempo para hacerlo así que corre";

        yield return new WaitForSeconds(tiempoEntreInstrucciones);

        textoInstrucciones.text = "GO! GO! GO!";
        wall.gameObject.SetActive(false);
        cronometer.canCronometer();
        yield return new WaitForSeconds(tiempoEntreInstrucciones);
        textoInstrucciones.text = "";
        Destroy(gameObject);

    }
}
