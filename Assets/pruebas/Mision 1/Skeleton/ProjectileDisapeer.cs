using System.Collections;
using UnityEditor;
using UnityEngine;

public class ProjectileDisapeer : MonoBehaviour
{
    private bool fadeIn;
    public float everyFlashes = 2;
    private GameObject modelObject; 

    public float timer = 5;
    public bool isGround;
    private void Start()
    {
        modelObject = transform.GetChild(0).gameObject;
        StartCoroutine(Toggler());
    }
    private void Update()
    {
        if (isGround){
            Timer();
            if(modelObject.activeSelf != fadeIn){
                modelObject.SetActive(fadeIn);
            }
            if (timer <= 0){
                Destroy(gameObject);
            }
        }


       
       
       
        
    }
    
    IEnumerator Toggler()
    {
        while (true) // Bucle infinito para alternar fadeIn
        {
            yield return new WaitForSeconds(everyFlashes);
            fadeIn = !fadeIn;
            
        }
    }
  

    void Timer(){

        timer -= Time.deltaTime;
    }


    private void OnCollisionStay(Collision other) {
        
  
        
            isGround = true;
        
    }
}
