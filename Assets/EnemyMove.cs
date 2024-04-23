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

	[SerializeField] EnemyHp enemyHp;

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
		if (enemyHp.GetIsDead() == false) 
		{
			time += Time.deltaTime;

			if (time >= moveChangeTime)
			{
				//�x�N�g�����쐬
				randomSpeed.x = Random.Range(-1, 1);
				randomSpeed.y = Random.Range(-1, 1);

				randomSpeed = randomSpeed.normalized;


				var v = rb.velocity;

				//�쐬�����x�N�g���ɃX�s�[�h�������Ĉړ�������
				v = randomSpeed * speed;

				rb.velocity = v;
				time = 0;
			}
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
		
	}
}
