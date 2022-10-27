using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballController : MonoBehaviour
{
    private Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x > 10 ||
                transform.localPosition.x < -10 ||
                transform.localPosition.y > 10 ||
                transform.localPosition.y < -10) {
            Destroy(gameObject);
        }
    }

    public void SetVelocity(Vector2 velocity) {
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Ship") && collider.gameObject.layer != gameObject.layer) {
            if (collider.gameObject.TryGetComponent(out HealthPool healthPool))
                healthPool.Hurt(1);
            if (collider.gameObject.TryGetComponent(out Mover mover))
                mover.SetKnockback(body.velocity.normalized, 0.1f);
			Destroy(gameObject);
		}
    }
}
