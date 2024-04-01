using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraSalud : MonoBehaviour
{
    public float health = 100;
    public float healthMaxime = 100;
    
    [Header("Interfaz")]
    public Image healthUI;
 
    private static BarraSalud instance;
    private void Awake() {
        if (instance == null){
            instance = this;
        }
        
    }


    void Update()
    {
        UpdateUI();
    }

    void UpdateUI () {
        healthUI.fillAmount = health / healthMaxime;
    } 
}
