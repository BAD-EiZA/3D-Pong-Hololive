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
    [Header("Layer Mask")]
    public LayerMask Side1Obs;
    public LayerMask Side2Obs;
    public LayerMask Top1Obs;
    public LayerMask Top2Obs;
    public LayerMask Grounds;
    [Header("Var")]
    public float seconds;
    public float timer;
    public int maxBall;
    public float SiderCheckRadius = 0.3f;
    [Header("Boolean")]
    public bool isSpawn;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        SpawnerBall();
        ballList = new List<GameObject>();
        isSpawn = false;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        seconds = Mathf.FloorToInt(timer % 60);
        if (seconds % 5 == 0 && !isSpawn)
        {
            SpawnerBall();
        }
    }
    public void SpawnerBall()
    {
        StartCoroutine("SpawnBall");
    }
    public IEnumerator SpawnBall()
    {
        isSpawn = true;
        yield return new WaitForSeconds(5);
        int randSpawn = Random.Range(0, spawnPoints.Length);
        GameObject Spawners = Instantiate(ball, spawnPoints[randSpawn].transform.position, Quaternion.identity);
        ballList.Add(Spawners);
        if (ballList.Count >= maxBall)
        {
            isSpawn = true;
        }
        else
        {
            isSpawn = false;
        }
    }
    

}
