using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
	}
	
    // Bullets move forwards in straight line, stay on screen for max 5 seconds
	void Update () 
    {
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
	}

}
