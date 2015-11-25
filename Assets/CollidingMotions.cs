using UnityEngine;

/// <summary>
/// Created: 24/11/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 24/11/2015
/// LastModifiedBy: Rafał Ostrowski
/// Description: Responsible for moving an object in circle around a certain point;
/// </summary>
public class CollidingMotions : MonoBehaviour
{
    /// <summary>
    /// Object's speed.
    /// </summary>
    private float _speed;

    /// <summary>
    /// Current angle.
    /// </summary>
    private float _angle;

    /// <summary>
    /// Holds time to generate current angle based on it.
    /// </summary>
    private float _timer;

    /// <summary>
    /// Circle's radius.
    /// </summary>
    private float _radius = 0.7f;

    /// <summary>
    /// Coordinates of a point around which the object will move.
    /// </summary>
    private float _centerX, _centerY, _centerZ;

    /// <summary>
    /// Initialization.
    /// </summary>
    private void Start()
    {
        _centerX = 3.07f;
        _centerY = 3.81f;
        _centerZ = -11.589f;

        _speed = Random.value*5;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        _timer += Time.deltaTime;
        _angle = _timer*_speed;
        var rotateVector = new Vector3(_centerX + Mathf.Cos(_angle)*_radius, _centerY,
            (_centerZ + Mathf.Sin(_angle)*_radius));
        transform.position = rotateVector;
    }
}
