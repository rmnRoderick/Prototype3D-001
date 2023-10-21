using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private int maxLifes;
    [SerializeField] private TextMeshProUGUI lifesText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private bool gameOver;
    
    public Lifes lifes;
    public Score score;
    public Timer timer;

   

    private void Awake()
    {
        lifes = new Lifes(maxLifes);
        score = new ();
        timer = new Timer(maxTime, timeText);

    }

    //public GameState(int maxLifes,TextMeshProUGUI lifesText,TextMeshProUGUI scoreText,TextMeshProUGUI timeText,float maxTime)
    //{
    //    lifes = new Lifes(maxLifes,lifesText);
    //    score = new Score(scoreText);
    //    timer = new Timer(maxTime,timeText);
    //}

    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            timer.RefreshTime();

            scoreText.SetText( score.RefreshScore() );

            //lifesText.SetText(lifes.RefreshLifes());

        }

        if(lifes.getRemainingLifes() <= 0 || timer.getRemainingTime()<=0)
        {
            gameOver = true;
        }
    }

    public bool isGameOver()
    {
        return gameOver == true;
    }




}
