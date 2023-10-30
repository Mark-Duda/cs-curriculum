using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthCode : MonoBehaviour
{
    private float iframesTimer;
    private float iframesTimerDefault = 1.5f;
    public bool iframes = false;
    public HUD hud;

    

    private void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        
    }

    private void Update()
    {
        if (iframes) ;
        {
            iframesTimer -= Time.deltaTime;
            if (iframesTimer < 0)
            {
                iframes = false;
                iframesTimer = iframesTimerDefault;
            }

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ipotion"))
        {
            iframesTimer = 10.0f;
            iframes = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Potion"))
        {
            ChangeHealth(3);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
            }
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision )
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }
        }

    }
    
    void ChangeHealth(int amount)
    {
        
        hud.health+=amount;
        Debug.Log("Health: "+hud.health);
        if (hud.health < 1)
        {
            Death();
        }

            
    }

    void Death()
    {
        hud.health = hud.initialhealth;
        hud.gold = 0;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}