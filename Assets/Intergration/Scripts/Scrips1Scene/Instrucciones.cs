using System.Collections;
using UnityEngine;
using TMPro;

public class Instrucciones : MonoBehaviour
{
    public TextMeshProUGUI textoInstrucciones;
    public float tiempoEntreInstrucciones1 = 4f;
    private Cronometer cronometer; 
    public GameObject wall;
    

    void Start()
    {
        StartCoroutine(CambiarInstrucciones1());
        cronometer = FindObjectOfType<Cronometer>();
    }
    IEnumerator CambiarInstrucciones1()
    {       
        textoInstrucciones.text = "Bienvenido Learne a este mundo de aprendizaje";           
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "Tendrás que aprender cómo evolucionar este mundo de videojuegos";
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "Tu primera tarea será activar el audio en tu juego";
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "Toca las cajas musicales y descubre el sonido";
        yield return new WaitForSeconds(tiempoEntreInstrucciones1); 
        textoInstrucciones.text = "Siempre sigue las flechas. Go! Go! GO!";
        wall.gameObject.SetActive(false);
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "";
        cronometer.canCronometer();
        Destroy(gameObject);
    }
 
    public void StarCourutineInstrucciones()
    {
        StartCoroutine(CambiarInstrucciones1());
    }
   
}

