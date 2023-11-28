using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthCode : MonoBehaviour
{
    public GameObject invincible;
    public GameObject canvas;
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
            BecomeInvincible();
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
                BecomeInvincible();
                Debug.Log("ran script");
                iframes = true;
                BecomeInvincible();
                
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
                BecomeInvincible();
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

    void BecomeInvincible()
    {
        GameObject newSmoke = Instantiate(invincible, new Vector3(1159.5f, 552, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
        newSmoke.transform.SetParent(canvas.transform, false);
        newSmoke.transform.localScale = new Vector3(1, 1, 1);   
        Debug.Log("script finished");
    }
}