using UnityEngine;
using TMPro;

public class Cronometer : MonoBehaviour
{
    public float tiempoInicial = 60f;
    public float tiempoRestante;
    public TextMeshProUGUI textoTiempo;
    GameManager gameManager;
    public bool goToChallenge;


    void Start()
    {
       Time.timeScale = 1;
       tiempoRestante = tiempoInicial;
       ActualizarTextoTiempo();
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            GameManager.Instance.lose = true;
            goToChallenge = false;
            //UIManager.Instance.panelLose.SetActive(true);
            GameManager.Instance.Lose();
            Time.timeScale = 0;
            textoTiempo.text = "00:00";
            gameManager.isPaused = true;
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
