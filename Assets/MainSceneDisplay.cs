using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Changes the look of the main scene - f.e. sets its default color and allows to set a random color.
/// Interacts with player's mouse and keyboard.
/// Keys:
/// k - allows to randomize floor's color
/// Mouse buttons:
/// right key - allows to randomize floor's color
/// </summary>
public class MainSceneDisplay : MonoBehaviour
{
    private const int MouseRightKey = 1;
    private const string ChangeColorKey = "k";
    private readonly Color _defaultColor = Color.black;


    // Use this for initialization
    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = _defaultColor;
    }

    // Update is called once per frame
    private void Update()
    {
        if (RightMouseWasClicked() || ChangeColorKeyWasPressed())
        {
            ChangeSceneColorToRandom();
        }
    }

    /// <summary>
    /// Detects if mouse's right button was clicked.
    /// </summary>
    /// <returns>True if the right key was pressed.</returns>
    private bool RightMouseWasClicked()
    {
        return Input.GetMouseButtonDown(MouseRightKey);
    }

    /// <summary>
    /// Detects if key that is responsible for changing the color was pressed on a keyboard.
    /// </summary>
    /// <returns>True if the key responsible was changing color was pressed.</returns>
    private bool ChangeColorKeyWasPressed()
    {
        return Input.GetKeyUp(ChangeColorKey);
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
