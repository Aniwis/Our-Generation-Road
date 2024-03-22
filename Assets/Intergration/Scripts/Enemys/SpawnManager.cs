using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // El prefab del enemigo que quieres spawnear
    public float spawnInterval = 2f; // Intervalo de tiempo entre cada spawn
    public Transform[] spawnPoints; // Puntos de spawn donde aparecerán los enemigos

    private int waveSize = 3; // Tamaño de la oleada inicial
    private int waveCounter = 1; // Contador de oleadas

    void Start()
    {
        // Comenzar la función de spawnear enemigos
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            // Mostrar información sobre la nueva oleada
            Debug.Log("Iniciando oleada " + waveCounter + " con " + waveSize + " enemigos.");

            // Spawnear la cantidad de enemigos especificada para esta oleada
            for (int i = 0; i < waveSize; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }

            // Esperar hasta que no haya enemigos restantes en la escena
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length == 0);

            // Incrementar el tamaño de la oleada para la próxima vez
            waveSize += 5;

            // Incrementar el contador de oleadas
            waveCounter++;
        }
    }

    void SpawnEnemy()
    {
        // Elegir un punto de spawn aleatorio
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar un nuevo enemigo en el punto de spawn seleccionado
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
