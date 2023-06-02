using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float duration = 2;
    private float _passedTime;
    // Update is called once per frame
    void Update()
    {
        _passedTime += Time.deltaTime;
        _passedTime = Mathf.Min(_passedTime + Time.deltaTime, duration);
        
        if (transform.rotation.x < 2f)
        {
            transform.Rotate(new Vector3(0.2f, 0, 0));
        }
        if (transform.rotation.x >= 2f)
        {
            print("helloooo");
            _passedTime = 0;
            transform.Rotate(new Vector3(-0.2f, 0, 0));
        }
    }
}

