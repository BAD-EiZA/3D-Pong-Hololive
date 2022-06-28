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
    public float maxSpd;
    [Header("Boolean")]
    public bool isTop1;
    public bool isTop2;
    public bool isSide1;
    public bool isSide2;
    public bool isTouch;

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        sideDirect1 = new Vector3(Random.Range(2f,5f), 0, Random.Range(2f,4f));
        sideDirect2 = new Vector3(Random.Range(-2f,-5f), 0, Random.Range(2f,4f));
        topDirect1 = new Vector3(Random.Range(2f,5f), 0, Random.Range(-2f, -5f));
        topDirect2 = new Vector3(Random.Range(-2f,-5f), 0, Random.Range(-2f,-5f));
        isTop1 = CheckTouchTop1();
        isTop2 = CheckTouchTop2();
        isSide1 = CheckTouchSide1();
        isSide2 = CheckTouchSide2();
        isTouch = false;
        
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
        if (!isTouch)
        {
            rb.velocity = rb.velocity.normalized * 9;
        }
        
        if(ScoreManager.instance.isGameOver == true)
        {
            Destroy(this.gameObject);
        }
        if(rb.velocity.magnitude > maxSpd)
        {
            rb.velocity = rb.velocity.normalized * 10;
        }
        
        //Debug.Log("Speed : " + rb.velocity.magnitude);
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
    public IEnumerator SlowBall()
    {
        yield return new WaitForSeconds(2);
        isTouch = false;
    }
    public IEnumerator SlowPower()
    {
        yield return new WaitForSeconds(4);
        isTouch = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isTouch = true;
            rb.velocity = rb.velocity.normalized * 12;
            SoundManager.instance.BallBounces();
            StartCoroutine("SlowBall");
        }
        if(other.gameObject.tag == "Paddle")
        {
            
            SoundManager.instance.BallBounces();
            
        }
        if(other.gameObject.tag == "PowerUp1")
        {
            isTouch = true;
            rb.velocity = rb.velocity.normalized * 15;
            PowerUpManager.instance.PowerList.Remove(PowerUpManager.instance.IsPower);
            StartCoroutine("SlowPower");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Goal1")
        {
            CameraShake.instance.isShaking = true;
            ScoreManager.instance.AddPlayer1Score(1);
            GameManager.instance.ballList.Remove(GameManager.instance.isList);
            if(GameData.instance.isDlc == true)
            {
                SoundManager.instance.OkayuGoals();
            }
            
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Goal2")
        {
            CameraShake.instance.isShaking = true;
            ScoreManager.instance.AddPlayer2Score(1);
            GameManager.instance.ballList.Remove(GameManager.instance.isList);;
            if (GameData.instance.isDlc == true)
            {
                SoundManager.instance.WatsonGoals();
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Goal3")
        {
            CameraShake.instance.isShaking = true;
            ScoreManager.instance.AddPlayer3Score(1);
            GameManager.instance.ballList.Remove(GameManager.instance.isList);
            if (GameData.instance.isDlc == true)
            {
                SoundManager.instance.GuraGoals();
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Goal4")
        {
            CameraShake.instance.isShaking = true;
            ScoreManager.instance.AddPlayer4Score(1);
            GameManager.instance.ballList.Remove(GameManager.instance.isList);
            if (GameData.instance.isDlc == true)
            {
                SoundManager.instance.MioGoals();
            }
            Destroy(gameObject);
        }

    }
    

}
