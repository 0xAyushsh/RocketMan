﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            playerHealth playerKill = other.GetComponent<playerHealth>();
            playerKill.makeDead();
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
