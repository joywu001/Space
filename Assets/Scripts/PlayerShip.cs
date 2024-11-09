using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private Rigidbody rb;

    private float speed = 7f;
    private float tilt = 45f;

    public GameObject bullet;
    public Transform bulletPos;
    public float coldDownTime;
    private float nextShot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector2 input = InputManager.instance.moveAction.ReadValue<Vector2>();
        Vector3 movement = new Vector3(input.x, 0, input.y) * speed;
        rb.velocity = movement;

        float clampedX = Mathf.Clamp(rb.position.x, -8f, 8f);
        float clampedZ = Mathf.Clamp(rb.position.z, -4.5f, 4.5f);

        rb.position = new Vector3(clampedX, rb.position.y, clampedZ);

        float tiltAngle = -rb.velocity.x * tilt;
        rb.rotation = Quaternion.Euler(0, 0, tiltAngle);
    }

    void Update()
    {
        if (InputManager.instance.fireAction.triggered && Time.time > nextShot)
        {
            Instantiate(bullet, bulletPos.position, bulletPos.rotation);
            nextShot = Time.time + coldDownTime;
        }
    }
}
