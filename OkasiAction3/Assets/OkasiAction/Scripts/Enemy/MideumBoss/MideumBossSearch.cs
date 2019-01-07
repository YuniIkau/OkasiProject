using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中山
//内容：中ボスのプレイヤーとの距離を制御する

public partial class MediumBoss : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        //敵(自身)と索敵範囲もしくは攻撃可能範囲が接触したときだけ処理をする
        if (!(other.gameObject.CompareTag("EnemySearchArea")) && !(other.gameObject.CompareTag("EnemyAttackArea")))
        {
            return;
        }
        //接触したのが攻撃可能範囲のほうならば
        else if (other.gameObject.CompareTag("EnemyAttackArea"))
        {
            if (!this.GetComponentInChildren<MediumBossAttack>().attacktrigger1)
            {
                //攻撃前に時間を持たせる
                this.waitFlag = true;
                //攻撃スタート
                this.GetComponentInChildren<MediumBossAttack>().attacktrigger = true;
            }         
        }
    }
    //敵(自身)とプレイヤタグが接触しなくなったときだけ処理をする
    private void OnTriggerExit(Collider other)
    {
        if (!(other.gameObject.CompareTag("EnemySearchArea")) && !(other.gameObject.CompareTag("EnemyAttackArea")))
        {
            return;
        }
        else if (other.gameObject.CompareTag("EnemyAttackArea"))
        {
            //攻撃をやめる
            this.GetComponentInChildren<MediumBossAttack>().attacktrigger = false;
        }

    }
}
