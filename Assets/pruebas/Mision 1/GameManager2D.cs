using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager2D : MonoBehaviour
{
    public static GameManager2D instance;

    private int currentScore;
    public TextMeshProUGUI textCollectable;
    private GameMaster2D gm;
    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster2D>();
        AddScore(0);
        AudioManager.Instance.PlayMusic(2);
    }
    private void Update() {
        ValidateScore();
    }
    public void AddScore(int suma)
    {
        currentScore += suma;
        UpdateScoreUI();
        
    }
    public void RemoveScore(int suma)
    {
       
        if (currentScore > 0 ){
             currentScore -= suma;
        }
        UpdateScoreUI();
        
    }

    void UpdateScoreUI () {

        textCollectable.text = "Puntaje: " + currentScore;
    }
    void ValidateScore(){
        if(currentScore >= 10)
        {
            gm.indexLevel = 1;
            new WaitForSeconds(2);
            gm.RestartScene();
            Debug.Log("JAJAJA no todo te ayuda en el juego, felicidades acabas de desbloquear poder recibir daño"); 
            // CursorControl
        }
       
    }
    public void DestroyCollectable(GameObject estandar)
    {
       Destroy(estandar);
    }
    public void SetGameObjectFine (GameObject received){
        DestroyCollectable(received);
        AddScore(1);
    }
    public void SetGameObjectBad (GameObject received){
        DestroyCollectable(received);
       RemoveScore(1);
    }



}
