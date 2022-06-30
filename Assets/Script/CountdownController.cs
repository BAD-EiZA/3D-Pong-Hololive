using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownController : MonoBehaviour
{
    public int countTime;
    public Text countDisplay;

    private void Start()
    {
        StartCoroutine(CountdownPlay());
    }

    IEnumerator CountdownPlay()
    {
        while (countTime > 0)
        {
            countDisplay.text = countTime.ToString();
            yield return new WaitForSeconds(1f);
            countTime--;
        }
        countDisplay.text = "START!";
        GameManager.instance.isGameStart = true;
        yield return new WaitForSeconds(1f);
        UIManager.instance.countHandler.SetActive(false);
    }
}
