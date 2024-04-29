using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndManager : MonoBehaviour
{
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
		if(collision.gameObject.tag == "LongRangeEnemy")
		{
			LongRangeEnemyMove enemySqr = collision.GetComponent<LongRangeEnemyMove>();
			enemySqr.TIObj.SetActive(false);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "LongRangeEnemy")
		{
			LongRangeEnemyMove enemySqr = collision.GetComponent<LongRangeEnemyMove>();
			enemySqr.TIObj.SetActive(false);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "LongRangeEnemy")
		{
			LongRangeEnemyMove enemySqr = collision.GetComponent<LongRangeEnemyMove>();
			enemySqr.TIObj.SetActive(true);
		}
	}
}
