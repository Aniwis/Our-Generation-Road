using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    private int scoreChallenge1;
    public ChallengeOneOne  challengeOneOne;
    public Cronometer cronometer;

    //public TextMeshProUGUI mensajeCanvas;
    public Animator animationDoor1;
    public Animator animationDoor2;
    public bool bandera1, bandera2;

    void Start()
    {
        bandera1 = false;
        bandera2 = false;
        cronometer = FindObjectOfType<Cronometer>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreChallenge1 = challengeOneOne.scoreNotes;
        if (scoreChallenge1 >= 7 && bandera1 == true)
        {
            StartCoroutine(OpenDoor1Courrutine());
            bandera1 = false;
            cronometer.cantCronometer();
            AudioManager.Instance.PlayMusic(3);
        }
    }

    IEnumerator OpenDoor1Courrutine()
    {
        // Esperar unos segundos
        yield return new WaitForSeconds(2f);

        // Activar la animación de la puerta

        animationDoor1.Play("AnimationDoor1");
    }
    public IEnumerator OpenDoor2Courrutine()
    {
        // Esperar unos segundos
        yield return new WaitForSeconds(2f);

        // Activar la animación de la puerta

        animationDoor2.Play("AnimationDoor2");
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            bandera1 = true;
        }

    }

    public void OpenDoor2()
    {
        StartCoroutine(OpenDoor2Courrutine());
    }


}

    

