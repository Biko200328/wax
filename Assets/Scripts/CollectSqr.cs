using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSqr : MonoBehaviour
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
		if(collision.gameObject.tag == "wax")
		{
			collision.gameObject.tag = "collectWax";
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "wax")
		{
			collision.gameObject.tag = "collectWax";
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "collectWax")
		{
			collision.gameObject.tag = "wax";
		}
	}
}
