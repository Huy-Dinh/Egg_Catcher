using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLayingBackground : MonoBehaviour
{
    public GameObject egg;
    public float minX = 0;
    public float maxX = 0;
    public float minY = 0;
    public float maxY = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Invokes the method "LayEgg" in 0 seconds, then repeatedly every 1 seconds.
        // Starting in 0 seconds.
        // will be launched every 1 seconds

        InvokeRepeating("LayEgg", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
        //LayEgg();
    }
    public void LayEgg()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(minX, maxX),//transform.position.x,
            Random.Range(minY, maxY),
            0.0f
            );
        Quaternion spawnRotation = Quaternion.identity;
        GameObject temp = Instantiate(egg, spawnPosition, spawnRotation);
        //Makes the GameObject with tag "UI" the parent of the GameObject "temp".
        temp.transform.parent = GameObject.FindWithTag("UI").transform;
        //yield return new WaitForSeconds(1.0f);

    }

}
