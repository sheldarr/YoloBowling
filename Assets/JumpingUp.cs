using UnityEngine;

/// <summary>
/// Created: 24/11/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 24/11/2015
/// LastModifiedBy: Rafał Ostrowski
/// Description: Responsible for jumping up once collision is detected. 
/// Once an object reached certain height, Rigidbody is generated for it,
/// which makes sure it falls down.
/// </summary>
public class JumpingUp : MonoBehaviour
{
    /// <summary>
    /// Determines whether an object's already jumped.
    /// </summary>
    private bool _wasIntoSpace;

    /// <summary>
    /// Determines whether an object is currently flying.
    /// </summary>
    private bool _isFlying;

    /// <summary>
    /// Speed used to move object up.
    /// </summary>
    private float _upSpeed;

    /// <summary>
    /// Initialization.
    /// </summary>
    private void Start()
    {
        _upSpeed = 0.3f;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        if (_isFlying)
        {
            transform.Translate(new Vector3(0, _upSpeed, 0));
            _upSpeed -= Time.deltaTime;
        }

        if (_upSpeed <= 0 && !_wasIntoSpace)
        {
            _wasIntoSpace = true;
            _isFlying = false;

            GenerateRigidbodyForObject();
            GenerateBoxColliderForObject();
        }
    }

    /// <summary>
    /// Generate box collider and assign it to object.
    /// </summary>
    private void GenerateBoxColliderForObject()
    {
        var boxCollider = gameObject.GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }
    }

    /// <summary>
    /// Generate rigid body and assign it to object.
    /// </summary>
    private void GenerateRigidbodyForObject()
    {
        var rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.useGravity = true;
    }

    /// <summary>
    /// Called when collision with an object was detected.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        _isFlying = true;
    }
}
