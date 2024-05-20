using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
	Rigidbody2D rb;
	GameObject playerObj;
	Vector3 direction;
	public float speed;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		playerObj = GameObject.FindGameObjectWithTag("Player");

		direction =  playerObj.transform.position - transform.position;
		direction = direction.normalized;
	}

	// Update is called once per frame
	void Update()
	{
		var v = rb.velocity;
		v = direction * speed;
		rb.velocity = v;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Destroy(this.gameObject);
		}
	}
}
