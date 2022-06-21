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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
