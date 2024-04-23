using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float speed;

	[SerializeField] Rigidbody2D rb;

	float keepDegree;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		rb.velocity = Vector2.zero;

		var v = rb.velocity;

		if(Input.GetKey(KeyCode.A))
		{
			v.x = -speed;
		}
		if (Input.GetKey(KeyCode.D))
		{
			v.x = speed;
		}
		if (Input.GetKey(KeyCode.W))
		{
			v.y = speed;
		}
		if (Input.GetKey(KeyCode.S))
		{
			v.y = -speed;
		}

		//左のアナログスティックが倒れている角度を求める
		var v2 = Input.GetAxis("cVerticalL");
		var h2 = Input.GetAxis("cHorizontalL");

		var degree = Mathf.Atan2(v2, h2) * Mathf.Rad2Deg;

		if (degree < 0)
		{
			degree += 360;
		}

		if (v2 == 0 && h2 == 0)
		{
			degree = keepDegree;
		}
		else if (v2 >= 0.1f || v2 <= -0.1f || h2 >= 0.1f || h2 <= -0.1f)
		{
			keepDegree = degree;
		}

		v.y = v2 * speed;
		v.x = h2 * speed;

		rb.velocity = v;

		// transformを取得
		Transform myTransform = this.transform;

		// ワールド座標を基準に、回転を取得
		Vector3 worldAngle = myTransform.eulerAngles;

		//回転処理
		worldAngle.z = degree; // ワールド座標を基準に、z軸を軸にした回転をアナログスティックの角度に設定
		myTransform.eulerAngles = worldAngle; // 回転角度を設定
	}
}
