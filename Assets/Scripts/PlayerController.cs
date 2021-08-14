using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float amountToMove;
    void Update()
    {
        amountToMove = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        transform.position += (transform.right * amountToMove);
    }
}
