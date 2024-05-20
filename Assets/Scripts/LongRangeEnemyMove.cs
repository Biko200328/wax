using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemyMove : MonoBehaviour
{
	GameObject playerObj;

	[Header("ˆÚ“®‘¬“x")]
	[SerializeField] float speed;

	[Header("’e‚Ì‘¬“x")]
	[SerializeField] float bulletSpeed;

	[Header("”­ŽËŠÔŠu")]
	[SerializeField] float interval;
	float timer;

	[Header("x‚æ‚è‹ß‚¢‚È‚ç—£‚ê‚Ä y‚æ‚è‰“‚¢‚È‚ç‹ß‚Ã‚­")]
	[SerializeField] Vector2 magnitude;

	public GameObject bulletObj;

	//indicator
	[SerializeField] GameObject indicator;
	GameObject canvas;
	[HideInInspector] public GameObject TIObj;

	[SerializeField] EnemyHp hpSqr;

	// Start is called before the first frame update
	void Start()
	{
		playerObj = GameObject.FindGameObjectWithTag("Player");

		//indicator
		canvas = GameObject.FindGameObjectWithTag("UICanvas");
		TIObj = Instantiate(indicator, transform.position, Quaternion.identity);
		TargetIndicator TISqr = TIObj.GetComponent<TargetIndicator>();
		TISqr.target = this.gameObject;
		TIObj.transform.SetParent(canvas.transform, false);
	}

	// Update is called once per frame
	void Update()
	{
		if(hpSqr.GetIsDead() == false)
		{
			var n = playerObj.transform.position - this.gameObject.transform.position;

			var n1 = n;
			n1 = n1.normalized;

			if (n.magnitude <= magnitude.x)
			{
				//—£‚ê‚é
				transform.position += -n1 * speed;

				transform.rotation = Quaternion.FromToRotation(Vector3.up, -n1);

				timer = 0;
			}

			if (n.magnitude >= magnitude.y)
			{
				//‹ß‚Ã‚­
				transform.position += n1 * speed;

				transform.rotation = Quaternion.FromToRotation(Vector3.up, n1);

				timer = 0;
			}

			if (n.magnitude < magnitude.y && n.magnitude > magnitude.x)
			{
				// ‘ÎÛ•¨‚Ö‰ñ“]‚·‚é
				transform.rotation = Quaternion.FromToRotation(Vector3.up, n);

				timer++;

				if(timer >= interval)
				{
					enemyBullet bulletSqr = Instantiate(bulletObj, transform.position, Quaternion.identity).GetComponent<enemyBullet>();
					bulletSqr.speed = bulletSpeed;

					timer = 0;
				}
			}
		}
	}
}
