using UnityEngine;

public class Oscilator : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector;
    [SerializeField] private float _speed;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _movementFactor;


    void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition + _movementVector;
    }

    void Update()
    {
        _movementFactor = Mathf.PingPong(Time.time * _speed, 1f);
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _movementFactor);
    }
}
