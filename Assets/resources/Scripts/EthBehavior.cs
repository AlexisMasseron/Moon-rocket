using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EthBehavior : MonoBehaviour {
    public int value = 1;

    // public int scoreUI = 0;

    private GameObject gameControllerObject; 
    private GameController gameController;
    private GameObject UI;
    // Start is called before the first frame update
    void Start() {
        UI = GameObject.FindGameObjectWithTag("Score");
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }



    void OnTriggerEnter2D(Collider2D col) { 
        if(col.gameObject.CompareTag("Player")) {
            gameController.scoreUI = int.Parse(UI.GetComponent<Text>().text) + value;
            UI.GetComponent<Text>().text = gameController.scoreUI + ""; 
            Destroy(gameObject);
        }
    }
}
