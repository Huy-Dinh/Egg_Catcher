using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBroken : MonoBehaviour
{
    public GameObject brokenEggSprite;
    // Get the SpriteRenderer of the Egg
    SpriteRenderer thisSpriteRenderer;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grass")
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x,
                transform.position.y,
                0.0f
                );
            Quaternion spawnRotation = Quaternion.identity;
            GameObject thisBrokenEgg = Instantiate(brokenEggSprite, spawnPosition, spawnRotation);
            Destroy(gameObject);
            Destroy(thisBrokenEgg, 2);
        }
    }


}
