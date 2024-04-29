using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjMove : MonoBehaviour
{
	Vector2 minPos;
	Vector2 movedPos;

	float totalTime;
	float time;

	bool isMove;

	bool isCollect;

	float recoveryNum;

	[SerializeField] bool isWall;

	GameObject playerObj;

	Vector3 toDirection;

	public bool isBeforeEnemy;	

	// Start is called before the first frame update
	void Start()
	{
		playerObj = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
	{
		if (isBeforeEnemy == false)
		{
			// 対象物へのベクトルを算出
			toDirection = playerObj.transform.position - transform.position;
			// 対象物へ回転する
			transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
		}
	}

	private void FixedUpdate()
	{
		if(isWall == false)
		{
			//発射
			if (isMove)
			{
				time += Time.deltaTime;

				//指定された位置まで移動
				transform.position = MyEasing.QuartOut(time, totalTime, minPos, movedPos);

				//初期化
				if (time >= totalTime)
				{
					isMove = false;
					time = 0;
				}
			}

			//回収
			if (isCollect)
			{
				time += Time.deltaTime;

				//指定された位置まで移動
				transform.position = MyEasing.QuartOut(time, totalTime, minPos, playerObj.transform.position);

				//初期化
				if (time >= totalTime)
				{
					isCollect = false;
					time = 0;
					Wax waxSqr = GameObject.Find("Gauge").GetComponent<Wax>();
					waxSqr.RecoveryWax(recoveryNum);
					Destroy(this.gameObject);
				}
			}
		}
		else
		{
			time = 0;
			isMove = false;
			isCollect = false;
		}
	}

	public void Attack(float t, Vector2 nowPos, Vector2 maxPos)
	{
		isMove = true;
		totalTime = t;
		minPos = nowPos;
		movedPos = maxPos;
	}

	public void Collect(float t, Vector2 maxPos,float num)
	{
		isCollect = true;
		totalTime = t;
		minPos = transform.position;
		movedPos = maxPos;
		recoveryNum = num;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(isMove)
		{
			if(collision.gameObject.tag == "Enemy")
			{
				EnemyHp enemyHp = collision.transform.GetChild(1).gameObject.GetComponent<EnemyHp>();
				enemyHp.Damage(1.0f);
			}

			if(collision.gameObject.tag == "Wall")
			{
				isMove = false;
				time = 0;
			}
		}
	}

	public void SetisWall(bool flag)
	{
		isWall = flag;
	}
}
