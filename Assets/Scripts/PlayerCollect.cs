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

	SpriteRenderer spriteRenderer;
	Sprite box;
	[SerializeField] Sprite sptite;

	[SerializeField] SpriteRenderer gauge;

	PlayerAttack attackSqr;

	// Start is called before the first frame update
	void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		box = spriteRenderer.sprite;
		attackSqr = GetComponent<PlayerAttack>();
	}

	// Update is called once per frame
	void Update()
	{
		//�N�[���^�C�����ł͂Ȃ�,�U�����ł͂Ȃ�
		if(isCollect == false && attackSqr.GetisAttack() == false)
		{
			if(Input.GetAxis("LT") != 0)
			{
				//�͈͓��ɂ��郍�E��T��
				GameObject[] waxs = GameObject.FindGameObjectsWithTag("collectWax");

				if(waxs.Length >= 1)
				{
					isCollect = true;
					time = 0;
				}

				//���̃��E���������
				for (int i = 0; i < waxs.Length; i++) 
				{
					AttackObjMove attackObjSqr = waxs[i].GetComponent<AttackObjMove>();
					attackObjSqr.Collect(collectTime, transform.position, recoveryNum);
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

			//�X�v���C�g��ύX
			spriteRenderer.sprite = sptite;
			gauge.sprite = sptite;
			//��O�ɂȂ�悤��
			spriteRenderer.sortingOrder = 2;
			//�F��ύX
			spriteRenderer.color = Color.green;

			//������
			if(time >= collectTime)
			{
				//�X�v���C�g����
				spriteRenderer.sprite = box;
				gauge.sprite = box;
				spriteRenderer.sortingOrder = 0;
				spriteRenderer.color = Color.white;

				isCollect = false;
			}
		}
	}

	public bool GetIsCollect()
	{
		return isCollect;
	}
}
