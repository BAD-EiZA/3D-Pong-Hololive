using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePowerUp : MonoBehaviour
{
    private float rotatespd = 115f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * rotatespd * Time.deltaTime);
    }
}
