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
		//�Q�[�W���ۂ�
		var scale = gameObject.transform.localScale;
		scale.x = nowWax / maxWax;
		gameObject.transform.localScale = scale;
	}

	public void ReduceWax(float num)
	{
		//�w�肵�����l�����炷
		if (nowWax > 0)
		{
			nowWax -= num;
			//0�ȉ��ɂȂ�Ȃ��悤��
			if (nowWax <= 0)
			{
				nowWax = 0;
			}
		}
		//���Ƃ���0�������ꍇ
		else
		{
			//�����ł�����Ēm�点�鉽��
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
	/// ���E�������Ă���ꍇ��true��Ԃ��܂�<br />
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
