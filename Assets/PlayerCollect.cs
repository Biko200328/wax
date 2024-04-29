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
		//クールタイム中ではない,攻撃中ではない
		if(isCollect == false && attackSqr.GetisAttack() == false)
		{
			if(Input.GetAxis("LT") != 0)
			{
				//範囲内にいるロウを探す
				GameObject[] waxs = GameObject.FindGameObjectsWithTag("collectWax");

				if(waxs.Length >= 1)
				{
					isCollect = true;
					time = 0;
				}

				//そのロウを回収する
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
		//回収のクールタイム
		if(isCollect)
		{
			time += Time.deltaTime;

			//スプライトを変更
			spriteRenderer.sprite = sptite;
			gauge.sprite = sptite;
			//手前になるように
			spriteRenderer.sortingOrder = 2;
			//色を変更
			spriteRenderer.color = Color.green;

			//初期化
			if(time >= collectTime)
			{
				//スプライト周り
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
