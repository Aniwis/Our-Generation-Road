using System.Collections;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Animator animator;
    public float xLimit = 8;
    public float posY = 7;
    public float velocidad = 0.5f; // Se ha reducido la velocidad
    private int direccion;
    public float intervaloTiempo = 1f;
    public bool isLaughing;
    public GameObject [] listPrefabs ;

    private void Start()
    {
        // Inicializar la dirección aleatoriamente
        animator = GetComponent<Animator>();
        direccion = Random.Range(0, 2) * 2 - 1;
        StartCoroutine(EjecutarCadaTiempo());
    }

    private void Update()
    {
        
        // Calcular la nueva posición del objeto
        Vector3 nuevaPosicion = transform.position + new Vector3(direccion * velocidad * Time.deltaTime, 0, 0);

        
        // Verificar si la nueva posición está dentro del límite permitido
        if (Mathf.Abs(nuevaPosicion.x) < xLimit)
        {
            // Aplicar la transformación si está dentro del límite
            transform.Translate(direccion * velocidad * Time.deltaTime, 0, 0);
        }
        else
        {
            // Cambiar la dirección cuando alcanza el límite
            direccion = -direccion;
            isLaughing = false;
        }
    }

    IEnumerator EjecutarCadaTiempo(){

        while (true) // Bucle infinito para que se ejecute permanentemente
        {
            isLaughing = true;
            int selectUpOrNext = Random.value < 0.5f ? 1 : 2;

            int indexPrefab = selectUpOrNext == 1 ? 0 : 1;
           
            // Esperar el intervalo de tiempo especificado antes de continuar
            yield return new WaitForSeconds(intervaloTiempo);

            // se instancia el prefab cada cierto tiempo
            animator.SetBool("IsLaughing", isLaughing);
            Instantiate(listPrefabs[indexPrefab], transform.position, Quaternion.identity);
        }
    }

}
