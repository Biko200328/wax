using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBullet : MonoBehaviour
{
	public float bulletSpeed;
	public float degree;

	Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		// transform���擾
		Transform myTransform = this.transform;

		// ���[���h���W����ɁA��]���擾
		Vector3 worldAngle = myTransform.eulerAngles;

		//��]����
		worldAngle.z = degree; // ���[���h���W����ɁAz�������ɂ�����]���A�i���O�X�e�B�b�N�̊p�x�ɐݒ�
		myTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�

		var v = rb.velocity;

		//�����Ă�������Ɉړ�
		v = gameObject.transform.rotation * new Vector3(bulletSpeed, 0, 0);
		
		rb.velocity = v;
	}
}
