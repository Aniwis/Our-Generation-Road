using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
private GameMaster2D gm;
void Start(){
    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster2D>();
}
 private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player")){
        gm.lastCheckPointPos = transform.position;
    }
 }
}
