using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	CursorLockMode wantedMode = CursorLockMode.None;

	[SerializeField] AudioSource enemyExplosinSE;

	[SerializeField] AudioSource enemydeadSE;

	[SerializeField] AudioSource enemyHitSE;

	public bool isDead;
	public float SceneChangeTime = 3.0f;
	float SceneChangeTimer;
	public bool isStun;

	bool isPause;

	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1280, 720, false);
		Application.targetFrameRate = 60;

		// ��������
		Cursor.lockState = wantedMode;

		Cursor.lockState = wantedMode = CursorLockMode.Confined; //�͂ݏo���Ȃ����[�h
		Cursor.visible = false; //OS�J�[�\����\��
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.lockState = wantedMode = CursorLockMode.None; //�W�����[�h
			Debug.Log("DEBUG:Cursor is normal");
			Cursor.visible = true; //OS�J�[�\���\��
			isPause = true;
		}

		if(!isPause)
		{
			Cursor.lockState = wantedMode = CursorLockMode.Confined; //�͂ݏo���Ȃ����[�h
			Cursor.visible = false; //OS�J�[�\����\��
		}

		if(isPause)
		{
			if(Input.GetMouseButton(0))
			{
				isPause = false;
			}
		}

		//if (Input.GetKeyDown(KeyCode.F2))
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.Confined; //�͂ݏo���Ȃ����[�h
		//	Debug.Log("DEBUG:Cursor is confined");
		//	Cursor.visible = false; //OS�J�[�\����\��
		//}
		//if (Input.GetKeyDown(KeyCode.F3))
		//{
		//	Cursor.lockState = wantedMode = CursorLockMode.Locked; //�����Ȃ���
		//	Debug.Log("DEBUG:Cursor is locked");
		//	Cursor.visible = false; //OS�J�[�\����\��
		//}

		if(isDead)
		{
			SceneChangeTimer += Time.deltaTime;
			if(SceneChangeTimer >= SceneChangeTime)
			{
				SceneController sceneController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneController>();
				sceneController.sceneChange("ResultScene");
			}
		}
	}

	public void PlayExplosion()
	{
		enemyExplosinSE.Play();
	}

	public void PlayEnemyDead()
	{
		enemydeadSE.Play();
	}

	public void PlayEnemyHit()
	{
		enemyHitSE.Play();
	}
}
