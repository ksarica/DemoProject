using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] private Transform _player;
    [SerializeField] private List<Transform> _opponents;
    [SerializeField] private Transform _finishLine;

    [SerializeField] private int _currentPosition;
    [SerializeField] private float _checkDurationInEveryXSecond;

    [SerializeField] private TextMeshProUGUI _currentPositionText;
    
    public TextMeshProUGUI _winText;
    public TextMeshProUGUI _loseText;


    void Start()
    {
        _currentPosition = 1;
        StartCoroutine(WaitAndContinueChecking());
    }

    public int ReturnCurrentPosition()
    {
        return _currentPosition;
    }

    public void CalculatePositionOfThePlayer()
    {
        _currentPosition = 1;
        foreach (var opponent in _opponents)
        {
            var playerDistance = Mathf.Abs(GetDistanceToFinishLine(_player.position.z));
            var opponentDistance = Mathf.Abs(GetDistanceToFinishLine(opponent.position.z));
            if (playerDistance > opponentDistance)
            {
                _currentPosition++;
            }
        }
        _currentPositionText.text = "POS: " + _currentPosition + "/10";
    }

    public float GetDistanceToFinishLine(float currentTarget)
    {
        return _finishLine.position.z - currentTarget;
    }

    IEnumerator WaitAndContinueChecking()
    {
        CalculatePositionOfThePlayer();
        yield return new WaitForSeconds(_checkDurationInEveryXSecond);
        StartCoroutine(WaitAndContinueChecking());
    }

}
