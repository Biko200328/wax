using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float speed;

	[SerializeField] Rigidbody2D rb;

	float keepDegree;

	[SerializeField] PlayerCollect playerCollectSqr;

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
		var vl2 = Input.GetAxis("cVerticalL");
		var hl2 = Input.GetAxis("cHorizontalL");

		//左のアナログスティックが倒れている角度を求める
		var vr2 = Input.GetAxis("cVerticalR");
		var hr2 = Input.GetAxis("cHorizontalR");

		var degree = Mathf.Atan2(vr2, hr2) * Mathf.Rad2Deg;

		if (degree < 0)
		{
			degree += 360;
		}

		if (vr2 == 0 && hr2 == 0)
		{
			degree = keepDegree;
		}
		else if (vr2 >= 0.1f || vr2 <= -0.1f || hr2 >= 0.1f || hr2 <= -0.1f)
		{
			keepDegree = degree;
		}

		v.y = vl2 * speed;
		v.x = hl2 * speed;

		//回収中は動けない
		if(playerCollectSqr.GetIsCollect() == false)
		{
			rb.velocity = v;
		}

		// transformを取得
		Transform myTransform = this.transform;

		// ワールド座標を基準に、回転を取得
		Vector3 worldAngle = myTransform.eulerAngles;

		//回転処理
		worldAngle.z = degree; // ワールド座標を基準に、z軸を軸にした回転をアナログスティックの角度に設定
		myTransform.eulerAngles = worldAngle; // 回転角度を設定
	}
}
