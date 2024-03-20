using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCaster : MonoBehaviour
{
  

    private void OnDrawGizmos()
    {
        float maxDistance = 5;
        RaycastHit hit;
        bool isHit = Physics.BoxCast(transform.position,
        transform.lossyScale / 2, transform.forward, out hit,
        transform.rotation, maxDistance
        );

        if (isHit) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
        }



    }
}
