using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int score=0;
    public  Text scoreText;
    private void Awake() {
        scoreText=GameObject.Find("ScoreText").GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int amoutToAdd){
        score+=amoutToAdd;
        scoreText.text=score.ToString();   
    }
}
