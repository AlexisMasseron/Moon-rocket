using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingPanel : MonoBehaviour
{

    public Text hodlScore;
    public Text lamboScore;

    public Button restartButton;
    public int lamboPrice = 250000; // approx in $
    public int ethPrice = 370; // approx in $
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {    
    }

    public void OnEnd() {
        hodlScore.text = "You managed to get: " + gameController.scoreUI + " tokens";
        lamboScore.text = (gameController.scoreUI == 0) ? 
            "Well good luck getting a Lambo with that" :
            "You need close to " + (lamboPrice/ethPrice - gameController.scoreUI) + " more tokens before getting your lambo";
    }
}
