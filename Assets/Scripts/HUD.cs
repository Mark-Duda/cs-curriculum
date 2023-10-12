using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{ 
    public int health;
    public int gold;

    public TextMeshProUGUI coinText;

    public TextMeshProUGUI healthText;
    public static HUD hud;
    void Awake()
    {
        if (hud != null && hud != this)
        {
            
            Destroy(gameObject);
            Debug.Log("Duplicate HUD found. Destroying the current instance.");
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("HUD is set to this instance.");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins= "+gold;
        healthText.text = "Health= "+health;
    }
}

