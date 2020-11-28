using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameGUIHandler : MonoBehaviour
{
    [SerializeField] private PlayController playController = null;
    [SerializeField] private EnemySpawner enemySpawner = null;
    [SerializeField] private TextMeshProUGUI bestTimeText = null; 
    [SerializeField] private LevelManager levelManager = null;
    internal static bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        int minute = PlayerPrefs.GetInt("Minutes");
        int seconds = PlayerPrefs.GetInt("Seconds");
        bestTimeText.SetText("Best Time : " + (minute.ToString().Length > 1? minute.ToString() : "0" + minute.ToString()) + ":"
                          + ( ((int)seconds).ToString().Length> 1? ((int)seconds).ToString() : "0" + ((int)seconds).ToString()));
        startGame = false;
    }

    
    public void StartGameButton() 
    {
        startGame = true;
        levelManager.SetGameOverUI(false);
        playController.enabled = true;
        enemySpawner.enabled = true;
    }
    public void RetryButton()
    {
        
        //levelManager.SetGameOverUI(false);
        SceneManager.LoadScene(0);
    }
}
