using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/** Class handling UI text elements */
public class Scoreboard : MonoBehaviour
{

    /** Score text object */
    public Text scoreText;

    /** Click count text object */
    public Text clickText;

    /** Actions per seconds text object */
    public Text apsTxt;

    /** Cooldown Slider object */
    public Slider cooldown;

    // Start is called before the first frame update
    void Start()
    {
        // Set min and max of cooldown slider
        if (cooldown != null)
        {
            cooldown.minValue = 0;
            cooldown.maxValue = GameManager.Instance.limit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "Points: " + Math.Round(GameManager.Instance.points);
        }

        if (clickText != null)
        {
            clickText.text = "Click: " + GameManager.Instance.clickAction.getClicks();
        }

        if (apsTxt != null)
        {
            apsTxt.text = "APS: " + GameManager.Instance.clickAction.getClicksPerSecond();
        }

        if (cooldown != null)
        {
            cooldown.value = GameManager.Instance.clickAction.getClicks();
        }
    }
}
