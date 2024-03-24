using UnityEngine;
using TMPro;

public class Cronometer : MonoBehaviour
{
    public float tiempoInicial = 60f;
    public float tiempoRestante;
    public TextMeshProUGUI textoTiempo;

    public bool goToChallenge;


    void Start()
    {
       Time.timeScale = 1;
       tiempoRestante = tiempoInicial;
       ActualizarTextoTiempo();
    }

    void Update()
    {
        if (tiempoRestante > 0f && goToChallenge == true)
        {
            tiempoRestante -= Time.deltaTime;
            ActualizarTextoTiempo();
        }
        else if (tiempoRestante <= 0f)
        {
            goToChallenge = false;
            UIManager.Instance.panelLose.SetActive(true);
            GameManager.Instance.CursorControlActive();
            Time.timeScale = 0;
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
