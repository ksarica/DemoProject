using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    //[SerializeField] private float _rotationDuration;

    private Vector3 startingDirection;

    void Start()
    {
        startingDirection = Vector3.forward;
    }

    void Update()
    {
        transform.Rotate(startingDirection * (_rotationSpeed * Time.deltaTime));
    }
}
