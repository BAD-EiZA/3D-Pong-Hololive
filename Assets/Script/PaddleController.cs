using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float spd;
    public KeyCode upInput;
    public KeyCode downInput;
    public Rigidbody rb;
    public bool isPlayerSide;
    public bool isOkayu;
    public GameObject padOkayu;
    void Start()
    {
        padOkayu = GameObject.Find("Paddle4");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isGameStart == true)
        {
            if (ScoreManager.instance.isGameOver == false)
            {
                if (isPlayerSide)
                {
                    GetInputSide();
                }
                else
                {
                    GetInputTop();
                }
            }
            else
            {
                if (isOkayu)
                {
                    padOkayu.transform.localPosition = new Vector3(-3.07f, -0.4538952f, -6.184f);
                }
            }
            
        }
    }
    private Vector3 GetInputTop()
    {
        
        if (Input.GetKey(upInput))
        {
            return rb.velocity = Vector3.forward * spd;
        }
        if (Input.GetKey(downInput))
        {
            return rb.velocity = Vector3.back * spd;
        }
        return Vector3.zero;
    }
    private Vector3 GetInputSide()
    {

        if (Input.GetKey(upInput))
        {
            return rb.velocity = Vector3.left * spd;
        }
        if (Input.GetKey(downInput))
        {
            return rb.velocity = Vector3.right * spd;
        }
        return Vector3.zero;
    }

}
