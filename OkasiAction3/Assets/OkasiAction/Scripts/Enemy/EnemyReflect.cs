using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：敵側の各判定処理
//敵がダメージを受けた時の処理
//死亡時の処理
//これらのメソッドを各判定時に呼び出す

public class EnemyReflect : MonoBehaviour
{
    EnemyState enemyState;
    PlayerState playerState;
    PlayerTable player;
    EnemyTable enemy;
    public float num;
    //被ダメージ前のHP
    public float beforeHP;
    //ひるむダメージ
    public float falterDamarge;

    void Start()
    {
        enemyState = GetComponent<EnemyState>();
        playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        player = Resources.Load("PlayerTable") as PlayerTable;
        enemy = Resources.Load("EnemyTable") as EnemyTable;
        switch (this.gameObject.tag)
        {
            case "Normal_Ant":
                num = enemyState.normalHP;
                break;
            case "Armor_Ant":
                num = enemyState.armorHP;
                break;
            case "Shogun_Ant":
                num = enemyState.shogunHP;
                break;
            case "Thorn_Ant":
                num = enemyState.thornHP;
                break;
        }
    }
    void Update()
    {
        beforeHP = num;
    }
    public void EnemyThisDamage()
    {
        //自身のtagでだれのステータスを見るかを決定する
        switch (this.gameObject.tag)
        {
            case "Normal_Ant":
                enemyState.normalHP -= playerState.attack;
                num = enemyState.normalHP;
                break;
            case "Armor_Ant":
                enemyState.armorHP -= playerState.attack;
                num = enemyState.armorHP;
                break;
            case "Shogun_Ant":
                enemyState.shogunHP -= playerState.attack;
                num = enemyState.shogunHP;
                break;
            case "Thorn_Ant":
                enemyState.thornHP -= playerState.attack;
                num = enemyState.thornHP;
                break;
        }
        //if (num <= 0)
        //{
        //    //死亡関数
        //    EnemyDeath();
        //    return;
        //}
        enemyState.unHitTime = enemy.unHitTime;
    }
    //public void EnemyDeath()
    //{
    //    //死亡処理
    //    Destroy(this.gameObject);
    //}
}
