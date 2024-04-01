using System.Collections;
using UnityEngine;

public class RandomAzar : MonoBehaviour
{
    public GameObject[] chest = new GameObject[2];
    public float velocidadMovimiento = 3.0f;

    void Start()
    {
        StartCoroutine(Mezclar());
    }

    IEnumerator Mezclar()
    {
        // Almacena las posiciones iniciales de los objetos
        Vector3[] posicionesIniciales = new Vector3[chest.Length];
        for (int i = 0; i < chest.Length; i++)
        {
            posicionesIniciales[i] = chest[i].transform.position;
        }

        for (int i = 0; i < chest.Length; i++)
        {
            int randomIndex = Random.Range(i, chest.Length);

            GameObject temp = chest[i];
            chest[i] = chest[randomIndex];
            chest[randomIndex] = temp;

            // Utiliza las posiciones iniciales para mover los objetos
            yield return StartCoroutine(MoverObjetos(chest[i].transform, chest[randomIndex].transform, posicionesIniciales[i], posicionesIniciales[randomIndex]));
        }

        yield return new WaitForSeconds(2.0f);
    }

    IEnumerator MoverObjetos(Transform objeto1, Transform objeto2, Vector3 posicionInicialObjeto1, Vector3 posicionInicialObjeto2)
    {
        Vector3 direccion1 = posicionInicialObjeto2 - posicionInicialObjeto1;
        Vector3 direccion2 = posicionInicialObjeto1 - posicionInicialObjeto2;

        float distanciaObjetivos1 = Vector3.Distance(posicionInicialObjeto1, posicionInicialObjeto2);
        float distanciaObjetivos2 = Vector3.Distance(posicionInicialObjeto2, posicionInicialObjeto1);

        while (distanciaObjetivos1 > 0.1f && distanciaObjetivos2 > 0.1f)
        {
            Vector3 movimiento1 = direccion1.normalized * velocidadMovimiento * Time.deltaTime;
            Vector3 movimiento2 = direccion2.normalized * velocidadMovimiento * Time.deltaTime;

            objeto1.position = Vector3.MoveTowards(objeto1.position, posicionInicialObjeto2, movimiento1.magnitude);
            objeto2.position = Vector3.MoveTowards(objeto2.position, posicionInicialObjeto1, movimiento2.magnitude);

            distanciaObjetivos1 = Vector3.Distance(objeto1.position, posicionInicialObjeto2);
            distanciaObjetivos2 = Vector3.Distance(objeto2.position, posicionInicialObjeto1);

            yield return null;
        }
    }
}
