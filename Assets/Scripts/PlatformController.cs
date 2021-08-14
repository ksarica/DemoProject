using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 startingDirection;
    [SerializeField] private float turnAfterXSecond;

    private float _amountToMove;

    private float timeCounter;

    void Start()
    {
        timeCounter = turnAfterXSecond;
    }

    private void Update()
    {
        StartMoving(startingDirection);
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
        }
        else
        {
            timeCounter = turnAfterXSecond;
            startingDirection *= -1;
        }

    }

    private void StartMoving(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

}
