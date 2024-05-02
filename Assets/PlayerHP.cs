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
        //�Q�[�W���ۂ�
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
            //�w�肵�����l�����炷
            if (nowHp > 0)
            {
                nowHp -= damageNum;
                //0�ȉ��ɂȂ�Ȃ��悤��
                if (nowHp <= 0)
                {
                    nowHp = 0;
                }
            }
        }
    }
}
