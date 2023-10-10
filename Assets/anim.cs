using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PotionController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // This is the function specified in the Animation Event.
    public void ActivatePotionEffect()
    {
        // Code to activate the potion effect when the animation event occurs.
    }

    // Trigger the animation when needed.
    public void PlayPotionAnimation()
    {
        animator.SetTrigger("Potions");
    }
}