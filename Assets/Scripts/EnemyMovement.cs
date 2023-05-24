using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private float _distanceThreshold = 0.01f;
    private bool _isMoving;

    private void Start()
    {
        TargetPoint[] targetpoints = FindObjectsByType<TargetPoint>(FindObjectsSortMode.None);
        
        if (targetpoints.Length > 0)
        {
            _targetPosition = targetpoints[0].transform.position;
            _isMoving = true;
        }
    }

    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            transform.up = _targetPosition - transform.position;

            if (Vector3.Distance(transform.position, _targetPosition) < _distanceThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
