using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
private GameMaster gm;
void Start(){
    gm = FindObjectOfType<GameMaster>();
    }
 private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")){
        gm.lastCheckPointPos = transform.position;
    }
 }
}
