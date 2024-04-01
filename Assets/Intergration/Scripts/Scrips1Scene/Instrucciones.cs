using System.Collections;
using UnityEngine;
using TMPro;

public class Instrucciones : MonoBehaviour
{
    public TextMeshProUGUI textoInstrucciones;
   
    public float tiempoEntreInstrucciones1 = 4f;

    private Cronometer cronometer; 

    public bool canCronometer;
    public GameObject wall;

    void Start()
    {
        StartCoroutine(CambiarInstrucciones1());
        cronometer = FindObjectOfType<Cronometer>();
        canCronometer = true;
    }

    IEnumerator CambiarInstrucciones1()
    {
        
           // Cambiar el texto del TextMeshPro con la nueva instrucci�n
                textoInstrucciones.text = "Bienvenido Learne a este mundo de aprendizaje";

                // Esperar cierto tiempo antes de mostrar la siguiente instrucci�n
                yield return new WaitForSeconds(tiempoEntreInstrucciones1);

                textoInstrucciones.text = "Tendr�s que aprender c�mo evolucionar este mundo de videojuegos";
        
                yield return new WaitForSeconds(tiempoEntreInstrucciones1);

                textoInstrucciones.text = "Tu primera tarea ser� activar el audio en tu juego";

                yield return new WaitForSeconds(tiempoEntreInstrucciones1);

                textoInstrucciones.text = "Siempre sigue las flechas. Go! Go! GO!";
                wall.gameObject.SetActive(false);
                yield return new WaitForSeconds(tiempoEntreInstrucciones1);

                textoInstrucciones.text = "";
                cronometer.canCronometer();
    }
 

    public void StarCourutineInstrucciones()
    {
        StartCoroutine(CambiarInstrucciones1());
    }
   
}

