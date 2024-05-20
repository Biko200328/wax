using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
	[SerializeField] float maxHp;
	[SerializeField] float nowHp;

	public bool isDead;

	[SerializeField] bool isDamage;

	public float timer;
	[SerializeField] float mutekiTime;

	[SerializeField] BoxCollider2D coll;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//�Q�[�W���ۂ�
		var scale = gameObject.transform.localScale;
		scale.y = 1 - nowHp / maxHp;
		gameObject.transform.localScale = scale;
	}

	private void FixedUpdate()
	{
		if (isDamage)
		{
			timer += Time.deltaTime;
			if (timer >= mutekiTime)
			{
				isDamage = false;
			}
		}
	}

	public void Damage(float num)
	{
		if(isDead == false)
		{
			if (isDamage == false)
			{
				isDamage = true;
				nowHp -= num;
				timer = 0;

				if (nowHp <= 0)
				{
					nowHp = 0;
					isDead = true;
					//�^�O��ύX �z�������悤��
					transform.root.gameObject.tag = "wax";

					//���E�̃X�N���v�g��e�ɒǉ�
					AttackObjMove Sqr = transform.root.gameObject.AddComponent<AttackObjMove>();
					Sqr.isBeforeEnemy = true;

					//�R���C�_�[���g���K�[��
					coll.isTrigger = true;
				}
			}
		}
	}

	public bool GetIsDead()
	{
		return isDead;
	}
}
