using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("UI")]
    public Text Player1ScoreUI;
    public Text Player2ScoreUI;
    public Text Player3ScoreUI;
    public Text Player4ScoreUI;
    public GameObject P1WinUI;
    public GameObject P2WinUI;
    public GameObject P3WinUI;
    public GameObject P4WinUI;
    public GameObject countHandler;
    void Start()
    {
        instance = this;
    }
}
