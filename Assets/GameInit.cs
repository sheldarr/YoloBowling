using UnityEngine;

/// <summary>
/// Created: 10/11/2015
/// CreatedBy: Kewin Polok
/// LastModified: 09/12/2015
/// LastModifiedBy: Kewin Polok
/// Description: Game initialization script.
/// </summary>
public class GameInit : MonoBehaviour
{
    public GameObject Pin1;
    public GameObject Pin2;
    public GameObject Pin3;
    public GameObject Pin4;
    public GameObject Pin5;
    public GameObject Pin6;
    public GameObject Pin7;
    public GameObject Pin8;
    public GameObject Pin9;
    public GameObject Pin10;

    public GameObject BowlingBall;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start () {
        Pin1.GetComponent<Renderer>().material.color = Color.green;
        Pin2.GetComponent<Renderer>().material.color = Color.green;
        Pin3.GetComponent<Renderer>().material.color = Color.green;
        Pin4.GetComponent<Renderer>().material.color = Color.yellow;
        Pin5.GetComponent<Renderer>().material.color = Color.yellow;
        Pin6.GetComponent<Renderer>().material.color = Color.yellow;
        Pin7.GetComponent<Renderer>().material.color = Color.red;
        Pin8.GetComponent<Renderer>().material.color = Color.red;
        Pin9.GetComponent<Renderer>().material.color = Color.red;
        Pin10.GetComponent<Renderer>().material.color = Color.red;
    }
}
