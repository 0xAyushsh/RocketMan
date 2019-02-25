using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sporeController : MonoBehaviour
{
    public float sporeSpeedLow;
    public float sporeSpeedHigh;
    public float sporeAngle;
    public float sporeTorqueAngle;
    Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
        myRb.AddForce(new Vector2(Random.Range(-sporeAngle, sporeAngle), Random.Range(sporeSpeedLow, sporeSpeedHigh)), ForceMode2D.Impulse);
        myRb.AddTorque((Random.Range(-sporeTorqueAngle, sporeTorqueAngle)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
