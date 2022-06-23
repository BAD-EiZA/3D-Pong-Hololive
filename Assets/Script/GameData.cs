using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public bool isDlc;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
