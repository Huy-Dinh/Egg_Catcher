﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggLaying : MonoBehaviour
{
    public GameObject ball;
    //public float timeLeft;
    //public Text timerText;
    public GameObject findObjectGameController;
    public float timeCounted;
    // Start is called before the first frame update
    void Start()
    {
        findObjectGameController = GameObject.Find("GameController"); // get GameController Script because we want to access the GameController Component
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        timeCounted = findObjectGameController.GetComponent<GameController>().timeLeft; // we want to update timeLeft from GameCOntroller because when time left is zero, chickens are not allowed to give birth.
    }
    /*void FixedUpdate()
    {
        // fixupdated gives us fixed Delta Time
        timeLeft -= Time.deltaTime;   //if it's an update, it gives us the current whcih change every frame that the time it took since the last update since the last time the frame came around
        if (timeLeft < 0 )
        {
            timeLeft = 0;
        }
        
    }*/
    
    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while (timeCounted > 0)
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
    /*void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft).ToString();
    }*/
}
