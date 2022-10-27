using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPool : MonoBehaviour
{
    public UnityEvent onDie;
    public float shakeIntensityOnHit = 0.1f;

    public void Hurt(int amount) {

        if (IsAlive()) {
			CrewController[] crew = GetComponentsInChildren<CrewController>();
			Destroy(crew[Random.Range(0, crew.Length)].gameObject);

            FindObjectOfType<CameraShake>().Shake(shakeIntensityOnHit, shakeIntensityOnHit);

            if (crew.Length == 1) {
				onDie.Invoke();
			}
		}
    }

    public int GetHealth() {
        return GetComponentsInChildren<CrewController>().Length;
    }

    public bool IsAlive() {
        return GetHealth() > 0;
    }
}
