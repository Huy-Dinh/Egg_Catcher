using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectPointOnCaught : MonoBehaviour
{
    public int pointAdded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hat")
        {
            ScoreController.scoreValue += pointAdded;
        }        
    }
}
