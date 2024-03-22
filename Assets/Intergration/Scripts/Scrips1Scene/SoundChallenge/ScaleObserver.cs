using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObserver : MonoBehaviour
{
    public ChallengeOneOne challengeOneOne;

    private void OnCollisionEnter(Collision collision)
    {
        // Obtener el GameObject con el que colisionamos
        GameObject otherObject = collision.gameObject;
        // Verifica si el objeto con el que colisionamos tiene un nombre que corresponda a una nota de la escala
        string noteName = otherObject.gameObject.name.ToLower(); // Convertimos el nombre a min�sculas para evitar errores de may�sculas/min�sculas
        switch (noteName)
        {
            case "do":
                challengeOneOne.LearnScaleNote(1); // Ejecutamos el m�todo LearnScaleNote con el n�mero de la nota correspondiente
                Debug.Log("SuenaNota");
                break;
            case "re":
                challengeOneOne.LearnScaleNote(2);
                break;
            case "mi":
                challengeOneOne.LearnScaleNote(3);
                break;
            case "fa":
                challengeOneOne.LearnScaleNote(4);
                break;
            case "sol":
                challengeOneOne.LearnScaleNote(5);
                break;
            case "la":
                challengeOneOne.LearnScaleNote(6);
                break;
            case "si":
                challengeOneOne.LearnScaleNote(7);
                break;
            default:
                // Si el objeto no tiene un nombre de nota v�lido, no hacemos nada
                break;
        }
    }
}
