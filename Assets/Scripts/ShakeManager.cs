using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour
{
    private Shake shake;
    private int presses = 0;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();
    }

    public void shakeObj(float magnitude)
    {
        StartCoroutine(shake.ShakeCam(magnitude));
    }

    public void onPressed()
    {
        presses++;
        Shake.presses = presses;
        Debug.Log(Shake.presses);
    }


    public void onLift()
    {
        presses = 0;
        Shake.presses = presses;
        Debug.Log(Shake.presses);
    }
}
