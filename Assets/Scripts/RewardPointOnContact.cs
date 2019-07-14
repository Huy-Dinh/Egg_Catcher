using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPointOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Egg")
        {
            ScoreController.scoreValue += 1;
        }        
    }
}
