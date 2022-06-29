using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject canva;
    [SerializeField]
    private GameObject title;
    public void SingleGame()
    {
        GameData.instance.isDlc = false;
        SceneManager.LoadScene("Gameplay");
        Debug.Log("Created by Erzhanto - 149251970101-196");
    }
    public void MultiGame()
    {
        GameData.instance.isDlc = true;
        SceneManager.LoadScene("DLC");
        Debug.Log("Created by Erzhanto - 149251970101-196");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnCanvaGame()
    {
        canva.SetActive(true);
    }
    public void OnTitleGame()
    {
        title.SetActive(true);
    }
    public void OffTitleGame()
    {
        title.SetActive(false);
    }
}
