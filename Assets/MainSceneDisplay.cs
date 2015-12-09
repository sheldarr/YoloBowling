using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Created: 15/10/2015
/// CreatedBy: Rafał Ostrowski
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Changes the look of the main scene - f.e. sets its default color and allows to set a random color.
/// Interacts with player's mouse and keyboard.
/// Keys: k - allows to randomize floor's color
/// Mouse buttons: right button - allows to randomize floor's color
/// </summary>
public class MainSceneDisplay : MonoBehaviour
{
    // Update is called once per frame
    /// <summary>
    /// Updates this instance.
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            ChangeSceneColorToRandom();
        }
    }

    /// <summary>
    /// Generates a random color, which is then set for the main scene.
    /// </summary>
    private void ChangeSceneColorToRandom()
    {
        var randomColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

        gameObject.GetComponent<Renderer>().material.color = randomColor;
    }
}
