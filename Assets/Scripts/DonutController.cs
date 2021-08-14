using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    //[SerializeField] private float _rotationDuration;

    private Vector3 startingDirection;

    void Start()
    {
        startingDirection = Vector3.left;
    }

    void Update()
    {
        transform.Rotate(startingDirection * (_rotationSpeed * Time.deltaTime));
    }
}
