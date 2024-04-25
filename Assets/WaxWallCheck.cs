using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxWallCheck : MonoBehaviour
{
	[SerializeField] AttackObjMove attackObjSqr;
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
			attackObjSqr.SetIsWall(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Wall")
		{
			attackObjSqr.SetIsWall(false);
		}
	}
}
