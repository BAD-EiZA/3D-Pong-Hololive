using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [Header("Scoring")]
    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;
    public int maxScore;
    public int countPlayer;
    public bool isP1Win;
    public bool isP2Win;
    public bool isP3Win;
    public bool isP4Win;
    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        if (countPlayer == 3)
        {
            if (isP1Win)
            {
                UIManager.instance.P1WinUI.SetActive(true);
            }
            if (isP2Win)
            {
                UIManager.instance.P2WinUI.SetActive(true);
            }
            if (isP3Win)
            {
                UIManager.instance.P3WinUI.SetActive(true);
            }
            if (isP4Win)
            {
                UIManager.instance.P4WinUI.SetActive(true);
            }
        }
    }
    public void AddPlayer1Score(int value)
    {
        player1Score += value;
        UIManager.instance.Player1ScoreUI.text = player1Score.ToString();
        if (player1Score == maxScore)
        {
            countPlayer += 1;
            isP1Win = false;
        }
    }
    public void AddPlayer2Score(int value)
    {
        player2Score += value;
        UIManager.instance.Player2ScoreUI.text = player2Score.ToString();
        if (player2Score == maxScore)
        {
            countPlayer += 1;
            isP2Win = false;
        }
    }
    public void AddPlayer3Score(int value)
    {
        player3Score += value;
        UIManager.instance.Player3ScoreUI.text = player3Score.ToString();
        if (player3Score == maxScore)
        {
            countPlayer += 1;
            isP3Win = false;
        }
    }
    public void AddPlayer4Score(int value)
    {
        player4Score += value;
        UIManager.instance.Player4ScoreUI.text = player4Score.ToString();
        if (player4Score == maxScore)
        {
            countPlayer += 1;
            isP4Win = false;
        }
    }

}
