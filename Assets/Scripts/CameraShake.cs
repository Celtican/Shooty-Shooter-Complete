using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeUntil;
    private float intensity;

    // Update is called once per frame
    void Update()
    {
        if (Time.time < shakeUntil) {
            transform.localPosition = new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), transform.localPosition.z);
        } else {
            transform.localPosition = new Vector3(0, 0, transform.localPosition.z);
        }
    }

    public void Shake(float duration=0.1f, float intensity=0.1f) {
        shakeUntil = Time.time + duration;
        this.intensity = intensity;
    }
}
