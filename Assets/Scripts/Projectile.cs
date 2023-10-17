using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float projectileSpeed;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(new Vector2(0f, projectileSpeed*Time.deltaTime));
    }
}
