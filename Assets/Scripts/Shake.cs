using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shake : MonoBehaviour
{
    public static float mg = 0.0f;
    public static bool left, right;
    public TextMeshProUGUI magnitudeText;

    public IEnumerator ShakeCam(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x, y, 0f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}
