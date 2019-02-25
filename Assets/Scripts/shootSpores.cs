using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpores : MonoBehaviour
{

    public GameObject theProjectile;
    public float chancesShoot;
    public float shootTime;
    public Transform shootFrom;

    float nextShootTime;
    Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && (nextShootTime < Time.time)) {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) > chancesShoot) {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
                myAnim.SetTrigger("canonShoot");
            }
        }
    }
}
