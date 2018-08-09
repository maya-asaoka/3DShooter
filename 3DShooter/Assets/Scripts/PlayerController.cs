using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float turnSpeed;
    public int startHP;

    private Rigidbody rb;
    private int hp;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody> ();
        hp = startHP;
	}

    // player can only move forwards and backwards, horizontal input adds torque
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;

        float torque = horizontal * turnSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, torque, 0f);

        rb.MoveRotation(rb.rotation * rotation);
        rb.MovePosition(rb.position + movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Object.Destroy(other.gameObject);
            GameController.instance.CollectCoin();
        }
    }
}
