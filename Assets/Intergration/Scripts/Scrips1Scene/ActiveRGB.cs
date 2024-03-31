using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveRGB : MonoBehaviour
{
    private Canvas canvasColor;
    private TextMeshProUGUI textRGB;

    public Image feedBackColor;
    private float timer = 3;

    private float maxTime = 3;
    private ColorChange colorChange;

    private bool canCount = true;

    public string textWarning = "Mantener F para activar Color";
    public string activateTextColor = "Color Verde Actado";

    void Start()
    {
        canvasColor = transform.GetChild(1).GetComponent<Canvas>();
        textRGB = canvasColor.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        GameObject parentUIBomb = canvasColor.transform.GetChild(1).gameObject;
        feedBackColor = parentUIBomb.transform.GetChild(1).GetComponent<Image>();

        colorChange = GameObject.Find("ColorChange").GetComponent<ColorChange>();
    }

    void Update()
    {
        // La lógica para desactivar el canvas y resetear el texto ahora se maneja en OnTriggerExit
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que tu objeto jugador tenga el tag "Player"
        {
            StartInteraction();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndInteraction();
        }
    }

    private void StartInteraction()
    {
        canvasColor.gameObject.SetActive(true);
        textRGB.text = textWarning;
    }

    private void Interact()
    {
        UpdateColorUI();
        if (Input.GetKey(KeyCode.F))
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && canCount)
            {
                StartCoroutine(ChangeColorCount());
            }
        }
    }

    private void EndInteraction()
    {
        canvasColor.gameObject.SetActive(false);
        textRGB.text = "";
        if (timer > 0)
        {
            timer = maxTime; // Reset timer si el jugador sale antes de activar.
        }
    }

    void UpdateColorUI()
    {
        float restante = 1;
        feedBackColor.fillAmount = restante - (timer / maxTime);
    }

    IEnumerator ChangeColorCount()
    {
        canCount = false;
        textRGB.text = activateTextColor;
        colorChange.rgbCount += 1;
        yield return new WaitForSeconds(1);
        canCount = true;
        timer = maxTime; // Reset timer después de activar
        colorChange.ChangeColor();
        Destroy(gameObject);
    }
}
