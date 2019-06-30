using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject egg;
    private float maxWidth;
    public Text timerText;
    public float timeLeft;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject[] chickens;

    Coroutine COChickenControl, COChickenTeleporter;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float eggWidth = egg.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - eggWidth;

        // Populate the chicken list
        chickens = GameObject.FindGameObjectsWithTag("Chicken");

        // Start making it rain eggs
        COChickenControl = StartCoroutine(chickenControl());
        COChickenTeleporter = StartCoroutine(chickenTeleporter());
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
        if (timeLeft == 0)
        {
            if (COChickenControl != null)
                StopCoroutine(COChickenControl);
            if (COChickenTeleporter != null)
                StopCoroutine(COChickenTeleporter);
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

    public IEnumerator chickenControl()
    {
        int chickenIndex = -1;
        float delayTime = 0;
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            chickenIndex = UnityEngine.Random.Range((int)0, (int)chickens.Length);
            delayTime = UnityEngine.Random.Range(1.0f, 2.0f);

            chickens[chickenIndex].GetComponent<EggLaying>().LayEgg();
            yield return new WaitForSeconds(delayTime);
        }
    }

    public IEnumerator chickenTeleporter()
    {
        const int minHorizontal = -8;
        const int maxHorizontal = 9;
        const int minVertical = 4;
        const int maxVertical = 10;

        int randomX;
        int randomY;
        float delayTime;
        int chickenIndex;

        while (true)
        {
            delayTime = delayTime = UnityEngine.Random.Range(5.0f, 7.0f);
            yield return new WaitForSeconds(delayTime);
            chickenIndex = UnityEngine.Random.Range((int)0, (int)chickens.Length);

            randomX = UnityEngine.Random.Range(minHorizontal, maxHorizontal);
            randomY = UnityEngine.Random.Range(minVertical, maxVertical);
            chickens[chickenIndex].GetComponent<Transform>().position = new Vector3(randomX, randomY);
        }
    }
}