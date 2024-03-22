using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // Referencia al transform del jugador

    public Vector3 offset = new Vector3 (0, 3 , -5); // Distancia entre la cámara y el jugador

    // Velocidad de suavizado de movimiento de la cámara
    public float smoothSpeed = 0.125f;
    public int screenConfig = 2;

    private Camera miCamara;
    private CustomPostProcess postProcess;
    void Start()
    {
        miCamara = GetComponent<Camera>();
        postProcess = GetComponent<CustomPostProcess>();
        SelectScreen(screenConfig);
    }
    
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

    void Scene1Cofig () {
        offset = new Vector3 (0, 15, -19);
        transform.Rotate(Vector3.left, -35);
        miCamara.orthographic = true;
        postProcess.mat.SetFloat("_PixelRange", 70);
        postProcess.mat.SetInt("_SceneConfig", 0);
    }

    void Scene2Cofig () {
        offset= new Vector3 (0,3,-10);
        miCamara.orthographic = true;
        postProcess.mat.SetFloat("_PixelRange", 100);
        postProcess.mat.SetInt("_SceneConfig", 1);
    }

   void Scene3Cofig () {
        offset = new Vector3 (0, 1,-5);
        miCamara.orthographic = false;
        miCamara.fieldOfView = 67;
        postProcess.mat.SetFloat("_PixelRange", 1000);
        postProcess.mat.SetInt("_SceneConfig", 2);
    }

    public void SelectScreen( int screenConfig)
    {
        switch (screenConfig)
        {
            case 0:
                Scene1Cofig();
                break;
            case 1:
                Scene2Cofig();
                break;
            default:
                Scene3Cofig();
                break;
        }
    }
}
