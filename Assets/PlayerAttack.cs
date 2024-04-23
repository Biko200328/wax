using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerAttack : MonoBehaviour
{
	bool isAttack;
	float time;
	[Header("次の攻撃が出るまでの時間")]
	[SerializeField] float coolTime = 0.2f;

	[Header("攻撃の範囲")]
	[SerializeField] Vector2 attackPos;

	[Header("目的地までの時間")]
	[SerializeField] float attackTime;

	[Header("出る個数")]
	[SerializeField] int attackNum;

	[Header("ロウの減る量")]
	[SerializeField] float reduceNum;

	[Space(50)]
	[SerializeField] GameObject attackObj;
	[SerializeField] GameObject baseObj;
	[SerializeField] Wax waxSqr;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//RTを押したとき
		if(Input.GetAxis("RT") != 0)
		{
			//攻撃できる状態か(クールタイム外),ロウがまだあるか
			if(isAttack == false && waxSqr.HaveWax())
			{
				//クールタイム突入
				isAttack = true;

				//ロウを減らす
				waxSqr.ReduceWax(reduceNum);

				//指定した数値分ロウを生成
				for (int i = 0; i < attackNum; i++)
				{
					AttackObjMove objSqr = Instantiate(attackObj, transform.position, Quaternion.identity).GetComponent<AttackObjMove>();

					//基準のObjの位置からランダムで配置する
					Vector2 romdomVec;
					romdomVec.x = baseObj.transform.position.x + Random.Range(-attackPos.x, attackPos.x);
					romdomVec.y = baseObj.transform.position.y + Random.Range(-attackPos.y, attackPos.y);

					//動かすための数値を代入
					objSqr.Attack(attackTime, transform.position, romdomVec);
				}
			}
		}
	}

	private void FixedUpdate()
	{
		//クールタイムの計算
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
