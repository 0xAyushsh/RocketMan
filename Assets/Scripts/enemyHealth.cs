using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    public GameObject enemyDeathFX;
    public Slider enemyHealthSlider;

    public AudioClip enemyDeathSound;

    public bool drops;
    public GameObject theDrop;


    float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        enemyHealthSlider.maxValue = currentHealth;
        enemyHealthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage) {
        enemyHealthSlider.gameObject.SetActive(true);   
        currentHealth -= damage;
        if (currentHealth <= 0) makeDead();
        enemyHealthSlider.value = currentHealth;
    }

    void makeDead() {
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
        if (Random.Range(0, 10) >=5 )
        {
            drops = true;
        }
        else drops = false;
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
