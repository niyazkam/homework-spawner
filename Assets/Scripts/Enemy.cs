using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;
    private float _distanceThreshold = 0.01f;
    private bool _isMoving = false;

    public void Init(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        _isMoving = true;
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
