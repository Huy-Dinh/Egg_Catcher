using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBroken : MonoBehaviour
{
    // Get the SpriteRenderer of the Egg
    SpriteRenderer thisSpriteRenderer;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grass")
        {  
            thisSpriteRenderer = GetComponent<SpriteRenderer>();
            var sprite = Resources.Load<Sprite>("EggBroken");
            thisSpriteRenderer.sprite = sprite;

            CircleCollider2D currentCollider = GetComponent<CircleCollider2D>();
            PhysicsMaterial2D material = new PhysicsMaterial2D();
            material.friction = currentCollider.sharedMaterial.friction;
            material.bounciness = 0;
            currentCollider.sharedMaterial = material;

            Rigidbody2D currentRigidBody = GetComponent<Rigidbody2D>();
            currentRigidBody.velocity = new Vector2(0, 0);
            currentCollider.enabled = false;
            Destroy(currentRigidBody);
            Destroy(gameObject, 2);
        }
    }


}
