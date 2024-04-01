using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeactivateBomb : MonoBehaviour,IInteractable
{
    private Canvas canvasBomb ;
    private TextMeshProUGUI textBomb;

    public Image feedBackBomb;
    private float timer = 5;

    private float maxTime = 5;
    Collider bomb;

    public string textWarning = "Mantener F para desactivar bomba ";
    void Start()
    {
        canvasBomb = transform.GetChild(1).GetComponent<Canvas>();
        textBomb = canvasBomb.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        GameObject parentUIBomb = canvasBomb.transform.GetChild(1).gameObject;
        feedBackBomb = parentUIBomb.transform.GetChild(1).GetComponent<Image>();

        bomb = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        canvasBomb.gameObject.SetActive(false);
        textBomb.text = "";
    }

    public void Interact () {
        canvasBomb.gameObject.SetActive(true);
        textBomb.text = textWarning;
        UpdateBombUI();
        if (Input.GetKey(KeyCode.F))
        {
            timer -= Time.deltaTime;
            
            
            if (timer <= 0){
                
                bomb.isTrigger = true;
                textWarning = "Bomba desactivada ";
            }
        }

        if (Input.GetKeyUp(KeyCode.F) && timer > 0){
            timer = maxTime;
            
        }
    }


    void UpdateBombUI (){
        float restante = 1;
        feedBackBomb.fillAmount = restante - (timer / maxTime);     
    }



   private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
   }


}
