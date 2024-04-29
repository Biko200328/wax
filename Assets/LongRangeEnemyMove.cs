using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemyMove : MonoBehaviour
{
	GameObject playerObj;

	[Header("移動速度")]
	[SerializeField] float speed;

	[Header("xより近いなら離れて yより遠いなら近づく")]
	[SerializeField] Vector2 magnitude;

	//indicator
	[SerializeField] GameObject indicator;
	GameObject canvas;
	[HideInInspector] public GameObject TIObj;

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
		var n = playerObj.transform.position - this.gameObject.transform.position;

		var n1 = n;
		n1 = n1.normalized;

		if (n.magnitude <= magnitude.x)
		{
			//離れる
			transform.position += -n1 * speed;

			transform.rotation = Quaternion.FromToRotation(Vector3.up, -n1);
		}

		if(n.magnitude >= magnitude.y)
		{
			//近づく
			transform.position += n1 * speed;

			transform.rotation = Quaternion.FromToRotation(Vector3.up, n1);
		}

		if(n.magnitude < magnitude.y && n.magnitude > magnitude.x)
		{
			// 対象物へ回転する
			transform.rotation = Quaternion.FromToRotation(Vector3.up, n);
		}
	}
}
