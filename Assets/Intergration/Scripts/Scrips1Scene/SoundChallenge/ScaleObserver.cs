using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObserver : MonoBehaviour
{
    public ChallengeOneOne challengeOneOne;
    private int currentNoteIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        string noteName = otherObject.gameObject.name.ToLower();

        string[] scaleNotes = { "do", "re", "mi", "fa", "sol", "la", "si" };

        if (currentNoteIndex >= scaleNotes.Length)
        {
            return;
        }
        if (noteName == scaleNotes[currentNoteIndex])
        {
            Debug.Log(currentNoteIndex);
            challengeOneOne.LearnScaleNote(currentNoteIndex + 1);
            currentNoteIndex++;
        }
    }
}
