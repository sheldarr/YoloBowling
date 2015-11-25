using UnityEngine;
using System.Text.RegularExpressions;


/// <summary>
/// Created: 24/11/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 24/11/2015
/// LastModifiedBy: Rafał Ostrowski
/// Description: Responsible for respawning a pin after it fell off the game floor.
/// </summary>
public class PinRespawning : MonoBehaviour
{
    /// <summary>
    /// Minimum allowed height.
    /// </summary>
    private float _minimumAllowedHeight;

    /// <summary>
    /// Initialize.
    /// </summary>
    private void Start()
    {
        _minimumAllowedHeight = 2f;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        if (transform.position.y < _minimumAllowedHeight)
        {
            Color currentObjectColor = gameObject.GetComponent<Renderer>().material.color;
            string prefabName = GeneratePrefabName();

            DestroyCurrentObjectAndLogInfo();

            var newPin = Instantiate(Resources.Load(prefabName)) as GameObject;
            if (newPin != null)
            {
                newPin.GetComponent<Renderer>().material.color = currentObjectColor;
            }
        }
    }

    /// <summary>
    /// Generates name for a prefab which will be used to Instantiate new game object.
    /// </summary>
    /// <returns>Generated name</returns>
    private string GeneratePrefabName()
    {
        string currentPinNumber = Regex.Match(gameObject.name, @"\d+").Value;
        return "PrefabPin" + currentPinNumber;
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
