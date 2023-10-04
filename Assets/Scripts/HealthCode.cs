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
    private bool iframes = false;
    private int health = 5;

    private CoinCollect coinpurse;

    private void Start()
    {
        coinpurse = FindObjectOfType<CoinCollect>();
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


    void OnCollisionEnter2D(Collision2D collision )
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                ChangeHealth(-1);
                iframes = true;
            }

            if (health < 1)
            {
                death();
            }

        }
    }
    void ChangeHealth(int amount)
    {
        
        health+=amount;
        Debug.Log("Health: "+health);
        
            
    }
    void death()
    {
        health = 5;
        coinpurse.gold = 0;
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
   
    

}