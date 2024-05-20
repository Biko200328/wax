using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wax : MonoBehaviour
{
	[SerializeField] float nowWax = 100;
	[SerializeField] float maxWax = 100;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//ゲージっぽく
		var scale = gameObject.transform.localScale;
		scale.x = nowWax / maxWax;
		gameObject.transform.localScale = scale;
	}

	public void ReduceWax(float num)
	{
		//指定した数値分減らす
		if (nowWax > 0)
		{
			nowWax -= num;
			//0以下にならないように
			if (nowWax <= 0)
			{
				nowWax = 0;
			}
		}
		//もともと0だった場合
		else
		{
			//無いですよって知らせる何か
		}
	}

	public void RecoveryWax(float num)
	{
		nowWax += num;
		if(nowWax >= maxWax)
		{
			nowWax = maxWax;
		}
	}

	/// <Summary>
	/// ロウを持っている場合はtrueを返します<br />
	/// 
	/// </Summary>
	public bool HaveWax()
	{
		if(nowWax > 0)
		{
			return true;
		}

		return false;
	}
}
