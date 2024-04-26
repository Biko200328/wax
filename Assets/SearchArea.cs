using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchArea : MonoBehaviour
{
	[SerializeField] EnemyMove enemyMove;

	[SerializeField] EnemyHp hpSqr;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(hpSqr != null)
		{
			if (hpSqr.GetIsDead())
			{
				Destroy(this.gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag =="Player")
		{
			enemyMove.SetIsLook(true);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			enemyMove.SetIsLook(false);
		}
	}
}
