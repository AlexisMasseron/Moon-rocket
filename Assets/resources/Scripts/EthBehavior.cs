using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EthBehavior : MonoBehaviour {
    public int value = 1;
    private GameObject UI;
    // Start is called before the first frame update
    void Start() {
        UI = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) { 
        if(col.gameObject.CompareTag("Player")) {
            int scoreUI = int.Parse(UI.GetComponent<Text>().text) + value;
            UI.GetComponent<Text>().text = scoreUI + ""; 
            Destroy(gameObject);
        }
    }
}
