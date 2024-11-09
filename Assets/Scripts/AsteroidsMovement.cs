using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsMovement : MonoBehaviour
{
    public float AsteroidSpeed = 7f;

    void Update()
    {
        transform.Translate(Vector3.back * AsteroidSpeed * Time.deltaTime);
    }
}
