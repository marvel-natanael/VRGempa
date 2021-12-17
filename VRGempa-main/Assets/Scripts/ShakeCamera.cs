using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ShakeCamera : Quake
{
    [SerializeField] TextMeshProUGUI magnitudeText;
    [SerializeField] Camera cameraRig;
    [SerializeField] float crouch;
    [SerializeField] Quaternion headsetRotation;
    [SerializeField] float duration = 10.0f;
    public static int presses = 0;
    public static bool isFalling = false;

    void Awake()
    {
        Quake quake = new Quake();
        magnitudeText.gameObject.SetActive(false);
    }

    public override IEnumerator ShakeObj(float magnitude)
    {
        Vector3 orignalPosition = this.gameObject.transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            magnitudeText.gameObject.SetActive(true);
            magnitudeText.text = "CARI TEMPAT<br>BERLINDUNG";

            if (elapsed >= 5.0f)
            {
                isFalling = true;
                if (presses == 2 && crouch >= 0.4)
                {
                    magnitudeText.text = "AMAN";
                    magnitudeText.color = new Color(0.0f, 1.0f, 0.0f);
                }
                else
                {
                    magnitudeText.text = "RAWAN";
                    magnitudeText.color = new Color(1.0f, 0.0f, 0.0f);
                }
            }

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + transform.position.x, y + transform.position.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
        isFalling = false;
        presses = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        headsetRotation = cameraRig.transform.rotation;
        crouch = headsetRotation.x;
    }
}
