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
			// 対象物へのベクトルを算出
			toDirection = playerObj.transform.position - transform.position;
			// 対象物へ回転する
			transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
		}
		
	}

	private void FixedUpdate()
	{

		if (enemyHp.GetIsDead() == false)
		{
			//プレイヤー発見時は追跡する
			if (isLookPlayer)
			{
				transform.position += toDirection.normalized * lookSpeed;
			}
			//プレイヤー未発見時はランダムに動かす
			else
			{
				time += Time.deltaTime;

				if (time >= moveChangeTime)
				{
					//ベクトルを作成
					randomSpeed.x = Random.Range(-1, 1);
					randomSpeed.y = Random.Range(-1, 1);

					randomSpeed = randomSpeed.normalized;

					transform.rotation = Quaternion.FromToRotation(Vector3.up, randomSpeed);

					var v = rb.velocity;

					//作成したベクトルにスピードをかけて移動させる
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
