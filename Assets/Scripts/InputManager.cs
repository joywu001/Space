using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private Rigidbody rb;
    public static InputManager instance;

    public InputActionAsset controls;
    public InputAction moveAction;
    public InputAction fireAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveAction = controls.FindAction("Move");
        fireAction = controls.FindAction("Fire");
    }

    
}
