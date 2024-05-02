using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] float normalSpeed;
	[SerializeField] float lookSpeed;

	Rigidbody2D rb;

	public bool isLookPlayer;

	float time;
	[SerializeField] float moveChangeTime;

	Vector2 randomSpeed;

	[SerializeField] EnemyHp enemyHp;

	[SerializeField] GameObject playerObj;

	Vector3 toDirection;

	bool isChase;
	[SerializeField] float magnitude = 2.0f;
	[SerializeField] float lookTotalTime = 1.0f;
	float lookTimer;

	[SerializeField] GameObject bikkuri;
	GameObject mark;

	//indicator
	[SerializeField] GameObject indicator;
	GameObject canvas;
	[HideInInspector]public GameObject TIObj;

	EnemyAttack attackSqr;
	[SerializeField] float attackTime;
    float attackTimer;

    // Start is called before the first frame update
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();

		randomSpeed.x = Random.Range(-1, 1);
		randomSpeed.y = Random.Range(-1, 1);

		randomSpeed = randomSpeed.normalized;
		var v = rb.velocity;

		v = randomSpeed * normalSpeed;

		rb.velocity = v;

		playerObj = GameObject.Find("Player");

		attackSqr = GetComponent<EnemyAttack>();


		//indicator
		canvas = GameObject.FindGameObjectWithTag("UICanvas");
		TIObj = Instantiate(indicator, transform.position, Quaternion.identity);
		TargetIndicator TISqr = TIObj.GetComponent<TargetIndicator>();
		TISqr.target = this.gameObject;
		TIObj.transform.SetParent(canvas.transform, false);
	}

	// Update is called once per frame
	void Update()
	{
		if (enemyHp.GetIsDead() == false)
		{
			if (isLookPlayer)
			{
				// �Ώە��ւ̃x�N�g�����Z�o
				toDirection = playerObj.transform.position - transform.position;
				// �Ώە��։�]����
				transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
			}
		}

		if(enemyHp.GetIsDead() == true)
		{
			if (mark != null)
			{
				Destroy(mark);
			}
		}
	}

	private void FixedUpdate()
	{
		if (enemyHp.GetIsDead() == false)
		{
			//�v���C���[�������͒ǐՂ���
			if (isLookPlayer)
			{
				lookTimer += Time.deltaTime;

				if(lookTimer >= lookTotalTime)
				{
					isChase = true;
					Destroy(mark);
				}

				if(isChase)
				{
					if(toDirection.magnitude >= magnitude)
					{
						transform.position += toDirection.normalized * lookSpeed;
					}
					else
					{
						if(attackSqr.GetIsShake() == false)
						{
                            //timer��i�܂��Ĉ������ōU������悤��
                            attackTimer += Time.deltaTime;

                            if (attackTimer >= attackTime)
                            {
                                attackSqr.Attack();
								attackTimer = 0;
                            }
                        }
					}
				}
			}
			//�v���C���[���������̓����_���ɓ�����
			else
			{
				time += Time.deltaTime;

				if (time >= moveChangeTime)
				{
					//�x�N�g�����쐬
					randomSpeed.x = Random.Range(-1, 1);
					randomSpeed.y = Random.Range(-1, 1);

					randomSpeed = randomSpeed.normalized;

					transform.rotation = Quaternion.FromToRotation(Vector3.up, randomSpeed);

					var v = rb.velocity;

					//�쐬�����x�N�g���ɃX�s�[�h�������Ĉړ�������
					v = randomSpeed * normalSpeed;

					rb.velocity = v;
					time = 0;
				}
			}
		}
		else
		{
			rb.velocity = Vector2.zero;
		}
	}

	public void SetIsLook(bool flag)
	{
		if(enemyHp.GetIsDead() == false)
		{
			isLookPlayer = flag;

			//��������
			if (flag)
			{
				//�������Ƃ߂�
				rb.velocity = Vector2.zero;
				//�����!�}�[�N�𐶐�
				mark = Instantiate(bikkuri, transform.position, Quaternion.identity);
				mark.transform.position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
			}

			//���Z�b�g��������
			if (flag == false)
			{
				lookTimer = 0;
				isChase = false;
				if (mark != null)
				{
					Destroy(mark);
				}
			}
		}
		else
		{
			isLookPlayer = false;
		}
	}
}
