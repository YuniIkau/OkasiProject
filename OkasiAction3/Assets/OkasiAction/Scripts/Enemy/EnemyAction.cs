using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    public void Action()
    {
        if (currentAnimatorInfo.IsName("移動"))
        {
        }
        else if (currentAnimatorInfo.IsName("待機"))
        {
        }
        else if (currentAnimatorInfo.IsName("被ダメージ"))
        {
            this.UnAttackTimeReset();
            knockBack();
            damage = false;
        }
        else if (currentAnimatorInfo.IsName("威嚇"))
        {
            this.UnAttackTimeUpdate();
        }
        else if (currentAnimatorInfo.IsName("攻撃1"))
        {
            if (this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {         
                this.UnAttackTimeReset();
            }
            else
            {
                this.UnAttackTimeReset();
            }
        }
        else if (currentAnimatorInfo.IsName("攻撃2"))
        {
            if (this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                this.UnAttackTimeReset();
            }
            else
            {
                this.UnAttackTimeReset();
            }
        }
        else if (currentAnimatorInfo.IsName("攻撃3"))
        {
            if (this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                this.UnAttackTimeReset();
            }
            else
            {
                this.UnAttackTimeReset();
            }
        }
        else if (currentAnimatorInfo.IsName("死亡"))
        {
            deadFlag = true;
            this.UnAttackTimeReset();
        }
        else if (currentAnimatorInfo.IsName("死亡後"))
        {
            //ここでアイテムの生成
            itemFactory.Create(itemtype.ToString(), this.transform.position);
            Destroy(this.gameObject);
        }
    }
    //public void EnemyDeath()
    //{
    //    //死亡処理
    //    Destroy(this.gameObject);
    //}
}

