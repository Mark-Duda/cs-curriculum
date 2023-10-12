using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;




public class CoinCollect : MonoBehaviour
{
    public HUD hud;
   
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CollectCoin(3);
            Destroy(other.gameObject);
        }
    }

    void CollectCoin(int amount)
    {
        hud.gold+=amount;
        Debug.Log("Gold: "+hud.gold);
    }

}

