using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
	bool isCollect;

	float time;

	[Header("回収にかかる間")]
	[SerializeField] float collectTime;

	[Header("回復量")]
	[SerializeField] float recoveryNum;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetAxis("LT") != 0)
		{
			if(isCollect == false)
			{
				//範囲内にいるロウを探す
				GameObject[] waxs = GameObject.FindGameObjectsWithTag("collectWax");

				if(waxs.Length >= 1)
				{
					isCollect = true;
				}

				//そのロウを回収する
				for (int i = 0; i < waxs.Length; i++) 
				{
					AttackObjMove attackObjSqr = waxs[i].GetComponent<AttackObjMove>();
					attackObjSqr.Collect(collectTime, transform.position,recoveryNum);
				}
			}
		}
	}

	private void FixedUpdate()
	{
		//回収のクールタイム
		if(isCollect)
		{
			time += Time.deltaTime;

			if(time >= collectTime)
			{
				isCollect = false;
				time = 0;
			}
		}
	}

	public bool GetIsCollect()
	{
		return isCollect;
	}
}
