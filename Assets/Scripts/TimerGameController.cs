using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGameController : MonoBehaviour
{
    public Camera cam;
    public GameObject egg;
    public static float timeLeft;
    public float timeCount;
    public Text LifeText;
    public GameObject gameOverText;
    public GameObject restartButton;
    private float maxWidth;
    public GameObject[] chickens;
    Coroutine COChickenControl, COChickenTeleporter;
    Coroutine COTimeEgg;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        timeLeft = timeCount;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float eggWidth = egg.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - eggWidth;
        // Populate the chicken list
        chickens = GameObject.FindGameObjectsWithTag("Chicken");
        // Starting the egg laying
        COChickenControl = StartCoroutine(chickenNormalEggLayingControl());
        COChickenTeleporter = StartCoroutine(chickenTeleporter());
        COTimeEgg = StartCoroutine(chickenTimeEggLayingControl());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        timeLeft -= Time.deltaTime;
        LifeText.text = "Time left:\n" + Math.Max((int)timeLeft,0).ToString();
        if (timeLeft < 0)
        {
            if (COChickenControl != null)
                StopCoroutine(COChickenControl);
            if (COChickenTeleporter != null)
                StopCoroutine(COChickenTeleporter);
            if (COTimeEgg != null)
                StopCoroutine(COTimeEgg);
            StartCoroutine(showEndGameMenu());
        }
    }

    IEnumerator showEndGameMenu()
    {
        yield return new WaitForSeconds(0.1f);
        if (gameOverText.activeSelf == false)
        {
            gameOverText.SetActive(true);
        }
        if (restartButton.activeSelf == false)
        {
            restartButton.SetActive(true);
        }
    }

    public IEnumerator chickenNormalEggLayingControl()
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

    public IEnumerator chickenTimeEggLayingControl()
    {
        int chickenIndex = -1;
        float delayTime = 0;
        yield return new WaitForSeconds(7.0f);
        while (true)
        {
            chickenIndex = UnityEngine.Random.Range((int)0, (int)chickens.Length);
            delayTime = UnityEngine.Random.Range(5.0f, 15.0f);

            chickens[chickenIndex].GetComponent<EggLaying>().LayTimeEgg();
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
            Transform chickenTransform = chickens[chickenIndex].GetComponent<Transform>();
            chickenTransform.parent.GetComponent<Transform>().position = new Vector3(randomX, randomY);
        }
    }
}
