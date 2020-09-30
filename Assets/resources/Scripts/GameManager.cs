using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject eth;
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        float randomX = Random.Range(-width/2, width/2);
        float randomY = Random.Range(-height/2, height/2);
        Debug.Log(randomX);
        Debug.Log(randomY);
        Instantiate(eth, new Vector3(randomX, randomY, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
