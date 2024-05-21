using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxWallCheck : MonoBehaviour
{
	[SerializeField] AttackObjMove attackObjSqr;

	bool isWallCheck;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Wall")
		{
			attackObjSqr.SetisWall(true);
		}
		if (collision.gameObject.tag == "EnemyShield")
		{
			attackObjSqr.SetisWall(true);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Wall")
		{
			attackObjSqr.SetisWall(true);
		}
		if (collision.gameObject.tag == "EnemyShield")
		{
			attackObjSqr.SetisWall(true);
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Wall")
		{
			attackObjSqr.SetisWall(false);
		}
		if (collision.gameObject.tag == "EnemyShield")
		{
			attackObjSqr.SetisWall(false);
		}
	}
}
