
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class prueba : MonoBehaviour
// {
  
//     public GameObject[] chests = new GameObject[3];
//     public int numberMix;

//     void Start()
//     {
//         StartCoroutine(Mezclar());
//     }

//     IEnumerator Mezclar()
//     {
//         for (int i = 0; i < numberMix; i++)
//         {
            
//             int index1;
//             int index2;
//             getRandomChest(out index1, out index2);

//             GameObject Obj1 = chests[index1];
//             GameObject Obj2 = chests[index2];

//            MoverObjeto(Obj1, Obj2);
//            yield return new WaitForSeconds(2);
//         }
//     }

//     void getRandomChest(out int chestIndexRandom1, out int chestIndexRandom2)
//     {
//         chestIndexRandom1 = Random.Range(0, chests.Length);
//         chestIndexRandom2 = Random.Range(0, chests.Length);
//         while (chestIndexRandom1 == chestIndexRandom2)
//         {
//             chestIndexRandom2 = Random.Range(0, chests.Length);
//         }
//     }

//    void MoverObjeto(GameObject obj1, GameObject obj2)
//     {
//         float velocidadMovimiento = 2.0f;
//         Vector3 posicionObj1Inicial = obj1.transform.position;
//         Vector3 posicionObj2Inicial = obj2.transform.position;
        
//         while (posicionObj1Inicial  != obj2.transform.position && posicionObj2Inicial != obj1.transform.position)
//         {
//             Debug.Log("mix");
//             obj1.transform.position = Vector3.MoveTowards(obj1.transform.position, posicionObj2Inicial, velocidadMovimiento * Time.deltaTime);
//             obj2.transform.position = Vector3.MoveTowards(obj2.transform.position, posicionObj1Inicial, velocidadMovimiento * Time.deltaTime);
//         }
//     }
// }
using System.Collections;
using UnityEngine;

public class Prueba : MonoBehaviour
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



