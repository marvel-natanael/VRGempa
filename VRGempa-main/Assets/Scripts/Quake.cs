using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quake : MonoBehaviour
{
    public Quake()
    {
        Debug.Log("Quake constructor called");
    }

    public virtual IEnumerator ShakeObj(float magnitude)
    {
        Vector3 orignalPosition = this.gameObject.transform.position;
        float duration = 3.0f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(x + transform.position.x, y + transform.position.y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }

    public virtual IEnumerator ShakeObj(float magnitude, Vector3 orignalPosition)
    {
        yield return null;
    }
}

