using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Enemy : MonoBehaviour
{
    public void Think()
    {
        if (currentAnimatorInfo.IsName("移動"))
        {
            //自由移動中一定距離歩いたら
            //if(moveDist < chengeMoveDist)
            //{
            //    //待機モーションへ
            //    anim.SetBool("Move", false);
            //}
            if(!movetrigger&& !(this.GetComponentInChildren<EnemyAttack>().attacktrigger))
            {
                //待機モーションへ
                anim.SetBool("Move", false);
            }
            //アタックトリガーが入ったら
            if (this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                //威嚇モーションへ
                anim.SetBool("Threat",true);
                rand = Random.Range(0, 3);
            }
            //HPが０になったら
            if(this.gameObject.GetComponent<EnemyReflect>().num <= 0)
            {
                //死亡モーションへ
                anim.SetTrigger("Death");
            }
            //今までよりHPが少なくなったら
            if(damage)
            {
                //ダメージモーションへ
                anim.SetTrigger("Damage");
            }
        }
        else if (currentAnimatorInfo.IsName("待機"))
        {
            if(movetrigger)
            {
                //移動モーションへ
                anim.SetBool("Move", true);
            }
            if (this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                //威嚇モーションへ
                anim.SetBool("Threat",true);
            }
            //HPが０になったら
            if (this.gameObject.GetComponent<EnemyReflect>().num <= 0)
            {
                //死亡モーションへ
                anim.SetTrigger("Death");
            }
            if (damage)
            {
                //ダメージモーションへ
                anim.SetTrigger("Damage");
            }
        }
        else if (currentAnimatorInfo.IsName("被ダメージ"))
        {
        }
        else if (currentAnimatorInfo.IsName("威嚇"))
        {
            if(!this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                anim.SetBool("Threat", false);
            }
            //今までよりHPが少なくなったら
            if (damage)
            {
                //ダメージモーションへ
                anim.SetTrigger("Damage");
                anim.SetBool("Threat", false);
            }
            //待機時間が無くなったら
            if(!waitFlag)
            {
                //攻撃モーションへ
                //anim.SetBool("Attack1", true);
               
                switch (rand)
                {
                    case 0:
                        //攻撃モーションへ
                        anim.SetBool("Attack1",true);
                        break;
                    case 1:
                        //攻撃モーションへ
                        anim.SetBool("Attack2",true);
                        break;
                    case 2:
                        //攻撃モーションへ
                        anim.SetBool("Attack3",true);
                        break;
                    default:
                        break;
                }
                ////攻撃モーションへ
                //anim.SetBool("Attack",true);
            }
            //HPが０になったら
            if (this.gameObject.GetComponent<EnemyReflect>().num <= 0)
            {
                //死亡モーションへ
                anim.SetTrigger("Death");
            }
            if(!this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                anim.SetBool("Threat", false);
            } 
        }
        else if (currentAnimatorInfo.IsName("攻撃1"))
        {

            //HPが０になったら
            if (this.gameObject.GetComponent<EnemyReflect>().num <= 0)
            {
                //死亡モーションへ
                anim.SetTrigger("Death");
            }
            //今までよりHPが少なくなったら
            if (damage)
            {
                //ダメージモーションへ
                anim.SetTrigger("Damage");
            }
            anim.SetBool("Attack1", false);
        }
        else if (currentAnimatorInfo.IsName("攻撃2"))
        {
            //HPが０になったら
            if (this.gameObject.GetComponent<EnemyReflect>().num <= 0)
            {
                //死亡モーションへ
                anim.SetTrigger("Death");
            }
            //今までよりHPが少なくなったら
            if (damage)
            {
                //ダメージモーションへ
                anim.SetTrigger("Damage");
            }
            anim.SetBool("Attack2", false);
        }
        else if (currentAnimatorInfo.IsName("攻撃3"))
        {
            //HPが０になったら
            if (this.gameObject.GetComponent<EnemyReflect>().num <= 0)
            {
                //死亡モーションへ
                anim.SetTrigger("Death");
            }
            //今までよりHPが少なくなったら
            if (damage)
            {
                //ダメージモーションへ
                anim.SetTrigger("Damage");
            }
            anim.SetBool("Attack3", false);
        }
        else if (currentAnimatorInfo.IsName("死亡"))
        {
        }
        else if(currentAnimatorInfo.IsName("死亡後"))
        {  
        }
    }
}
