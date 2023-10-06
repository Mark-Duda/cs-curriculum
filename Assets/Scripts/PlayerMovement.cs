using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool overworld;
    private float Walkingspeed;
    private float Xdirection;
    private float Xvector;
    private float Ydirection;
    private float Yvector;
    // Start is called before the first frame update
    void Start()
    {
        Walkingspeed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (overworld)
        {
            Xdirection = Input.GetAxis("Horizontal");
            Xvector = Xdirection * Walkingspeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(Xvector, 0, 0);
            Ydirection = Input.GetAxis("Vertical");
            Yvector = Ydirection * Walkingspeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(0, Yvector, 0);
            
        }
        else
        {
            Xdirection = Input.GetAxis("Horizontal");
            Xvector = Xdirection * Walkingspeed * Time.deltaTime;
            transform.position = transform.position + new Vector3(Xvector, 0, 0);
        }
        
        
    }
}
