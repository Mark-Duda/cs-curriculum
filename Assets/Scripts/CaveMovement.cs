using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMovement : MonoBehaviour
{
    private float Walkingspeed;
    private float Xdirection;
    private float Xvector;
    // Start is called before the first frame update
    void Start()
    {
        Walkingspeed = 5f;

    }

    // Update is called once per frame
    void Update()
    {
        Xdirection = Input.GetAxis("Horizontal");
        Xvector = Xdirection * Walkingspeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(Xvector, 0, 0);
    }
}
