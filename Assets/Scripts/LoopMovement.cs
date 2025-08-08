using UnityEngine;

public class LoopMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _assendSpeed = 1;
    [SerializeField] private float _endPosition = 30;
    [SerializeField] private bool _direction = true;


    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        if (_direction && transform.position.x > _endPosition ||
            !_direction && transform.position.x < _endPosition)
        {
            transform.position = _startPosition;
        }
        int direction = _direction ? 1 : -1;
        transform.Translate(new Vector3(direction * _moveSpeed, _assendSpeed, 0f) * Time.deltaTime);
    }
}
