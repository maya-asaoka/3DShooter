using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// In-game enemy that follows and shoots at player

public class EnemyController : MonoBehaviour {

    public GameObject player;
    public GameObject coinPrefab;
    public GameObject enemyBulletPrefab;

    public int hp;

    public float fireRate;
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

    private Vector3 raiseCoin = new Vector3(0, 0.7f, 0);
    private Vector3 raiseBullet = new Vector3(0, 1f, 0);

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody> ();
        InvokeRepeating("FireAtPlayer", 2.0f, fireRate);
	}

    void FireAtPlayer()
    {
        Instantiate(enemyBulletPrefab, transform.position + raiseBullet, transform.rotation);
    }


    // rotate towards player then move
    private void FixedUpdate()
    {
        Vector3 towardsPlayer = player.gameObject.transform.position - transform.position;
        // length of radian is 0.0f
        Vector3 direction = Vector3.RotateTowards(transform.forward, towardsPlayer, turnSpeed * Time.deltaTime, 0.0f);
        rb.MoveRotation(Quaternion.LookRotation(direction));

        Vector3 moveTowardsPlayer = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, speed * Time.deltaTime);
        rb.MovePosition(moveTowardsPlayer);
    }

    // killed enemies leave a coin in their place
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            hp--;
            if (hp == 0)
            {
                Instantiate(coinPrefab, transform.position + raiseCoin, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

}
