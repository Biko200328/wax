using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBullet : MonoBehaviour
{
	public float bulletSpeedPos;
	public float bulletSpeed;
	public float degree;

	public float deathTime;
	float timer;

	Rigidbody2D rb;

	GameObject playerObj;

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

		var pos = transform.position;

		pos += gameObject.transform.rotation * new Vector3(bulletSpeedPos, 0, 0);

		transform.position = pos;

		//var v = rb.velocity;

		////�����Ă�������Ɉړ�
		//v = gameObject.transform.rotation * new Vector3(bulletSpeed, 0, 0);

		//rb.velocity = v;

	}

	private void FixedUpdate()
	{
		timer += Time.deltaTime;
		if(timer >= deathTime)
		{
			//Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.transform.SetParent(this.gameObject.transform);
		}
	}
}
