using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

   
    public float fullHealth;
    public GameObject deathFX;
    float currentHealth;
    public AudioClip playerHurt;

    
    playerController controlMovement;

    //HUD variable
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreen;
    public Text gameWinScreen;


    public gameRestart theGameManager;
    public AudioClip playerDeathSound;

    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 0.7f);
    float smoothColor = 5f;

    

    AudioSource playerAs;




    // Use this for initialization
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //HUD initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;
        playerAs = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged) {
            damageScreen.color = damagedColor;
        }
        else {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.time);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        playerAs.clip = playerHurt;
        playerAs.Play();
        healthSlider.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount) {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth)
            currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }
    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);
        Destroy(gameObject);
        damageScreen.color = damagedColor;
        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.restartGame();

    }

    public void winGame() {
        Destroy(gameObject);
        theGameManager.restartGame();
        Animator winGameAnimator = gameWinScreen.GetComponent<Animator>();
        winGameAnimator.SetTrigger("gameOver");
    }
}