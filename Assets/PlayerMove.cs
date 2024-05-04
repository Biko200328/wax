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

		//���̃A�i���O�X�e�B�b�N���|��Ă���p�x�����߂�
		vl = Input.GetAxis("cVerticalL");
		hl = Input.GetAxis("cHorizontalL");

		//���̃A�i���O�X�e�B�b�N���|��Ă���p�x�����߂�
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

		//������͓����Ȃ�
		if (playerCollectSqr.GetIsCollect() == false)
		{
			rb.velocity = v;
		}

		// transform���擾
		Transform myTransform = this.transform;

		// ���[���h���W����ɁA��]���擾
		Vector3 worldAngle = myTransform.eulerAngles;

		//��]����
		worldAngle.z = degree; // ���[���h���W����ɁAz�������ɂ�����]���A�i���O�X�e�B�b�N�̊p�x�ɐݒ�
		myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
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
