using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBroken : MonoBehaviour
{
    public GameObject brokenEggSprite;
    public GameObject crackedEggSprite;
    // Get the SpriteRenderer of the Egg
    SpriteRenderer thisSpriteRenderer;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grass")
        {
            GameObject thisCrackedEgg = Instantiate(crackedEggSprite, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(thisCrackedEgg, 1);
            Vector3 spawnPosition = new Vector3(thisCrackedEgg.transform.position.x,
                                    thisCrackedEgg.transform.position.y,
                                    0.0f);
            GameObject thisBrokenEgg = Instantiate(brokenEggSprite, spawnPosition, Quaternion.identity);
            Destroy(thisBrokenEgg, 1);
        }
    }


}
