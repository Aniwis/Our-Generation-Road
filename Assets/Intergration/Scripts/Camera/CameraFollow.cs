using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // Referencia al transform del jugador

    public Vector3 offset = new Vector3 (0, 3 , -5); // Distancia entre la cámara y el jugador

    // Velocidad de suavizado de movimiento de la cámara
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcular la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Interpolar suavemente entre la posición actual de la cámara y la deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establecer la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
