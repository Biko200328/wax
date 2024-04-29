using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemyMove : MonoBehaviour
{
	GameObject playerObj;

	[Header("ˆÚ“®‘¬“x")]
	[SerializeField] float speed;

	[Header("x‚æ‚è‹ß‚¢‚È‚ç—£‚ê‚Ä y‚æ‚è‰“‚¢‚È‚ç‹ß‚Ã‚­")]
	[SerializeField] Vector2 magunitude;

	// Start is called before the first frame update
	void Start()
	{
		playerObj = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		var n = playerObj.transform.position - this.gameObject.transform.position;

		var n1 = n;
		n1 = n1.normalized;

		if (n.magnitude <= magunitude.x)
		{
			//—£‚ê‚é
			transform.position += -n1 * speed;

			transform.rotation = Quaternion.FromToRotation(Vector3.up, -n1);
		}

		if(n.magnitude >= magunitude.y)
		{
			//‹ß‚Ã‚­
			transform.position += n1 * speed;

			transform.rotation = Quaternion.FromToRotation(Vector3.up, n1);
		}

		if(n.magnitude < magunitude.y && n.magnitude > magunitude.x)
		{
			// ‘ÎÛ•¨‚Ö‰ñ“]‚·‚é
			transform.rotation = Quaternion.FromToRotation(Vector3.up, n);
		}
	}
}
