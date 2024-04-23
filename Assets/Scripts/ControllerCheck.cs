using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
	//コントローラーが接続されているかのフラグ
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
		//コントローラー接続チェック
		isConnectController();
	}

	private void isConnectController()
	{
		//コントローラーの接続チェック
		//接続されているコントローラー情報(名前)を得る
		string[] cName = Input.GetJoystickNames();
		//接続数
		int currentConnectionCount = 0;
		//接続されているコントローラーの数を確認
		for (int i = 0; i < cName.Length; i++)
		{
			//空白の名前の情報を除外
			if (cName[i] != "")
			{
				//接続数を1足す
				currentConnectionCount++;
			}
		}

		//接続数が1以上(コントローラーが接続されているとき)
		if(isConnectionPower == false)
		{
			if (currentConnectionCount >= 1)
			{
				//任意のフラグをtrueに
				isConnection = true;
			}
			//接続されていないとき
			else
			{
				//falseに
				isConnection = false;
			}
		}
	}
}
