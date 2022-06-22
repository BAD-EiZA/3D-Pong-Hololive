using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    [Header("Vector")]
    private Vector3 sideDirect1;
    private Vector3 sideDirect2;
    private Vector3 topDirect1;
    private Vector3 topDirect2;
    private Vector3 direction;
    [Header("Other")]
    public Transform SiderCheck;
    public float spd;
    public Rigidbody rb;
    [Header("Boolean")]
    public bool isTop1;
    public bool isTop2;
    public bool isSide1;
    public bool isSide2;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        sideDirect1 = new Vector3(2f, 0, 2f);
        sideDirect2 = new Vector3(-2f, 0, 2f);
        topDirect1 = new Vector3(2f, 0, -2f);
        topDirect2 = new Vector3(-2f, 0, -2f);
        isTop1 = CheckTouchTop1();
        isTop2 = CheckTouchTop2();
        isSide1 = CheckTouchSide1();
        isSide2 = CheckTouchSide2();
        if (isSide1)
        {
            rb.velocity = sideDirect1 * spd;
        }
        if (isSide2)
        {
            rb.velocity = sideDirect2 * spd;
        }
        if (isTop1)
        {
            rb.velocity = topDirect1 * spd;
        }
        if (isTop2)
        {
            rb.velocity = topDirect2 * spd;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("Speed : " + rb.velocity.magnitude);
    }
    public bool CheckTouchTop1()
    {
        return Physics.CheckSphere(SiderCheck.position, GameManager.instance.SiderCheckRadius, GameManager.instance.Top1Obs);
    }
    public bool CheckTouchTop2()
    {
        return Physics.CheckSphere(SiderCheck.position, GameManager.instance.SiderCheckRadius, GameManager.instance.Top2Obs);
    }
    public bool CheckTouchSide1()
    {
        return Physics.CheckSphere(SiderCheck.position, GameManager.instance.SiderCheckRadius, GameManager.instance.Side1Obs);
    }
    public bool CheckTouchSide2()
    {
        return Physics.CheckSphere(SiderCheck.position, GameManager.instance.SiderCheckRadius, GameManager.instance.Side2Obs);
    }
    public void SpeedBall()
    {
        rb.velocity *= 2;
        StartCoroutine("ResetSpd");
    }
    public IEnumerator ResetSpd()
    {
        yield return new WaitForSeconds(2);
        rb.velocity = rb.velocity.normalized * 6;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            SpeedBall();
        }
    }

}
