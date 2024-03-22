using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeOneOne : MonoBehaviour
{
    public AudioSource doScale, reScale, miScale, faScale, solScale, laScale, siScale;
    public int scoreNotes;

    // Start is called before the first frame update
    void Start()
    {
        scoreNotes =  0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LearnScaleNote(int scaleNote)
    {
        switch (scaleNote)
        {
            case 1:
                doScale.Play();
                scoreNotes ++;
                break;
            case 2:
                reScale.Play();
                scoreNotes ++;
                break;
            case 3:
                miScale.Play();
                scoreNotes ++;
                break;
            case 4:
                faScale.Play();
                scoreNotes ++;
                break;
            case 5:
                solScale.Play();
                scoreNotes ++;
                break;
            case 6:
                laScale.Play();
                scoreNotes ++;
                break;
            case 7:
                siScale.Play();
                scoreNotes ++;
                break;
            default:
                
                break;
        }

    }
}
