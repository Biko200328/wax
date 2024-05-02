using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float nowHp;
    [SerializeField] float maxHp;
    [SerializeField] float damageNum;

    bool isDamage;
    [SerializeField] float mutekiTime = 1;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲージっぽく
        var scale = gameObject.transform.localScale;
        scale.x = nowHp / maxHp;
        gameObject.transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        if(isDamage)
        {
            timer += Time.deltaTime;
            if(timer >= mutekiTime)
            {
                isDamage = false;
                timer = 0;
            }
        }
    }

    public void Damage()
    {
        if(isDamage == false)
        {
            isDamage = true;
            timer = 0;
            //指定した数値分減らす
            if (nowHp > 0)
            {
                nowHp -= damageNum;
                //0以下にならないように
                if (nowHp <= 0)
                {
                    nowHp = 0;
                }
            }
        }
    }
}
