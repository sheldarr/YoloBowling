using UnityEngine;

/// <summary>
/// Created: 10/11/2015
/// CreatedBy: Kewin Polok
/// LastModified: 11/11/2015
/// LastModifiedBy: Kewin Polok
/// Description: Game initialization script. At this moment it only sets different material color for pins with different motion.
/// </summary>
public class GameInit : MonoBehaviour {
    /// <summary>
    /// Initialization
    /// </summary>
    void Start () {
        GameObject.Find("Pin_1").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("Pin_2").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("Pin_3").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("Pin_4").GetComponent<Renderer>().material.color = Color.yellow;
        GameObject.Find("Pin_5").GetComponent<Renderer>().material.color = Color.yellow;
        GameObject.Find("Pin_6").GetComponent<Renderer>().material.color = Color.yellow;
        GameObject.Find("Pin_7").GetComponent<Renderer>().material.color = Color.red;
        GameObject.Find("Pin_8").GetComponent<Renderer>().material.color = Color.red;
        GameObject.Find("Pin_9").GetComponent<Renderer>().material.color = Color.red;
        GameObject.Find("Pin_10").GetComponent<Renderer>().material.color = Color.red;
    }
}
