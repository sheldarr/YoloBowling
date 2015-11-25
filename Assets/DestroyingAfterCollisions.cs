using UnityEngine;

/// <summary>
/// Created: 24/11/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 24/11/2015
/// LastModifiedBy: Rafał Ostrowski
/// Description: Responsible for destroying an object after collision was detected for it 
/// a random number of times. Max random range is determined by N, which is set 
/// manually in object's inspector. 
/// </summary>
public class DestroyingAfterCollisions : MonoBehaviour
{
    /// <summary>
    /// Max random range.
    /// </summary>
    public int N;

    /// <summary>
    /// Number of detected collisions;
    /// </summary>
    private int _detectedCollisions;

    /// <summary>
    /// Number of maximum allowed collisions. Once it's exceeded, the object is destroyed.
    /// </summary>
    private int _maxCollisions;

    /// <summary>
    /// Initialization.
    /// </summary>
	void Start ()
	{
        _detectedCollisions = 0;

	    if (N < 1)
	    {
	        N = 2;
	    }

	    _maxCollisions = Random.Range(1, N);
	}

    /// <summary>
    /// Called each time a collision was detected for the object.
    /// </summary>
    void OnCollisionEnter(Collision other)
    {
        ++_detectedCollisions;
        if (_detectedCollisions >= _maxCollisions)
        {
            DestroyCurrentObjectAndLogInfo();
        }
    }

    /// <summary>
    /// Destroyes current object. Logs info to the console about it.
    /// </summary>
    private void DestroyCurrentObjectAndLogInfo()
    {
        Destroy(gameObject);
        Debug.Log(string.Format("Destroying {0}", gameObject.name));
    }
}
