using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameMaster2D gm;
    private void Start() {
         gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster2D>();
    }
    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.CompareTag("Fine")  ){
                GameManager2D.instance.SetGameObjectFine(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Bad")) {
                GameManager2D.instance.SetGameObjectBad(other.gameObject);
            }
            else if (other.gameObject.CompareTag("ParticlesActivator")){
                 gm.indexLevel = 2;

                Debug.Log("felicidades has encontrado un tesoro inimaginable, has encontrado las particulas del juego");
            }
          
    }

}


