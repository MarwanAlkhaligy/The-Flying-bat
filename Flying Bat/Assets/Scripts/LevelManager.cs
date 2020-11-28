using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameTimeText = null; 
    [SerializeField] private TextMeshProUGUI gameOverTimeText = null; 
    [SerializeField] private GameObject gamePlayUI = null;
    [SerializeField] private GameObject gameOverUI = null;
   
    private int minute = 0;
    private float seconds = 0f;
    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayController.isGameOver) {
            seconds += Time.deltaTime;
            if(seconds > 59) {
                seconds = 0f;
                minute++;
            }
            gameTimeText.SetText(minute.ToString().Length > 1? minute.ToString() : "0" + minute.ToString() + ":"
                          + ( ((int)seconds).ToString().Length> 1? ((int)seconds).ToString() : "0" + ((int)seconds).ToString()));
        } else {
            gameOverUI.SetActive(true);
            gamePlayUI.SetActive(false);
            gameOverTimeText.SetText("Time:" + gameTimeText.GetParsedText());
            int bestMintues = PlayerPrefs.GetInt("Minutes");
            int bestSeconds = PlayerPrefs.GetInt("Seconds");

            if(minute > bestMintues || minute >= bestMintues && seconds > bestSeconds) {
               PlayerPrefs.SetInt("Minutes", minute);
               PlayerPrefs.SetInt("Seconds", (int)seconds);
            }
            PlayController.isGameOver = false;
        }
        
    }
    public void SetGameOverUI(bool activeState)
    {
        gameOverUI.SetActive(activeState);
    }
    public void SetGamePlayUI(bool activeState)
    {
        gamePlayUI.SetActive(activeState);
    }
}
