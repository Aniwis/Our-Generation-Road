using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    private int scoreChallenge1;
    public ChallengeOneOne  challengeOneOne;
    public Cronometer cronometer;
    public Animator animationDoor1;
    public Animator animationDoor2;
    public bool bandera1;
    public GameObject wall;

    public TextMeshProUGUI textoInstrucciones;
    public float tiempoEntreInstrucciones1 = 4f;
    

    void Start()
    {
        bandera1 = false;
        cronometer = FindObjectOfType<Cronometer>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreChallenge1 = challengeOneOne.scoreNotes;
        if (scoreChallenge1 >= 7 && bandera1 == true)
        {
            StartCoroutine(OpenDoor1Courrutine());     
        }
    }

    IEnumerator OpenDoor1Courrutine()
    {
        yield return new WaitForSeconds(1);
        wall.gameObject.SetActive(true);
        AudioManager.Instance.PlayMusic(3);
        cronometer.cantCronometer();
        bandera1 = false;
        textoInstrucciones.text = "Felicitaciones, ahora eres un maestro Músico";
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "Ahora podrás disfrutar de la hermosa música mientras juegas";
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "Sigue descubriendo este maravilloso mundo";
        yield return new WaitForSeconds(tiempoEntreInstrucciones1);
        textoInstrucciones.text = "";
        animationDoor1.Play("AnimationDoor1");
        Destroy(gameObject);
        wall.gameObject.SetActive(false);
    }
    public IEnumerator OpenDoor2Courrutine()
    {
        yield return new WaitForSeconds(2f);
        animationDoor2.Play("AnimationDoor2");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bandera1 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("sale player");
            bandera1 = false;
            StopCoroutine(OpenDoor1Courrutine());
        }
    }

    public void OpenDoor2()
    {
        StartCoroutine(OpenDoor2Courrutine());
    }
}

    

