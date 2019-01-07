using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中山
//内容：中ボスの行動パターンを制御

public partial class MediumBoss : MonoBehaviour
{
    public void Think()
    {
        if (currentAnimatorInfo.IsName("移動"))
        {
            this.CheckDeath();
            //アタックトリガーが入ったら
            if (this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
            {
                //威嚇モーションへ
                anim.SetBool("Threat", true);
                rand = Random.Range(0, 2);
            }
            this.HirumiCheck();
            if (!chaseFlag)
            {
                anim.SetBool("Move", false);
            }
        }
        else if (currentAnimatorInfo.IsName("待機"))
        {
            this.CheckDeath();
            this.HirumiCheck();
            Rot();
            //距離が離れていたら
            if (this.CheckDistance())
            {
                //移動か突進してたら処理しない
                if (chaseFlag||tossinFlag)
                {
                    return;
                }
                switch (Random.Range(0, 2))
                {
                    //移動か突進のどちらか
                    case 0:
                        anim.SetBool("Charge", true);
                        tossinFlag = true;
                        break;
                    default:
                        chaseFlag = true;
                        anim.SetBool("Move", true);
                        break;
                }
            }
            else
            {
                if (this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
                {
                    anim.SetBool("Threat", true);
                }
                else
                {
                    chaseFlag = true;
                    anim.SetBool("Move", true);
                }
            }
        }
        else if (currentAnimatorInfo.IsName("被ダメージ"))
        {
            //アリの現在体力が半分以下だったら
            if (this.gameObject.GetComponent<EnemyReflect>().num <= GetComponent<EnemyState>().shogunHalfHP)
            {
                anim.SetTrigger("Howling");
            }

        }
        else if (currentAnimatorInfo.IsName("威嚇"))
        {
            this.CheckDeath();
            if (!waitFlag)
            {

                switch (rand)
                {
                    case 0:
                        anim.SetBool("Attack", true);
                        break;
                    default:
                        anim.SetBool("Attack1", true);
                        break;
                }

            }
            if (!this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
            {
                anim.SetBool("Threat", false);
            }
            this.HirumiCheck();
        }
        else if (currentAnimatorInfo.IsName("溜め"))
        {
            this.CheckDeath();
            this.HirumiCheck();
            this.DestinationSet();
            anim.SetBool("Attack2", true);
        }
        else if (currentAnimatorInfo.IsName("攻撃1"))
        {
            this.CheckDeath();
            this.HirumiCheck();
            if (this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
            {
                //威嚇モーションへ
                anim.SetBool("Threat", true);
                this.UnAttackTimeReset();
                anim.SetBool("Attack", false);
            }
            if (!this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
            {
                anim.SetBool("Threat", false);
                anim.SetBool("Move", true);
                this.UnAttackTimeReset();
                anim.SetBool("Attack", false);
            }

        }
        else if (currentAnimatorInfo.IsName("攻撃2"))
        {
            this.CheckDeath();
            this.HirumiCheck();
            if (this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
            {
                //威嚇モーションへ
                anim.SetBool("Threat", true);
                this.UnAttackTimeReset();
                anim.SetBool("Attack1", false);
            }
            if (!this.GetComponentInChildren<MediumBossAttack>().attacktrigger)
            {
                anim.SetBool("Threat", false);
                anim.SetBool("Move", true);
                this.UnAttackTimeReset();
                anim.SetBool("Attack1", false);
            }
        }
        else if (currentAnimatorInfo.IsName("攻撃3"))
        {
            this.CheckDeath();
            this.GetComponentInChildren<MediumBossAttack>().attacktrigger1 = true;
            this.HirumiCheck();
            //突進攻撃開始
            ChargeAttack();
            if (!tossinFlag)
            {
                anim.SetBool("Charge", false);
                anim.SetBool("Move", false);
                anim.SetBool("Attack1", false);
            }
        }
        else if (currentAnimatorInfo.IsName("仲間呼び"))
        {
            //ここに仲間を呼ぶ動作を追加予定
        }
        else if (currentAnimatorInfo.IsName("死亡"))
        {

        }
    }
    //ひるむダメージを受けたか
    void HirumiCheck()
    {
        if (this.gameObject.GetComponent<EnemyReflect>().falterDamarge <= 0)
        {
            this.gameObject.GetComponent<EnemyReflect>().falterDamarge = 10;
            anim.SetTrigger("Damarge");
        }
    }
    //HPが0になったかどうか確認する
    void CheckDeath()
    {
        //HPが０になったら
        if (this.gameObject.GetComponent<EnemyReflect>().num <= 0)
        {
            //死亡モーションへ
            anim.SetTrigger("Death");
        }
    }
}

