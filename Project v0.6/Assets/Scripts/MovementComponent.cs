using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class MovementComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private MovementType movementType;
    
    private Vector3 moveBy;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    void OnMovement(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        moveBy = new Vector3(inputValue.x, 0, inputValue.y);
    }

    void OnJump(InputValue input)
    {
        GetComponent<Rigidbody>().AddForce(0,8,0, ForceMode.VelocityChange);
    }
    
    void Update()
    {
        ExecuteMovement();
    }
    
    void ExecuteMovement() {
        if (movementType == MovementType.TransformBased) {
            //transform.position += moveBy * (speed * Time.deltaTime);
            transform.Translate(moveBy * (speed * Time.deltaTime));
        }
        else if (movementType == MovementType.PhysicsBased)
        {
            var rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddForce(moveBy * 2, ForceMode.Acceleration);
        }
        
    }
}
