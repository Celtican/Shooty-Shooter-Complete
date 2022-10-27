using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 1f;
    [Range(0f, 1f)] public float speedRandomRange = 0;
    public float steerSpeed = 45f;
	public float selfKnockbackStrength = 1f;
	public float selfKnockbackDuration = 1f;

	private Rigidbody2D body;
    private Knockback knockback;
    private float timeSinceKnockback = 0;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        speed += Random.Range(-speedRandomRange, speedRandomRange);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = GetDirection() * speed;
        if (knockback != null) {
			timeSinceKnockback += Time.deltaTime;
			if (timeSinceKnockback >= knockback.duration) {
                timeSinceKnockback = 0;
                knockback = null;
                return;
            } else {
                direction *= timeSinceKnockback/knockback.duration;
                direction += knockback.direction * ((knockback.duration - timeSinceKnockback) / knockback.duration);
			}
        }

        body.velocity = direction;
        body.angularVelocity = 0;
    }

    public void Steer(float rotation) {
        transform.Rotate(0, 0, -Mathf.Clamp(rotation, -1, 1) * steerSpeed * Time.deltaTime);
    }

    public void SetKnockback(Vector2 direction, float duration) {
        knockback = new Knockback(direction, duration);
        timeSinceKnockback = 0;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public float GetAngle() {
        return Mathf.Deg2Rad * transform.eulerAngles.z - Mathf.PI / 2f;
	}

    public Vector2 GetDirection() {
        float angle = GetAngle();
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ship"))
            SetKnockback((transform.position - collision.transform.position).normalized * selfKnockbackStrength, selfKnockbackDuration);
        else if (collision.gameObject.CompareTag("Terrain"))
            SetKnockback(-GetDirection(), 1);
	}

    private class Knockback {
        public Vector2 direction;
        public float duration;

        public Knockback(Vector3 direction, float duration) {
            this.direction = direction;
            this.duration = duration;
        }
    }
}
