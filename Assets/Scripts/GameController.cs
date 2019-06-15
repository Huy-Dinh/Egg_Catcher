using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject ball;
    private float maxWidth;
    public Text timerText;
    public float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        //Renderer renderer = new Renderer();
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());
    }

    void FixedUpdate()
    {
        // fixupdated gives us fixed Delta Time
        timeLeft -= Time.deltaTime;   //if it's an update, it gives us the current whcih change every frame that the time it took since the last update since the last time the frame came around
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateText();
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        while(true)
        {
            Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(-maxWidth, maxWidth),
            transform.position.y,
            0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            //Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f,2.0f));
        }
        
    }
    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft).ToString();
    }

}