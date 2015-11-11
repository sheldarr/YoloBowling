using UnityEngine;

/// <summary>
/// Created: 10/11/2015
/// CreatedBy: Kewin Polok
/// LastModified: 11/11/2015
/// LastModifiedBy: Kewin Polok
/// Description: Simple script which constantly moves object in square path with constant speed.
/// </summary>
public class UniformSquareMotion : MonoBehaviour
{
    /// <summary>
    /// The minimum speed
    /// </summary>
    private const float MinSpeed = 1;
    /// <summary>
    /// The maximum speed
    /// </summary>
    private const float MaxSpeed = 5;
    /// <summary>
    /// The default time to change direction
    /// </summary>
    private const float DefaultTimeToChangeDirection = 1;

    /// <summary>
    /// The current direction
    /// </summary>
    private Vector3 _currentDirection;
    /// <summary>
    /// Time left to change direction
    /// </summary>
    private float _timeToChangeDirection;
    /// <summary>
    /// The actual speed
    /// </summary>
    private float _speed;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        _currentDirection = new Vector3 { x = Random.value, y = 0, z = Random.value }.normalized;
        _timeToChangeDirection = DefaultTimeToChangeDirection;
        _speed = Random.Range(MinSpeed, MaxSpeed);
    }

    /// <summary>
    /// Updates is called once per frame
    /// </summary>
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

    /// <summary>
    /// Rotates the current direction by 90 degrees.
    /// </summary>
    private void RotateBy90Degrees()
    {
        _currentDirection = Quaternion.Euler(0, 90, 0) * _currentDirection;
    }
}
