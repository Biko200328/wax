using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
	public bool isDefence;
	[SerializeField] float defenceTime;
	public float timer;

	[SerializeField] float maxHp;
	[SerializeField] float nowHp;

	bool isDamage;
	[SerializeField] float damageTime;
	float damageTimer;

	// Start is called before the first frame update
	void Start()
	{
		nowHp = maxHp;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void FixedUpdate()
	{
		if(isDefence)
		{
			timer++;
			if(timer >= defenceTime)
			{
				isDefence = false;
			}
		}

		if(isDamage)
		{
			damageTimer++;
			if(damageTimer >= damageTime)
			{
				isDamage = false;
				damageTimer = 0;
			}
		}
	}

	public void Damage()
	{
		if(isDamage == false)
		{
			nowHp--;
			isDamage = true;
			if (nowHp <= 0)
			{
				isDefence = false;
				Destroy(this.gameObject);
			}
		}
	}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if(collision.gameObject.tag == "wax")
	//	{
	//		AttackObjMove attackObjMove = collision.GetComponent<AttackObjMove>();
	//		if(attackObjMove.isMove == true)
	//		{
	//			isDefence = true;
	//			timer = 0;
	//		}
	//	}
	//}
}
