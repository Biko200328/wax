using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerAttack : MonoBehaviour
{
	bool isAttack;
	float time;
	[Header("���̍U�����o��܂ł̎���")]
	[SerializeField] float coolTime = 0.2f;

	[Header("�U���͈̔�")]
	[SerializeField] Vector2 attackPos;

	[Header("�ړI�n�܂ł̎���")]
	[SerializeField] float attackTime;

	[Header("�o���")]
	[SerializeField] int attackNum;

	[Header("���E�̌����")]
	[SerializeField] float reduceNum;

	[SerializeField] GameObject attackObj;
	[SerializeField] GameObject baseObj;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetAxis("RT") != 0)
		{
			if(isAttack == false)
			{
				isAttack = true;

				for (int i = 0; i < attackNum; i++)
				{
					AttackObjMove objSqr = Instantiate(attackObj, transform.position, Quaternion.identity).GetComponent<AttackObjMove>();

					//���Obj�̈ʒu���烉���_���Ŕz�u����
					Vector2 romdomVec;
					romdomVec.x = baseObj.transform.position.x + Random.Range(-attackPos.x, attackPos.x);
					romdomVec.y = baseObj.transform.position.y + Random.Range(-attackPos.y, attackPos.y);

					objSqr.Attack(attackTime, transform.position, romdomVec);
				}
			}
		}
	}

	private void FixedUpdate()
	{
		if (isAttack)
		{
			time += Time.deltaTime;
			if (time >= coolTime)
			{
				isAttack = false;
				time = 0;
			}
		}
	}
}
