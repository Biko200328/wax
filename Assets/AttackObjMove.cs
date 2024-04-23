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
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		//発射
		if (isMove)
		{
			time += Time.deltaTime;

			//指定された位置まで移動
			transform.position = QuartOut(time, totalTime, minPos, movedPos);

			//初期化
			if (time >= totalTime)
			{
				isMove = false;
				time = 0;
			}
		}

		//回収
		if(isCollect)
		{
			time += Time.deltaTime;

			//指定された位置まで移動
			transform.position = QuartOut(time, totalTime, minPos, movedPos);

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

	public static Vector2 QuartOut(float t, float totaltime, Vector2 min, Vector2 max)
	{
		max -= min;
		t = t / totaltime - 1;
		return -max * (t * t * t * t - 1) + min;
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
}
