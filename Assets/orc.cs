using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orc : MonoBehaviour
{
  
    
    public bool isInRange;
    public Transform orctarget;
    public Transform iposition;
    private float health;
    private float iframesTimer;
    private float iframesTimerDefault = 1;
    private bool iframes = false;
    private int OrcHealth;

    
    // Start is called before the first frame update
    private void Start()
    {
        iframesTimer = iframesTimerDefault;
        OrcHealth = 5;

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    public float orcSpeed;
    private void Update()
    {
        if (isInRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, orctarget.position, orcSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, iposition.position, orcSpeed * Time.deltaTime);
        }

        if (iframes)
        {
            iframesTimer -= Time.deltaTime;
            if (iframesTimer < 0)
            {
                iframes = false;
                //reset the timer
                iframesTimer = iframesTimerDefault;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            if (!iframes)
            {
                iframes = true;
            }


            if (OrcHealth < 1)
            {
                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!iframes)
            {
                ChangeOrcHealth(-1);
                iframes = true;
            }

            if (OrcHealth < 1)
            {
                Destroy(gameObject);
            }


        }


        void ChangeOrcHealth(int amount)
        {
            OrcHealth += amount;
            Debug.Log("OrcHealth: " + OrcHealth);

        }

    }
}