using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPointOnCaught : MonoBehaviour
{
    public int pointRewarded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hat")
        {
            ScoreController.scoreValue += pointRewarded;
        }        
    }
}
