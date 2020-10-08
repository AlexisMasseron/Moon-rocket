using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject eth;
    public EndingPanel endingPanel;
    public GameObject endingPanelObject;
    public GameObject timerUI;

    public int scoreUI = 0;

    public float totalTime = 15;

    public int speedGeneration = 1;

    public bool timerIsRunning = false;
    // this is to create a margin gap in order to prevent our token to be generated partialy outside the player's screen
    private float rangeOverlap = 0.1f;

    public void OnRestart() { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnExitGame() {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        endingPanelObject.SetActive(false);
        timerIsRunning = true;
        Debug.Log("Game started");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (totalTime > 0)
            {
                totalTime -= Time.deltaTime;
                if(Time.time >= speedGeneration) {
                    speedGeneration=Mathf.FloorToInt(Time.time)+1;
                    GenerateEth();
                }
                timerUI.GetComponent<Text>().text = Mathf.RoundToInt(totalTime) + "";
            }
            else
            {
                Debug.Log("Time has run out!");
                totalTime = 0;
                timerIsRunning = false;
                endingPanel.OnEnd();
                endingPanelObject.SetActive(true);
            }
        }
    }

    void GenerateEth() {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        float randomX = Random.Range(-width/2+ rangeOverlap, width/2-rangeOverlap);
        Instantiate(eth, new Vector3(randomX, 5, 0), Quaternion.identity);
    }
}
