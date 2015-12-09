using UnityEngine;

/// <summary>
/// Created: 24/11/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Responsible for respawning a pin after it fell off the game floor.
/// </summary>
public class PinRespawning : MonoBehaviour
{
    /// <summary>
    /// Minimum allowed height.
    /// </summary>
    private float _minimumAllowedHeight = -3f;

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        if (!(transform.position.y < _minimumAllowedHeight))
        {
            return;
        }

        RespawnPin();

        DestroyObject(gameObject);
    }

    private void RespawnPin()
    {
        var currentObjectColor = gameObject.GetComponent<Renderer>().material.color;


        var newPin = Instantiate(Resources.Load(gameObject.name)) as GameObject;
        if (newPin != null)
        {
            newPin.GetComponent<Renderer>().material.color = currentObjectColor;
        }
    }
}
