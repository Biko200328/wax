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

		//// 初期動作
		//Cursor.lockState = wantedMode;

		//Cursor.lockState = wantedMode = CursorLockMode.Confined; //はみ出さないモード
		//Cursor.visible = false; //OSカーソル非表示
	}

	// Update is called once per frame
	void Update()
	{
		//if (Input.GetKeyDown(KeyCode.Escape))
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.None; //標準モード
		//	Debug.Log("DEBUG:Cursor is normal");
		//	Cursor.visible = true; //OSカーソル表示
		//	isPause = true;
		//}

		//if(!isPause)
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.Confined; //はみ出さないモード
		//	Cursor.visible = false; //OSカーソル非表示
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
