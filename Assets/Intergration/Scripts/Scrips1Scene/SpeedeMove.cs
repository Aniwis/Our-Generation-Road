using UnityEngine;

public class SpeedeMove : MonoBehaviour
{
    private Animator speedeAnim;
    public float velocidad = 0;
    public bool running;
    
    void Start()
    {
        running = false;
        speedeAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        RunSpeede();
        speedeAnim.SetBool("Running", running);
    }
    void RunSpeede()
    {
        running = true;
        GetComponent<Rigidbody>().velocity = transform.forward * velocidad;
    }

}

