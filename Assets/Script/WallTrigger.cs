using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public float spds;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.name == "Ball")
        {
            BallController ball = coli.GetComponent<BallController>();
            ball.rb.velocity *= 2;
        }
    }
}
