using UnityEngine;

public class UniformSquareMotion : MonoBehaviour
{
    private const float MinSpeed = 1;
    private const float MaxSpeed = 3;
    private const float DefaultTimeToChangeDirection = 5;

    private Vector3 _currentDirection;
    private float _timeToChangeDirection;
    private float _speed = 1.0f;

    // Use this for initialization
    void Start()
    {
        _currentDirection = new Vector3 { x = Random.value, y = 0, z = Random.value }.normalized;
        _timeToChangeDirection = DefaultTimeToChangeDirection;
        _speed = Random.Range(MinSpeed, MaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_currentDirection * Time.deltaTime * _speed);
        _timeToChangeDirection -= Time.deltaTime;

        if (_timeToChangeDirection < 0)
        {
            RotateBy90Degrees();
            _timeToChangeDirection = DefaultTimeToChangeDirection;
        }
    }

    private void RotateBy90Degrees()
    {
        _currentDirection = Quaternion.Euler(0, 90, 0) * _currentDirection;
    }
}
