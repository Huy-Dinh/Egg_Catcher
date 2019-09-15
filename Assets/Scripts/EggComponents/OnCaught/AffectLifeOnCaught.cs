using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectLifeOnCaught : MonoBehaviour
{
    public int lifeAdded;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hat")
        {
            GameObject gameController = GameObject.Find("GameController");
            if (gameController == null)
                return;
            SurvivalGameController survivalScript = gameController.GetComponent<SurvivalGameController>();
            survivalScript.livesLeft += lifeAdded;
        }        
    }
}
