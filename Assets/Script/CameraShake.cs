using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    public bool isShaking = false;
    public AnimationCurve curve;
    public float dur = 1f;

    void Start()
    {
        instance = this;
    }
    void Update()
    {
        if (isShaking)
        {
            isShaking = false;
            StartCoroutine("Shakes");
        }
    }
    public IEnumerator Shakes()
    {
        Vector3 startPos = transform.position;
        float longTime = 0f;
        while(longTime < dur)
        {
            longTime += Time.deltaTime;
            float power = curve.Evaluate(longTime / dur);
            transform.position = startPos + Random.insideUnitSphere * power;
            yield return null;
        }
        transform.position = startPos;
    }
}
