using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos2D : MonoBehaviour
{
    public string [] dialogos;
    private TextMeshProUGUI dialogueUI;

    public float waitTimeChange = 2;
    private void Start() {
        //obtener el canvas donde esta el texto de dialogos 
        dialogueUI = GameObject.Find("Dialogos").GetComponent<TextMeshProUGUI>(); 
        // ejecutar co-rutine 
        StartCoroutine(ExecDialogue());
    }
    
    IEnumerator ExecDialogue (){
       
        foreach (string dialogo in dialogos)
        {
            
            dialogueUI.text += dialogo; // Agregar el nuevo diálogo al texto existente
            yield return new WaitForSeconds(waitTimeChange);// Esperar el tiempo especificado
            dialogueUI.text = ""; 
        }
        


    }





}
