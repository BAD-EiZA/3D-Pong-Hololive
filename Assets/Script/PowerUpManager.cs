using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager instance;
    public bool isSpawnPower;
    public int maxPowerUp;
    public float seconds;
    public float timer;
    public List<GameObject> PowerUp;
    public List<GameObject> PowerList;
    public GameObject IsPower;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isSpawnPower = false;
        PowerList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        seconds = Mathf.FloorToInt(timer % 60);
        if (seconds % 20 == 0 && !isSpawnPower && PowerList.Count < maxPowerUp && ScoreManager.instance.isGameOver == false)
        {
            StartCoroutine("SpawnPower");


        }
    }
    public IEnumerator SpawnPower()
    {
        isSpawnPower = true;
        int randsSpawn = Random.Range(0, PowerUp.Count);
        IsPower = Instantiate(PowerUp[randsSpawn], new Vector3(Random.Range(-4f, 4f), 0.5f, Random.Range(-4f, 4f)), Quaternion.identity);
        PowerList.Add(IsPower);
        yield return new WaitForSeconds(1);
        isSpawnPower = false;
        if (PowerList.Count >= maxPowerUp)
        {
            yield return new WaitForSeconds(10);
            RemoveAllPower();
        }

    }
    public void RemovePowerz(GameObject lawz)
    {
        PowerList.Remove(lawz);
        Destroy(lawz);
    }
    public void RemoveAllPower()
    {
        while (PowerList.Count > 0)
        {
            RemovePowerz(PowerList[0]);
        }
    }
}
