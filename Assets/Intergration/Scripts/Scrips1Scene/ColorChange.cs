using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public int rgbCount;
    public bool canChangeColor;
    public CameraFollow cameraFollow;
    public TextMeshProUGUI textoInstrucciones;
    Cronometer cronometer;
    void Start()
    {
        GameObject mainCamera = GameObject.Find("MainCamera");
        cameraFollow = mainCamera.GetComponent<CameraFollow>();
        cronometer = FindFirstObjectByType<Cronometer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rgbCount >= 3)
        {
            canChangeColor = true;
        }
    }

    public void ChangeColor()
    {
        if (canChangeColor)
            StartCoroutine(WinGame());
    }

    IEnumerator WinGame()
    {
        cronometer.cantCronometer();
        cameraFollow.SelectScreen(2);
        yield return new WaitForSeconds(1);
        textoInstrucciones.text = "Eres increible. Lo has conseguido";
        yield return new WaitForSeconds(3);
        textoInstrucciones.text = "Has dado vida al juego y ahora tienes color, música y puedes correr";
        yield return new WaitForSeconds(3);
        textoInstrucciones.text = "Continúa explorando este grandioso mundo de aprendizaje";
        yield return new WaitForSeconds(3);
        textoInstrucciones.text = "";
        GameManager.Instance.win = true;
        GameManager.Instance.Win();

    }
}
