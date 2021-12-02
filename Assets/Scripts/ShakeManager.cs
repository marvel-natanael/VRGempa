using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private Shake shake;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();
    }

    public void shakeObj()
    {
        StartCoroutine(shake.ShakeCam(3.0f, 0.01f));
    }
}
