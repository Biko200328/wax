using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
	bool isCollect;

	float time;

	[Header("����ɂ������")]
	[SerializeField] float collectTime;

	[Header("�񕜗�")]
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
				//�͈͓��ɂ��郍�E��T��
				GameObject[] waxs = GameObject.FindGameObjectsWithTag("collectWax");

				if(waxs.Length >= 1)
				{
					isCollect = true;
				}

				//���̃��E���������
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
		//����̃N�[���^�C��
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
