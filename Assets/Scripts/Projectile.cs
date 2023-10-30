using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyDelay = 2.0f;

    public orc orc;
    // Start is called before the first frame update
    void Start()
    {
        orc = GameObject.FindObjectOfType<orc>();
        Invoke("DestroyBullet", destroyDelay);
    }

    void OnCollisonEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //ChangeOrcHealth(-1);
            DestroyBullet();
        }
        if (other.gameObject.CompareTag("wall"))
        {
            DestroyBullet();
        }
        
    }
    

    public float projectileSpeed;
    // Update is called once per frame
    private void Update()
    {
        
        transform.Translate(new Vector2( projectileSpeed*Time.deltaTime,0.0f));
       
        

    }
    void DestroyBullet()
    {
        // Destroy the bullet game object
        Destroy(gameObject);
    }
}

