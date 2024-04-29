using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemyMove : MonoBehaviour
{
	GameObject playerObj;

	[Header("�ړ����x")]
	[SerializeField] float speed;

	[Header("x���߂��Ȃ痣��� y��艓���Ȃ�߂Â�")]
	[SerializeField] Vector2 magnitude;

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

		if (n.magnitude <= magnitude.x)
		{
			//�����
			transform.position += -n1 * speed;

			transform.rotation = Quaternion.FromToRotation(Vector3.up, -n1);
		}

		if(n.magnitude >= magnitude.y)
		{
			//�߂Â�
			transform.position += n1 * speed;

			transform.rotation = Quaternion.FromToRotation(Vector3.up, n1);
		}

		if(n.magnitude < magnitude.y && n.magnitude > magnitude.x)
		{
			// �Ώە��։�]����
			transform.rotation = Quaternion.FromToRotation(Vector3.up, n);
		}
	}
}
