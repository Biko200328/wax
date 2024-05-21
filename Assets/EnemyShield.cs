using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
	public bool isDefence;
	[SerializeField] float defenceTime;
	float timer;

	// Start is called before the first frame update
	void Start()
	{

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
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "wax")
		{
			AttackObjMove attackObjMove = collision.GetComponent<AttackObjMove>();
			if(attackObjMove.isMove == true)
			{
				isDefence = true;
				timer = 0;
			}
		}
	}
}
