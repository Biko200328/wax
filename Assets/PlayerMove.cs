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

		//���̃A�i���O�X�e�B�b�N���|��Ă���p�x�����߂�
		var vl2 = Input.GetAxis("cVerticalL");
		var hl2 = Input.GetAxis("cHorizontalL");

		//���̃A�i���O�X�e�B�b�N���|��Ă���p�x�����߂�
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

		//������͓����Ȃ�
		if(playerCollectSqr.GetIsCollect() == false)
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
}
