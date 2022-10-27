using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject canonballPrefab;
    public float canonballSpeed = 5;

	public void Shoot(Vector2 target) {
        Vector2 velocity = (target - new Vector2(transform.position.x, transform.position.y)).normalized * canonballSpeed;
        GameObject cannonball = Instantiate(canonballPrefab, transform.position, Quaternion.identity, transform.parent);
        cannonball.GetComponent<CannonballController>().SetVelocity(velocity);
        FindObjectOfType<CameraShake>().Shake(0.05f, 0.05f);
	}
}
