using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using TMPro;

using UnityEngine.UI;
public class OpenChest : MonoBehaviour,IInteractable
{
    GameObject lidChest; 
    private Canvas canvasBomb ;
    private TextMeshProUGUI textBomb;

    public Image feedBackBomb;
    private float timer = 5;

    private float maxTime = 5;
  
    private bool chestOpen = false;
    public string textWarning = "Mantener F para Abrir cofre ";
    void Start()
    {
        canvasBomb = transform.GetChild(1).GetComponent<Canvas>();
        textBomb = canvasBomb.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        GameObject parentUIBomb = canvasBomb.transform.GetChild(1).gameObject;
        feedBackBomb = parentUIBomb.transform.GetChild(1).GetComponent<Image>();
        GameObject modellidChest = transform.GetChild(0).gameObject;
        lidChest = modellidChest.transform.GetChild(0).gameObject;

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
            
            
            if (timer <= 0 && !chestOpen){
                
                OpenChestAnim();
                textWarning = "Cofre Abierto ";
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


       

    void OpenChestAnim (){

        lidChest.transform.Rotate(Vector3.left, 90f);
        chestOpen = true;
    }
}
