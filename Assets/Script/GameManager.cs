using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Prefab & Spawn Point")]
    public GameObject ball;
    public GameObject[] spawnPoints;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnerBall()
    {
        StartCoroutine("SpawnBall");
    }
    public IEnumerator SpawnBall()
    {
        yield return new WaitForSeconds(5);
        int randSpawn = Random.Range(0, spawnPoints.Length);
        GameObject Spawners = Instantiate(ball, spawnPoints[randSpawn].transform.position, Quaternion.identity);

    }
}
