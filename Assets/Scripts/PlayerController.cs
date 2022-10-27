using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Mover movement;
    private Shooter shooter;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.Steer(Input.GetAxis("Horizontal"));

        if (Input.GetMouseButtonDown(0)) {
            shooter.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
