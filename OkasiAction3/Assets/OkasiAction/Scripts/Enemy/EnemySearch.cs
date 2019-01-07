using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：木下
//内容：雑魚アリのPlayer索敵

public partial class Enemy : MonoBehaviour
{

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
            //追跡をやめる
            this.movetrigger = false;
            //攻撃前に時間を持たせる
            this.waitFlag = true;
            //攻撃スタート
            this.GetComponentInChildren<EnemyAttack>().attacktrigger = true;
        }
        //接触したのが索敵範囲のほうならば
        else
        {
            //敵にアタッチされているEnemyMoveスクリプトのフラグをオンにする
            this.movetrigger = true;
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
            //追跡を開始する
            this.movetrigger = true;
            //攻撃をやめる
            this.GetComponentInChildren<EnemyAttack>().attacktrigger = false;
        }
        else
        {
            //追跡をやめる
            this.GetComponent<Enemy>().movetrigger = false;
        }
    }
}
