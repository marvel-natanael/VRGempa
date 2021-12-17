using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShakeManager : MonoBehaviour
{
    [SerializeField] GameObject[] shake;
    [SerializeField] GameObject[] destroy;
    GameObject player;
    private int presses = 0;

    void Start()
    {
        shake = GameObject.FindGameObjectsWithTag("Shake");
        player = GameObject.FindGameObjectWithTag("Player");
        destroy = GameObject.FindGameObjectsWithTag("Destroy");
        
        foreach (GameObject obj in destroy)
        {
            obj.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void shakeObj(float magnitude)
    {
        foreach(GameObject obj in shake)
        {
            var _shake = obj.GetComponent<Shake>();
            StartCoroutine(_shake.ShakeObj(magnitude, obj.gameObject.transform.position));
        }

        var _player = player.GetComponent<ShakeCamera>();
        StartCoroutine(_player.ShakeObj(magnitude));

    }

    void Update()
    {
        if (ShakeCamera.isFalling)
        {
            foreach (GameObject obj in destroy)
            {
                obj.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public void onPressed()
    {
        presses++;
        ShakeCamera.presses = presses;
    }


    public void onLift()
    {
        presses = 0;
        ShakeCamera.presses = presses;
    }
}
