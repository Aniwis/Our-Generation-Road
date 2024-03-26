using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActiveRGB : MonoBehaviour,IInteractable
{
    private Canvas canvasColor ;
    private TextMeshProUGUI textRGB;

    public Image feedBackColor;
    private float timer = 3;

    private float maxTime = 3;
  

    public string textWarning = "Mantener F para activar Color";
    public string activateTextColor = "Color Verde Actado";
    void Start()
    {
        canvasColor = transform.GetChild(1).GetComponent<Canvas>();
        textRGB = canvasColor.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        GameObject parentUIBomb = canvasColor.transform.GetChild(1).gameObject;
        feedBackColor = parentUIBomb.transform.GetChild(1).GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        canvasColor.gameObject.SetActive(false);
        textRGB.text = "";
    }

    public void Interact () {
        canvasColor.gameObject.SetActive(true);
        textRGB.text = textWarning;
        UpdateColorUI();
        if (Input.GetKey(KeyCode.F))
        {
            timer -= Time.deltaTime;
            
            
            if (timer <= 0){
                textWarning = activateTextColor;

            }
        }

        if (Input.GetKeyUp(KeyCode.F) && timer > 0){
            timer = maxTime;
            
        }
    }


    void UpdateColorUI (){
        float restante = 1;
        feedBackColor.fillAmount = restante - (timer / maxTime);     
    }

}
