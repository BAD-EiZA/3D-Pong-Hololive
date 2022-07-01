using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Prefab & Spawn Point")]
    public GameObject ball;
    public List<GameObject> ballList;
    public GameObject[] spawnPoints;
    public GameObject isList;
    [Header("Layer Mask")]
    public LayerMask Side1Obs;
    public LayerMask Side2Obs;
    public LayerMask Top1Obs;
    public LayerMask Top2Obs;
    [Header("Var")]
    public float seconds;
    public float timer;
    public int maxBall;
    public float SiderCheckRadius = 0.3f;
    [Header("Boolean")]
    public bool isSpawn;
    public bool isShake;
    public bool isRemoveList;
    public bool isGameStart;


    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    private void Start()
    {
        instance = this;
        ballList = new List<GameObject>();
        isSpawn = false;
        isRemoveList = false;
        isGameStart = false;
    }

    void Update()
    {
        if (GameData.instance.isDlc == false)
        {
            isGameStart = true;
        }
        if (isGameStart)
        {
            timer -= Time.deltaTime;
            seconds = Mathf.FloorToInt(timer % 60);
            if (seconds % 2 == 0 && !isSpawn && ballList.Count < maxBall && ScoreManager.instance.isGameOver == false)
            {
                StartCoroutine("SpawnBall");


            }
            Debug.Log("Index : " + ballList.Count);
        }
    }
    public IEnumerator SpawnBall()
    {
        isSpawn = true;
        int randSpawn = Random.Range(0, spawnPoints.Length);
        isList = Instantiate(ball, spawnPoints[randSpawn].transform.position, Quaternion.identity);
        ballList.Add(isList);
        yield return new WaitForSeconds(1);
        isSpawn = false;
        if(ballList.Count >= maxBall)
        {
            yield return new WaitForSeconds(10);
            RemoveAllListBall();
        }
        
    }
    
    public void RemoveListz(GameObject law)
    {
        ballList.Remove(law);
        
    }
    public void RemoveAllListBall()
    {
        while (ballList.Count > 0)
        {
            RemoveListz(ballList[0]);
        }
    }
    


}
