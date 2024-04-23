using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] float normalSpeed;
	[SerializeField] float lookSpeed;

	Rigidbody2D rb;

	public bool isLookPlayer;

	float time;
	[SerializeField] float moveChangeTime;

	Vector2 randomSpeed;

	[SerializeField] EnemyHp enemyHp;

	[SerializeField] GameObject playerObj;

	Vector3 toDirection;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		randomSpeed.x = Random.Range(-1, 1);
		randomSpeed.y = Random.Range(-1, 1);

		randomSpeed = randomSpeed.normalized;
		var v = rb.velocity;

		v = randomSpeed * normalSpeed;

		rb.velocity = v;

		playerObj = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
	{
		if(isLookPlayer)
		{
			// �Ώە��ւ̃x�N�g�����Z�o
			toDirection = playerObj.transform.position - transform.position;
			// �Ώە��։�]����
			transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
		}
		
	}

	private void FixedUpdate()
	{

		if (enemyHp.GetIsDead() == false)
		{
			//�v���C���[�������͒ǐՂ���
			if (isLookPlayer)
			{
				transform.position += toDirection.normalized * lookSpeed;
			}
			//�v���C���[���������̓����_���ɓ�����
			else
			{
				time += Time.deltaTime;

				if (time >= moveChangeTime)
				{
					//�x�N�g�����쐬
					randomSpeed.x = Random.Range(-1, 1);
					randomSpeed.y = Random.Range(-1, 1);

					randomSpeed = randomSpeed.normalized;

					transform.rotation = Quaternion.FromToRotation(Vector3.up, randomSpeed);

					var v = rb.velocity;

					//�쐬�����x�N�g���ɃX�s�[�h�������Ĉړ�������
					v = randomSpeed * normalSpeed;

					rb.velocity = v;
					time = 0;
				}
			}
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
		
	}

	public void SetIsLook(bool flag)
	{
		isLookPlayer = flag;
	}
}
