using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    public bool isMusic = false;
    private bool banderaMusica = false;
    private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (isMusic && banderaMusica == false)
        {
            AudioManager.Instance.PlayMusic(3);
            banderaMusica = true;
        }
        
    }

    private void Update()
    {
        if (isMusic && banderaMusica == false)
        {
            AudioManager.Instance.PlayMusic(3);
            banderaMusica = true;
        }
    }
}
