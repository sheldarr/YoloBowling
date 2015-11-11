using UnityEngine;

/// <summary>
/// Created: 10/11/2015
/// CreatedBy: Kewin Polok
/// LastModified: 11/11/2015
/// LastModifiedBy: Kewin Polok
/// Description: Simple script which constantly transforms object vertically up and down
/// </summary>
public class UpDownMotion : MonoBehaviour {

    /// <summary>
    /// The vertical speed
    /// </summary>
    private const float VerticalSpeed = 0.05f;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {
        transform.Translate(0, Mathf.Sin(Time.time) * VerticalSpeed, 0);
    }
}
