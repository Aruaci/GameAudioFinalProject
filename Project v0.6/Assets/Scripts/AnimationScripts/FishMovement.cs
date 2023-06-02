using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    // control points as serialized fields
    [SerializeField] private Transform controlPoint0;
    [SerializeField] private Transform controlPoint1;
    [SerializeField] private Transform controlPoint2;
    [SerializeField] private Transform controlPoint3;
    
    // serialized field to control the speed
    [SerializeField] private float duration = 1;
    [SerializeField] private float pauseTimeMin = 2;
    [SerializeField] private float pauseTimeMax = 5;
    
    // create array of transforms to store control points
    private Transform[] _controlPoints;
    
    // float to store passed time
    private float _passedTime;
    
    // boolean that determines if the object should move forward or backwards
    private bool _moveForward = true;

    void Awake()
    {
        // create new transforms array and store control points in it
        _controlPoints = new [] { controlPoint0, controlPoint1, controlPoint2, controlPoint3 };
    }

    void Update()
    {
        // increase passed time
        _passedTime += Time.deltaTime;
        // use Min to ensure that passed time does not exceed the duration
        _passedTime = Mathf.Min(_passedTime + Time.deltaTime, duration);
        
        if (_passedTime == duration)
        {
            AkSoundEngine.PostEvent("Play_Fish_Splash", gameObject);
            _passedTime = 0;
        }

        this.transform.rotation = Quaternion.Euler(CalculateTangent(_passedTime / duration));
        this.transform.Rotate(0,270,0);
        this.transform.position = CalculatePosition(_passedTime / duration);
    }
    
    private Vector3 CalculatePosition(float u)
    {
        // formula of position on bezier curve:
        // position(u) = (1−u)3 * p0 + 3u(1−u)2 * p1 + 3u2(1−u) * p2 + u3 * p3
        
        Vector3 position =
            // (1−u)3 * p0 +
            Mathf.Pow(1 - u, 3) * _controlPoints[0].position +
            // 3u(1−u)2 * p1 +
            3 * u * Mathf.Pow(1 - u, 2) * _controlPoints[1].position +
            // u2(1−u) * p2 +
            3 * Mathf.Pow(u, 2) * (1-u) * _controlPoints[2].position + 
            // u3 * p3
            Mathf.Pow(u, 3) * _controlPoints[3].position;
        return position;
    }

    private Vector3 CalculateTangent(float u)
    {
        Vector3 tangent =
            -3 * Mathf.Pow(1 - u, 2) * _controlPoints[0].position +
            3 * Mathf.Pow(1 - u, 2) * _controlPoints[1].position -
            6 * u * (1 - u) * _controlPoints[1].position -
            3 * Mathf.Pow(u, 2) * _controlPoints[2].position +
            6 * u * (1 - u) * _controlPoints[2].position + 
            3 * Mathf.Pow(u, 2) * _controlPoints[3].position;

        return tangent;
    }
}
