using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster2D : MonoBehaviour
{
    private static GameMaster2D instance;
    public int mision;
    public Vector3 lastCheckPointPos;
    public GameObject [] misiones = new GameObject [3];
    // public Vector3 SpawnLevels;
    public int indexLevel ;
    private void Start() {
       
       
    }
    private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else 
        {
            Destroy(gameObject);
        }
    Instantiate(misiones[indexLevel], transform.position, Quaternion.identity);
    }

    public void RestartScene(){
        GameManager GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        GM.RestartScene();
    }
}



// TEGO UN OBJETO QUE SIEMPRE ESTA VIVO A PESAR DE LOS REINICIOS SI REINICIO LA ESCENA 
// deberia mantener la posicion, la camara, los desbloqueables de resto deberia parar todo 



