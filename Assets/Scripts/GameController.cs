using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject buoy;

    public RotaterArrow rotater;

    public int numberBuoyForWin = 10;
    private int numberBuoy;
    public Text scoreText;

    public float time;
    public Text timeText;

    public Text elapsedTime;

    public GameObject endGameCanvas;
    public BoatController boatController;

    private void Start()
    {
        time = 0;
        numberBuoy = 0;
    }

    void Update()
    {
        if (numberBuoy >= numberBuoyForWin && endGameCanvas.activeSelf == false)
        {
            endGameCanvas.SetActive(true);
            boatController.isControll = false;
            elapsedTime.text = GetMinutesString() + ":" + GetSecondsString();
        }
        
        if (endGameCanvas.activeSelf == false)
        {
            time += Time.deltaTime;
            UpdateTimeText();
        }
    }

	public void CreateNewBuoy()
    {
        GameObject buoy_t = Instantiate(buoy);
        Vector3 newCoord = new Vector3();

        newCoord.x = Random.Range(-252, 352);
        newCoord.z = Random.Range(-252, 300);
        newCoord.y = 0.57f;

        buoy_t.transform.position = newCoord;

        rotater.SetNewTargetPos(newCoord);
    }

    public void AddScore()
    {
        ++numberBuoy;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = numberBuoy.ToString() + "/" + numberBuoyForWin;
    }

    private void UpdateTimeText()
    {
        timeText.text = GetMinutesString() + ":" + GetSecondsString();
    }

    private string GetMinutesString()
    {
        int minutes = (int)(time / 60.0f);
        if (minutes < 10)
            return "0" + minutes.ToString();
        else
            return minutes.ToString();
    }

    private string GetSecondsString()
    {
        int seconds = (int)(time % 60.0f);

        if (seconds < 10)
            return "0" + seconds.ToString();
        else
            return seconds.ToString();
    }
}
