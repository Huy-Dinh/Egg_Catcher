using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectLifeOnBroken : MonoBehaviour
{
    public int lifeAdded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Grass") || (col.gameObject.tag == "Destroyer"))
        {
            GameObject gameController = GameObject.Find("GameController");
            if (gameController == null)
                return;
            SurvivalGameController survivalScript = gameController.GetComponent<SurvivalGameController>();
            survivalScript.livesLeft = survivalScript.livesLeft + lifeAdded;
        }
    }
}
