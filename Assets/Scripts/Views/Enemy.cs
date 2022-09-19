using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region [ Fields ]
    [SerializeField] private float _speedMove;
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _range;
    #endregion

    #region [ Properties ]
    private Transform _target;
    private List<Transform> _neighbors;
    #endregion

    #region [ Public Methods ]
    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public Transform GetTarget()
    {
        if (_target) return _target;
        return null;
    }

    public void SetSpeedMove(float speedMove)
    {
        _speedMove = speedMove;
    }

    public float GetSpeedMove()
    {
        return _speedMove;
    }

    public void SetStopDistance(float stopDistance)
    {
        _stopDistance = stopDistance;
    }

    public float GetStopDistance()
    {
        return _stopDistance;
    }

    public void SetListNeighbor(List<Transform> neighbor)
    {
        _neighbors = neighbor;
    }

    public List<Transform> GetListNeighbor()
    {
        return _neighbors;
    }

    public void SetRange(float range)
    {
        _range = range;
    }

    public float GetRange()
    {
        return _range;
    }
    #endregion
}
