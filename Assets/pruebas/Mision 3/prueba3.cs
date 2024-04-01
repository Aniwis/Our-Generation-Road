using System.Collections;
using UnityEngine;

public class prueba3 : MonoBehaviour
{
    public GameObject[] gameObjects; // Arreglo de tus 3 objetos
    public float swapSpeed = 1.0f; // Velocidad a la que se moverán los objetos
    private int numSwaps = 5; // Número de intercambios
    private bool isSwapping = false; // Para controlar que no se inicie otro intercambio hasta terminar el actual
    GameObject lidChest; 
    void Start()
    {
         lidChest = gameObjects[1].transform.GetChild(0).gameObject;
         lidChest = lidChest.transform.GetChild(0).gameObject;
        StartCoroutine(SwapPositionsRoutine());
    }



    IEnumerator ShowGold(){
        lidChest.transform.Rotate(Vector3.left, 90f);
        yield return new WaitForSeconds(2);
        lidChest.transform.Rotate(Vector3.left, -90f);
       
    }



    IEnumerator SwapPositionsRoutine()
    {
        StartCoroutine(ShowGold());
        yield return new WaitForSeconds(3);
        for (int i = 0; i < numSwaps; i++)
        {
            // Espera a que termine el intercambio actual antes de iniciar otro
            while (isSwapping)
            {
                yield return null;
            }

            // Inicia un nuevo intercambio
            StartCoroutine(SmoothSwapPositions());
            // Espera un poco entre intercambios para dar tiempo al jugador de seguir el movimiento
            yield return new WaitForSeconds(1.0f);
        }
    }

    IEnumerator SmoothSwapPositions()
    {
        isSwapping = true;

        int index1 = Random.Range(0, gameObjects.Length);
        int index2 = Random.Range(0, gameObjects.Length);

        while (index1 == index2)
        {
            index2 = Random.Range(0, gameObjects.Length);
        }

        Vector3 startPosition1 = gameObjects[index1].transform.position;
        Vector3 startPosition2 = gameObjects[index2].transform.position;

        float time = 0;

        while (time < 1)
        {
            gameObjects[index1].transform.position = Vector3.Lerp(startPosition1, startPosition2, time);
            gameObjects[index2].transform.position = Vector3.Lerp(startPosition2, startPosition1, time);
            time += Time.deltaTime * swapSpeed;
            
            yield return null;
        }

        // Asegura que los objetos lleguen a la posición final deseada sin quedarse a medio camino debido a la interpolación
        gameObjects[index1].transform.position = startPosition2;
        gameObjects[index2].transform.position = startPosition1;

        isSwapping = false;
    }
}