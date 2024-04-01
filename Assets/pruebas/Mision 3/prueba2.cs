using System.Collections;
using UnityEngine;

public class prueba2 : MonoBehaviour
{
    public GameObject[] cofres = new GameObject[3];
    public int cantidadMezclas;

    void Start()
    {
        StartCoroutine(Mezclar());
    }

    IEnumerator Mezclar()
    {
        for (int i = 0; i < cantidadMezclas; i++)
        {
            int indice1, indice2;
            ObtenerCofresAleatorios(out indice1, out indice2);

            GameObject cofre1 = cofres[indice1];
            GameObject cofre2 = cofres[indice2];

            yield return StartCoroutine(MoverCofres(cofre1, cofre2, 2.0f));
            yield return new WaitForSeconds(2);
        }
    }

    void ObtenerCofresAleatorios(out int indiceCofre1, out int indiceCofre2)
    {
        indiceCofre1 = Random.Range(0, cofres.Length);
        indiceCofre2 = Random.Range(0, cofres.Length);
        while (indiceCofre1 == indiceCofre2)
        {
            indiceCofre2 = Random.Range(0, cofres.Length);
        }
    }

    IEnumerator MoverCofres(GameObject cofre1, GameObject cofre2, float velocidadMovimiento)
    {
        Vector3 posicionInicialCofre1 = cofre1.transform.position;
        Vector3 posicionInicialCofre2 = cofre2.transform.position;

        float tiempoTranscurrido = 0;

        while (tiempoTranscurrido < 1)
        {
            tiempoTranscurrido += Time.deltaTime * velocidadMovimiento;
            cofre1.transform.position = Vector3.Lerp(posicionInicialCofre1, posicionInicialCofre2, tiempoTranscurrido);
            cofre2.transform.position = Vector3.Lerp(posicionInicialCofre2, posicionInicialCofre1, tiempoTranscurrido);
            yield return null;
        }

        cofre1.transform.position = posicionInicialCofre2;
        cofre2.transform.position = posicionInicialCofre1;
    }
}

