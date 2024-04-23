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
		if (isMove)
		{
			time += Time.deltaTime;
			transform.position = QuartOut(time, totalTime, minPos, movedPos);

			if (time >= totalTime)
			{
				isMove = false;
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
}
