using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineControllers : MonoBehaviour
{
    public static CinemachineControllers instance;
    public Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        instance = this;

    }
}
