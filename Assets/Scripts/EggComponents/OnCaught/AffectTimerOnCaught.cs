using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectTimerOnCaught : MonoBehaviour
{
    public int pointAdded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hat")
        {
            TimerGameController.timeLeft = TimerGameController.timeLeft + pointAdded;
        }        
    }
}
