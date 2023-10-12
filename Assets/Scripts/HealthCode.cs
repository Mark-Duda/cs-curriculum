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
        if (other.gameObject.CompareTag("Potion"))
        {
            ChangeHealth(3);
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

            if (hud.health < 1)
            {
                Death();
            }

        }
    }
    
    void ChangeHealth(int amount)
    {
        
        hud.health+=amount;
        Debug.Log("Health: "+hud.health);
        
            
    }

    void Death()
    {
        hud.health = 5;
        hud.gold = 0;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
}