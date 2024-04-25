using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class StickAttack : MonoBehaviour
{
	[SerializeField] GameObject bullet;

	PlayerMove moveSqr;

	[SerializeField] float bulletDeleteTime;
	[SerializeField] float bulletSpeed;

	// Start is called before the first frame update
	void Start()
	{
		moveSqr = GetComponent<PlayerMove>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown("buttonR"))
		{
			StickBullet bulletSqr = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<StickBullet>();
			bulletSqr.bulletSpeed = bulletSpeed;
			bulletSqr.degree = moveSqr.degree;
			bulletSqr.deathTime = bulletDeleteTime;
		}
	}
}
