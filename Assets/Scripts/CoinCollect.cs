using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;




public class CoinCollect : MonoBehaviour
{
    private int gold = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        CollectCoin(3);
        Destroy(other.gameObject);
    }

    void CollectCoin(int ammount)
    {
        gold+=ammount;
        Debug.Log("Gold: "+gold);
    }

}

