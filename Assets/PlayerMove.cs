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

		//���̃A�i���O�X�e�B�b�N���|��Ă���p�x�����߂�
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

		// transform���擾
		Transform myTransform = this.transform;

		// ���[���h���W����ɁA��]���擾
		Vector3 worldAngle = myTransform.eulerAngles;

		//��]����
		worldAngle.z = degree; // ���[���h���W����ɁAz�������ɂ�����]���A�i���O�X�e�B�b�N�̊p�x�ɐݒ�
		myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�
	}
}
