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
    public GameObject gameOverText;
    public GameObject restartButton;


    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
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
        if(timeLeft == 0)
        {
            StartCoroutine(showEndGameMenu());
        }
          
    }
    IEnumerator showEndGameMenu()
    {  
        yield return new WaitForSeconds(1.0f);
        if (gameOverText.activeSelf == false)
        {
            gameOverText.SetActive(true);
        }
        if (restartButton.activeSelf == false)
        {
            restartButton.SetActive(true);
        }
    }

    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft).ToString();
    }

}