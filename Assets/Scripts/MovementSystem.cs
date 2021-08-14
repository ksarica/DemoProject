using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damping;

    [SerializeField] private Transform _target;

    private UIController _uiController;


    private Quaternion lookForward;
    private void Start()
    {
        _uiController = FindObjectOfType<UIController>();
        lookForward = Quaternion.Euler(0, 0, 1);
        if (this.GetComponent<PlayerController>() == null)
        {
            _speed = Random.Range(0.2f, 0.6f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishLine>() != null)
        {
            if (this.GetComponent<PlayerController>() != null)
            {
                PrintGameOverMessage();
                this.GetComponent<PlayerController>().enabled = false;
            }
            this.GetComponent<MovementSystem>().enabled = false;
        }

    }

    private void PrintGameOverMessage()
    {
        var position = _uiController.ReturnCurrentPosition();
        Debug.Log(position);
        if (position == 1)
        {
            Debug.Log("IF Satır İçi");
            _uiController._winText.gameObject.SetActive(true);
        }
        else
        {
            _uiController._loseText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<RotatingPlatformController>() != null)
        {
            transform.position += -transform.right * 0.15f * Time.deltaTime;
        }
    }

    void Update()
    {
        FixRotation();
        transform.position += (Vector3.forward * _speed * Time.deltaTime);
    }

    private void FixRotation()
    {
        var lookPos = _target.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(lookForward, rotation, Time.deltaTime * _damping);
    }

}
