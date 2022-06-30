using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{

    public bool isSides;
    public bool isUps;
    public bool isMoveAI;
    public bool isSingleTake;
    public bool isUp;
    public bool isSide;
    public bool isOkayu;
    public bool isMio;
    public bool isAme;
    public bool isGura;
    public GameObject padAme;
    public GameObject padMio;
    public GameObject padOkayu;
    public GameObject padGura;
    public float delayMove;
    private float randPos;
    public float spdAI;
    public Rigidbody rb;
    void Start()
    {
        padAme = GameObject.Find("Paddle3");
        padGura = GameObject.Find("Paddle1");
        padMio = GameObject.Find("Paddle2");
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
                if (isSides)
                {
                    if (!isMoveAI && !isSingleTake)
                    {
                        StartCoroutine("DelayAI");
                        isSingleTake = true;
                    }
                    if (isMoveAI)
                    {
                        MoveAI();
                    }
                }
                if (isUps)
                {
                    if (!isMoveAI && !isSingleTake)
                    {
                        StartCoroutine("DelayAI2");
                        isSingleTake = true;
                    }
                    if (isMoveAI)
                    {
                        MoveAI1();
                    }
                }
            }
            else
            {
                if (isGura)
                {
                    padGura.transform.localPosition = new Vector3(3.14f, -0.4538952f, 0.0121973f);
                }
                if (isAme)
                {
                    padAme.transform.localPosition = new Vector3(-2.98f, -0.4538952f, 6.27f);
                }
                if (isMio)
                {
                    padMio.transform.localPosition = new Vector3(-9.29f, -0.4538952f, 0.0121973f);
                }
            }
        }
    }
    private IEnumerator DelayAI()
    {
        yield return new WaitForSeconds(delayMove);
        randPos = Random.Range(-3f, 3f);
        if (transform.position.z < randPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }
        isSingleTake = false;
        isMoveAI = true;
    }
    private IEnumerator DelayAI2()
    {
        yield return new WaitForSeconds(delayMove);
        randPos = Random.Range(-3f, 3f);
        if (transform.position.x < randPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }
        isSingleTake = false;
        isMoveAI = true;
    }
    private void MoveAI()
    {
        if (!isUp)
        {
            rb.velocity = new Vector3(0,0,-2f)* spdAI;
            if (transform.position.z <= randPos)
            {
                rb.velocity = Vector3.zero;
                isMoveAI = false;
            }
        }
        if (isUp)
        {
            rb.velocity = new Vector3(0,0,2f) * spdAI;
            if (transform.position.z >= randPos)
            {
                rb.velocity = Vector3.zero;
                isMoveAI = false;
            }
        }
    }
    private void MoveAI1()
    {
        if (!isUp)
        {
            rb.velocity = new Vector3(-3f, 0, 0) * spdAI;
            if (transform.position.x <= randPos)
            {
                rb.velocity = Vector3.zero;
                isMoveAI = false;
            }
        }
        if (isUp)
        {
            rb.velocity = new Vector3(3f, 0, 0) * spdAI;
            if (transform.position.x >= randPos)
            {
                rb.velocity = Vector3.zero;
                isMoveAI = false;
            }
        }
    }
}
