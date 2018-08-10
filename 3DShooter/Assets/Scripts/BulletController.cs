using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    public int timeUntilDisappear;

    private Rigidbody rb;

    private float timeCreated;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        timeCreated = Time.time;
	}
	
    // Bullets move forwards in straight line, stay on screen for max 5 seconds
	void Update () 
    {
        if (Time.time - timeCreated > timeUntilDisappear)
        {
            Destroy(this.gameObject);
        }
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
	}

}
