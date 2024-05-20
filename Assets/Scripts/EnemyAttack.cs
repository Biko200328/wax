using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] bool isShake;
	[SerializeField] bool isAttack;

	float shakeTimer;
	[SerializeField] float shakeTime;

	float timer;
	[SerializeField] float totalTime;

	GameObject playerObj;

	Vector2 nowPos;
	Vector2 playerPos;

	Vector3 scale;

	[SerializeField] GameObject sword;

    [SerializeField] EnemyHp enemyHp;

    // Start is called before the first frame update
    void Start()
	{
		playerObj = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
		if(enemyHp.GetIsDead() == false)
		{
            if (isShake == false && isAttack == false)
            {
                sword.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 140);
            }

            if (isShake)
            {
                shakeTimer += Time.deltaTime;

                var angle = sword.transform.eulerAngles;
                angle.z = MyEasing.QuartOut(shakeTimer, shakeTime, transform.eulerAngles.z + 140, transform.eulerAngles.z + 200);
                sword.transform.eulerAngles = angle;

                if (shakeTimer >= shakeTime)
                {
                    isAttack = true;
                    playerPos = playerObj.transform.position;
                    nowPos = transform.position;
                    isShake = false;
                    shakeTimer = 0;
                }
            }

            if (isAttack)
            {
                timer += Time.deltaTime;

                transform.position = MyEasing.QuartOut(timer, totalTime, nowPos, playerPos);

                var angle = sword.transform.eulerAngles;
                angle.z = MyEasing.QuartOut(timer, totalTime, transform.eulerAngles.z + 200, transform.eulerAngles.z + 40);
                sword.transform.eulerAngles = angle;

                if (timer >= totalTime)
                {
                    isAttack = false;
                    timer = 0;
                }
            }
        }
	}

	public bool GetIsAttackMove()
	{
        if(isShake == true || isAttack == true)
        {
            return true;
        }
        else return false;
	}

    public bool GetIsAttack()
    {
        return isAttack;
    }

    public void Attack()
	{
		isShake = true;
		shakeTimer = 0;
		timer = 0;
	}
}