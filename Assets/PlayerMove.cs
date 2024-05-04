using AIE2D;
using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float speed;

	[SerializeField] Rigidbody2D rb;

	float keepDegree;

	[SerializeField] PlayerCollect playerCollectSqr;

	float vl;
	float hl;

	public float degree;

	bool isDodge;
	[SerializeField] float dodgeTime;
	[SerializeField] float dodgePower;
	[SerializeField] bool isConsume;
	[SerializeField] float consumeNum;
	[SerializeField] float createTime;
	[SerializeField] GameObject waxObj;
	[SerializeField] Wax wax;
	float createTimer;
	float dTimer;
	Vector2 nowPos;
	Vector2 n;

	StaticAfterImageEffect2DPlayer afterImage;

	

	// Start is called before the first frame update
	void Start()
	{
		afterImage = GetComponent<StaticAfterImageEffect2DPlayer>();
		afterImage.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		rb.velocity = Vector2.zero;

		var v = rb.velocity;

		if (Input.GetKey(KeyCode.A))
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
		vl = Input.GetAxis("cVerticalL");
		hl = Input.GetAxis("cHorizontalL");

		//左のアナログスティックが倒れている角度を求める
		var vr = Input.GetAxis("cVerticalR");
		var hr = Input.GetAxis("cHorizontalR");

		degree = Mathf.Atan2(vr, hr) * Mathf.Rad2Deg;

		if (degree < 0)
		{
			degree += 360;
		}

		if (vr == 0 && hr == 0)
		{
			degree = keepDegree;
		}
		else if (vr >= 0.1f || vr <= -0.1f || hr >= 0.1f || hr <= -0.1f)
		{
			keepDegree = degree;
		}

		v.y = vl * speed;
		v.x = hl * speed;

		if (Input.GetButtonDown("buttonL"))
		{
			if (isDodge == false && playerCollectSqr.GetIsCollect() == false && wax.HaveWax() == true)
			{
				isDodge = true;
				dTimer = 0;
				nowPos = transform.position;
				n = new Vector2(hl, vl);
				n = n.normalized;
				afterImage.SetActive(true);
			}
		}

		//回収中は動けない
		if (playerCollectSqr.GetIsCollect() == false)
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

	private void FixedUpdate()
	{
		if (isDodge)
		{
			dTimer += Time.deltaTime;

			transform.position = MyEasing.QuartOut(dTimer, dodgeTime, nowPos, nowPos + (n * dodgePower));

			if (dTimer >= dodgeTime)
			{
				isDodge = false;
				dTimer = 0;
				afterImage.SetActive(false);
			}

			if(isConsume == true)
			{
				createTimer++;
				if (createTimer >= createTime)
				{
					Instantiate(waxObj, transform.position, Quaternion.identity);
					wax.ReduceWax(consumeNum);
					createTimer = 0;
				}
			}
		}
	}

	public bool GetIsDodge()
	{
		return isDodge;
	}
}
