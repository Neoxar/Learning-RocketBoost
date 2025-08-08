using UnityEngine;

public class Spinning : MonoBehaviour
{
    private float _xSpinnSpeed;
    private float _ySpinnSpeed;
    private float _zSpinnSpeed;

    void Start()
    {
        _xSpinnSpeed = Random.Range(0f, 5f) * Time.deltaTime;
        _ySpinnSpeed = Random.Range(0f, 5f) * Time.deltaTime;
        _zSpinnSpeed = Random.Range(0f, 5f) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_xSpinnSpeed, _ySpinnSpeed, _zSpinnSpeed);
    }
}
