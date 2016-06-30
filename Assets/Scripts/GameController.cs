using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int points = 0;
    private Text pointTxt;
	public float timer; 
	private Text timerTxt;
	private Image loadingbar; 

	private bool timerRunning = true;

    // Use this for initialization
    void Start () {
		pointTxt = GameObject.Find("PointsTopRight").GetComponent<Text>();
		timerTxt = GameObject.Find("TimerTopLeft").GetComponent<Text>();
		loadingbar = GameObject.Find ("LoadingBar").GetComponent<Image>();

        UpdatePoints();
	}
	
	// Update is called once per frame
	void Update () {
		if (timerRunning) {
			timer -= Time.deltaTime;
			timerTxt.text = timer.ToString ("0.0");
			loadingbar.fillAmount = timer / 30;

			if (timer >= 15){
				Debug.Log ((timer - 15) / 15);
				loadingbar.color = Color.Lerp (Color.yellow, Color.green, ((timer - 15) / 15)); //Von grün zu gelb; 1:grün; 2:gelb
			}
			else 
				loadingbar.color = Color.Lerp (Color.red, Color.yellow, timer / 15);
		}
	}

    public void AddPoints()
    {
        //points++;
		points = points + 100;	
        UpdatePoints();
    }

    void UpdatePoints()
    {
        pointTxt.text = points.ToString();
    }

	public void startTimer(bool start){ //if false: stop timer
		timerRunning = start;
	}
}
