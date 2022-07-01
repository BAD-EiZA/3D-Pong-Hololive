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
    public bool isGameOver;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;
    public GameObject Pad1;
    public GameObject Pad2;
    public GameObject Pad3;
    public GameObject Pad4;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;

    private void Start()
    {
        instance = this;
        isP1Win = true;
        isP2Win = true;
        isP3Win = true;
        isP4Win = true;
        Wall1 = GameObject.Find("Wall1");
        Wall2 = GameObject.Find("Wall2");
        Wall3 = GameObject.Find("Wall3");
        Wall4 = GameObject.Find("Wall4");
        anim1 = Wall1.GetComponent<Animator>();
        anim2 = Wall2.GetComponent<Animator>();
        anim3 = Wall3.GetComponent<Animator>();
        anim4 = Wall4.GetComponent<Animator>();
        isGameOver = false;
    }
    void Update()
    {
        if (countPlayer == 3)
        {
            if (isP1Win)
            {
                UIManager.instance.P1WinUI.SetActive(true);
                isGameOver = true;
                if(GameData.instance.isDlc == true)
                {
                    CinemachineControllers.instance.anim.Play("Okayu");
                }
            }
            if (isP2Win)
            {
                UIManager.instance.P2WinUI.SetActive(true);
                isGameOver = true;
                if (GameData.instance.isDlc == true)
                {
                    CinemachineControllers.instance.anim.Play("Ame");
                }
            }
            if (isP3Win)
            {
                UIManager.instance.P3WinUI.SetActive(true);
                isGameOver = true;
                if (GameData.instance.isDlc == true)
                {
                    CinemachineControllers.instance.anim.Play("Gura");
                }
            }
            if (isP4Win)
            {
                UIManager.instance.P4WinUI.SetActive(true);
                isGameOver = true;
                if (GameData.instance.isDlc == true)
                {
                    CinemachineControllers.instance.anim.Play("Mio");
                }
            }
        }
    }
    public void AddPlayer1Score(int value)
    {
        if(isGameOver == false)
        {
            if (player1Score < maxScore)
            {
                player1Score += value;
                UIManager.instance.Player1ScoreUI.text = player1Score.ToString();
            }
            if (!isGameOver && player1Score == maxScore)
            {
                countPlayer += 1;
                isP1Win = false;
                Destroy(Pad1);
                anim1.SetTrigger("Lose");
            }
            
        }
    }
    public void AddPlayer2Score(int value)
    {
        if(isGameOver == false)
        {
            if (player2Score < maxScore)
            {
                player2Score += value;
                UIManager.instance.Player2ScoreUI.text = player2Score.ToString();
            }
            if (!isGameOver && player2Score == maxScore)
            {
                countPlayer += 1;
                isP2Win = false;
                Destroy(Pad2);
                anim2.SetTrigger("Lose");
            }
        }
        
    }
    public void AddPlayer3Score(int value)
    {
        if(isGameOver == false)
        {
            if (player3Score < maxScore)
            {
                player3Score += value;
                UIManager.instance.Player3ScoreUI.text = player3Score.ToString();
            }
            if (!isGameOver && player3Score == maxScore)
            {
                countPlayer += 1;
                isP3Win = false;
                Destroy(Pad3);
                anim3.SetTrigger("Lose");
            }
        }
        
    }
    public void AddPlayer4Score(int value)
    {
        if(isGameOver == false)
        {
            if (player4Score < maxScore)
            {
                player4Score += value;
                UIManager.instance.Player4ScoreUI.text = player4Score.ToString();
            }
            if (!isGameOver && player4Score == maxScore)
            {
                countPlayer += 1;
                isP4Win = false;
                Destroy(Pad4);
                anim4.SetTrigger("Lose");
            }
        }
        
    }

}
