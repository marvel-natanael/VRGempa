using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shake : MonoBehaviour
{
    public static float mg = 0.0f;
    public static int presses = 0;
    public TextMeshProUGUI magnitudeText;


    public IEnumerator ShakeCam(float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float duration = 3.0f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (presses >= 2)
            {
                magnitudeText.text = "AMAN";
                magnitudeText.color = new Color(0.0f, 1.0f, 0.0f);
            }
            else
            {
                magnitudeText.text = "RAWAN";
                magnitudeText.color = new Color(1.0f, 0.0f, 0.0f);
            }

            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, 0f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        magnitudeText.text = "";
        transform.position = orignalPosition;
    }
}
