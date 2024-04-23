using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] float speed;

	Rigidbody2D rb;

	float time;
	[SerializeField] float moveChangeTime;

	Vector2 randomSpeed;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		randomSpeed.x = Random.Range(-1, 1);
		randomSpeed.y = Random.Range(-1, 1);

		randomSpeed = randomSpeed.normalized;
		var v = rb.velocity;

		v = randomSpeed * speed;

		rb.velocity = v;
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		time += Time.deltaTime;
		if(time >= moveChangeTime)
		{
			randomSpeed.x = Random.Range(-1, 1);
			randomSpeed.y = Random.Range(-1, 1);

			randomSpeed = randomSpeed.normalized;
			var v = rb.velocity;

			v = randomSpeed * speed;

			rb.velocity = v;
			time = 0;
		}
	}
}
