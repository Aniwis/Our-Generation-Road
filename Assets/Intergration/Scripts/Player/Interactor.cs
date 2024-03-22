using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;



public interface IInteractable {
    void Interact();
}
public class Interactor : MonoBehaviour
{
    public LayerMask layer;
    public float InteractRange = 2f;
    
    private RaycastHit _hit;
    // Update is called once per frame
    void Update()
    {
        
            bool isHit = Physics.BoxCast(transform.position,
            transform.lossyScale / 2,
            transform.forward,
            out _hit,
            transform.rotation,
            InteractRange);

            if (isHit)
            {
                if (_hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                    interactObj.Interact();
            }
         
    }

    private void OnDrawGizmos()
    {

        if (_hit.distance != 0) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position + transform.forward * _hit.distance, transform.lossyScale);
        }
        
    }

}
