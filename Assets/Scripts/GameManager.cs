using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1280, 720, false);
		Application.targetFrameRate = 60;

		//// ��������
		//Cursor.lockState = wantedMode;

		//Cursor.lockState = wantedMode = CursorLockMode.Confined; //�͂ݏo���Ȃ����[�h
		//Cursor.visible = false; //OS�J�[�\����\��
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Escape))
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.None; //�W�����[�h
		//	Debug.Log("DEBUG:Cursor is normal");
		//	Cursor.visible = true; //OS�J�[�\���\��
		//	isPause = true;
		//}

		//if(!isPause)
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.Confined; //�͂ݏo���Ȃ����[�h
		//	Cursor.visible = false; //OS�J�[�\����\��
		//}

		//if(isPause)
		//{
		//	if(Input.GetMouseButton(0))
		//	{
		//		isPause = false;
		//	}
		//}

	}
}
