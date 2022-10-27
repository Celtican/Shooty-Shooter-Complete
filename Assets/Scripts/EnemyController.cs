using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Mover movement;
	private GameObject target;

	// Start is called before the first frame update
	void Start() {
		movement = GetComponent<Mover>();
		target = FindObjectOfType<PlayerController>().gameObject;
	}

	// Update is called once per frame
	void Update()
    {
		float curDirectionAngle = transform.eulerAngles.z * Mathf.Deg2Rad - Mathf.PI/2f;
		Vector2 curDirection = new Vector2(Mathf.Cos(curDirectionAngle), Mathf.Sin(curDirectionAngle));
		float adjustAngle = -Vector2.SignedAngle(target.transform.position - transform.position, curDirection) * Mathf.Deg2Rad;

		movement.Steer(-adjustAngle);

		if (adjustAngle > 0) {
			for (float angle = curDirectionAngle; angle < curDirectionAngle + adjustAngle; angle += Mathf.PI / 16f) {
				Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized, Color.green);
			}
		} else {
			for (float angle = curDirectionAngle; angle > curDirectionAngle + adjustAngle; angle -= Mathf.PI / 16f) {
				Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized, Color.red);
			}
		}

		//Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(curDirectionAngle), Mathf.Sin(curDirectionAngle)).normalized, Color.red);
		Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(curDirectionAngle + adjustAngle), Mathf.Sin(curDirectionAngle + adjustAngle)).normalized, adjustAngle > 0 ? Color.green : Color.red);
		Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(curDirectionAngle), Mathf.Sin(curDirectionAngle)).normalized, Color.white);
		//Debug.DrawRay(transform.position, new Vector2(Mathf.Cos(adjustAngle + curDirectionAngle), Mathf.Sin(adjustAngle + curDirectionAngle)).normalized, Color.yellow);
	}
}
