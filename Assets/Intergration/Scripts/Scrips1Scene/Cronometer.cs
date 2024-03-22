using UnityEngine;
using TMPro;

public class Cronometer : MonoBehaviour
{
    public float tiempoInicial = 60f; // Tiempo inicial en segundos
    public float tiempoRestante; // Tiempo restante en segundos
    public TextMeshProUGUI textoTiempo; // Referencia al TextMeshPro que mostrará el tiempo restante

    public bool goToChallenge; 

    void Start()
    {
        //goToChallenge = false;
        tiempoRestante = tiempoInicial; // Inicializa el tiempo restante
        ActualizarTextoTiempo(); // Actualiza el TextMeshPro al iniciar
        
    }

    void Update()
    {
        if (tiempoRestante > 0f && goToChallenge == true)
        {
            tiempoRestante -= Time.deltaTime; // Reduce el tiempo restante con el tiempo transcurrido desde el último frame
            ActualizarTextoTiempo(); // Actualiza el TextMeshPro con el tiempo restante
        }
         else if(tiempoRestante <= 0f)
        {
           // El tiempo ha llegado a 0 o menos, agregar cualquier lógica adicional 
           tiempoRestante = 0f; // Para asegurarse de que el tiempo no sea negativo
           goToChallenge = false;
        }
    }

    void ActualizarTextoTiempo()
    {
        // Formatea el tiempo restante en minutos y segundos
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);
        string textoFormateado = string.Format("{0:00}:{1:00}", minutos, segundos);

        // Actualiza el TextMeshPro con el tiempo restante formateado
        textoTiempo.text = textoFormateado;
    }

    public void canCronometer()
    {
         goToChallenge = true;
    }
    public void cantCronometer()
    {
        goToChallenge = false;
    }
}

