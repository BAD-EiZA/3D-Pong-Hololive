using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public bool sideP1;
    public bool sideP2;
    public bool sideP3;
    public bool sideP4;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            if (sideP1)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer1Score(1);
            }
            if (sideP2)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer2Score(1);
            }
            if (sideP3)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer3Score(1);
            }
            if (sideP4)
            {
                CameraShake.instance.isShaking = true;
                ScoreManager.instance.AddPlayer4Score(1);
            }
        }
    }
}
