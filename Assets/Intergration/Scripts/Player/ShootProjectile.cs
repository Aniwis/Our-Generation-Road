using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform spawnPoint; // Punto de origen del proyectil
    public float projectileForce = 20f; // Fuerza de lanzamiento del proyectil
    public float fireDelay = 0.5f; // Tiempo de retraso entre cada disparo
    private float nextFireTime; // Momento en que se podrá disparar nuevamente

    void Start()
    {
        // Inicializar el próximo momento de disparo
        nextFireTime = Time.time;
    }

    void Update()
    {
        // Verificar si se puede disparar y el jugador presiona el botón de disparo
        if (Time.time > nextFireTime && Input.GetButtonDown("Fire1"))
        {
            // Llama a la función Shoot para lanzar el proyectil
            Shoot();

            // Establecer el próximo momento de disparo
            nextFireTime = Time.time + fireDelay;
        }
    }

    void Shoot()
    {
        // Crea una instancia del proyectil en el punto de origen
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

        // Obtiene el componente Rigidbody del proyectil
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Comprueba si se ha encontrado el componente Rigidbody
        if (rb != null)
        {
            // Aplica una fuerza al proyectil en la dirección hacia adelante del punto de origen
            rb.AddForce(spawnPoint.forward * projectileForce, ForceMode.Impulse);
        }
    }
}
