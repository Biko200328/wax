using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBullet : MonoBehaviour
{
	public float bulletSpeedPos;
	public float bulletSpeed;
	public float degree;

	public float deathTime;
	float timer;

	Rigidbody2D rb;

	GameObject playerObj;

	bool isCatch;

	GameObject catchedEnemy;
	EnemyMove enemyMoveSqr;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// transformを取得
		Transform myTransform = this.transform;

		// ワールド座標を基準に、回転を取得
		Vector3 worldAngle = myTransform.eulerAngles;

		//回転処理
		worldAngle.z = degree; // ワールド座標を基準に、z軸を軸にした回転をアナログスティックの角度に設定
		myTransform.eulerAngles = worldAngle; // 回転角度を設定

		var pos = transform.position;

		pos += gameObject.transform.rotation * new Vector3(bulletSpeedPos, 0, 0);

		transform.position = pos;

		//var v = rb.velocity;

		////向いている方向に移動
		//v = gameObject.transform.rotation * new Vector3(bulletSpeed, 0, 0);

		//rb.velocity = v;

	}

	private void FixedUpdate()
	{
		if(isCatch)
		{
			timer += Time.deltaTime;
			if (timer >= deathTime)
			{
				catchedEnemy.transform.SetParent(null);
				enemyMoveSqr.SetIsSutck(false);
				Destroy(this.gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			if(isCatch == false)
			{
				catchedEnemy = collision.gameObject;
				catchedEnemy.transform.SetParent(this.gameObject.transform);
				enemyMoveSqr = catchedEnemy.GetComponent<EnemyMove>();
				enemyMoveSqr.SetIsSutck(true);
				isCatch = true;
			}
		}
	}
}
