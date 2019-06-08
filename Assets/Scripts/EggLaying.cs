﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLaying : MonoBehaviour
{
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y,
            0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f, 2.0f));
        }
    }
}