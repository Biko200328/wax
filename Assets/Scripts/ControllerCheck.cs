using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
	//�R���g���[���[���ڑ�����Ă��邩�̃t���O
	public bool isConnection = false;

	public static bool isConnectionPower;

	private void Awake()
	{
		isConnection = isConnectionPower;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.F1))
		{
			isConnection = !isConnection;
			isConnectionPower = isConnection;
		}
	}


	private void FixedUpdate()
	{
		//�R���g���[���[�ڑ��`�F�b�N
		isConnectController();
	}

	private void isConnectController()
	{
		//�R���g���[���[�̐ڑ��`�F�b�N
		//�ڑ�����Ă���R���g���[���[���(���O)�𓾂�
		string[] cName = Input.GetJoystickNames();
		//�ڑ���
		int currentConnectionCount = 0;
		//�ڑ�����Ă���R���g���[���[�̐����m�F
		for (int i = 0; i < cName.Length; i++)
		{
			//�󔒂̖��O�̏������O
			if (cName[i] != "")
			{
				//�ڑ�����1����
				currentConnectionCount++;
			}
		}

		//�ڑ�����1�ȏ�(�R���g���[���[���ڑ�����Ă���Ƃ�)
		if(isConnectionPower == false)
		{
			if (currentConnectionCount >= 1)
			{
				//�C�ӂ̃t���O��true��
				isConnection = true;
			}
			//�ڑ�����Ă��Ȃ��Ƃ�
			else
			{
				//false��
				isConnection = false;
			}
		}
	}
}
