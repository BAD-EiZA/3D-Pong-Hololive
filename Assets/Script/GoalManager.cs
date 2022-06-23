using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameManager gm;
    public bool sideP1;
    public bool sideP2;
    public bool sideP3;
    public bool sideP4;
    

    private void Start()
    {
        

    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Ball")
        {
            if (sideP1)
            {
                if(ScoreManager.instance.player1Score < ScoreManager.instance.maxScore)
                {
                    CameraShake.instance.isShaking = true;
                    ScoreManager.instance.AddPlayer1Score(1);
                    GameManager.instance.isRemoveList = true;
                }
                else
                {
                    CameraShake.instance.isShaking = true;
                    GameManager.instance.isRemoveList = true;
                }
                

            }
            if (sideP2)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer2Score(1);
                GameManager.instance.isRemoveList = true;

            }
            if (sideP3)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer3Score(1);
                GameManager.instance.isRemoveList = true;

            }
            if (sideP4)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer4Score(1);
                GameManager.instance.isRemoveList = true;

            }
            
            
        }
    }
}
