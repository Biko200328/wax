using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] EnemyAttack enemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyAttack.GetIsAttack())
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerHP playerHp = GameObject.Find("PlayerHPGauge").GetComponent<PlayerHP>();
                playerHp.Damage();
            }
        }
    }
}
