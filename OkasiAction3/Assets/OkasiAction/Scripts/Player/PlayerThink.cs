using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：Playerスクリプトのモーションのステータスをもらい状態の思考をする
//(Playerスクリプトのコード量が多すぎるため分割した)

public partial class Player : MonoBehaviour
{
    public void Think()
    {
        
        if (this.dead)
        {
            anim.SetBool("Dead", true);
            return;
        }
        if (currentAnimatorInfo.IsName("待機"))
        {
            if (this.moveVec != Vector3.zero)
            {
                anim.SetBool("Move bool", true);
            }
            if (this.rdby.velocity.y >= playerTable.jumpPow * 0.1f)
            {
                anim.SetBool("Jump", true);
            }
            if (weapon.GetComponent<BoxCollider>().enabled)
            {
                if (this.firstAttack)
                {
                    anim.SetTrigger("Attack");
                    this.firstAttack = false;
                }
            }
            if (this.evasionDire != null)
            {
                anim.SetTrigger(this.evasionDire);
            }
            if (this.ultimateAttack)
            {
                anim.SetTrigger("Ulti");
            }
            if (player.unHitTime >= playerTable.unHitTime && player.firstDamage)
            {
                anim.SetTrigger("Damaged");
            }
        }

        else if (currentAnimatorInfo.IsName("移動"))
        {
            if (this.moveVec == Vector3.zero)
            {
                anim.SetBool("Move bool", false);
            }
            if (this.rdby.velocity.y >= playerTable.jumpPow * 0.1f)
            {
                anim.SetBool("Jump", true);
            }
            if (this.evasionDire != null)
            {
                anim.SetTrigger(this.evasionDire);
            }
            if (weapon.GetComponent<BoxCollider>().enabled)
            {
                if (this.firstAttack)
                {
                    anim.SetTrigger("Attack");
                    this.firstAttack = false;
                }
            }
            if (this.ultimateAttack)
            {
                anim.SetTrigger("Ulti");
            }
            if (player.unHitTime >= playerTable.unHitTime && player.firstDamage)
            {
                anim.SetTrigger("Damaged");
            }           
        }

        else if (currentAnimatorInfo.IsName("攻撃１"))
        {
            if (this.firstAttack)
            {
                anim.SetTrigger("Attack");
            }

            if (this.charge)
            {
                anim.SetBool("Charge", true);
            }
            if (this.evasionDire != null)
            {
                anim.SetTrigger(this.evasionDire);
            }
        }
        else if (currentAnimatorInfo.IsName("攻撃２"))
        {
            if (weapon.GetComponent<BoxCollider>().enabled)
            {
                if (this.firstAttack)
                {
                    anim.SetTrigger("Attack");
                }
            }
            if (this.charge)
            {
                anim.SetBool("Charge",true);
            }
            if (this.evasionDire != null)
            {
                anim.SetTrigger(this.evasionDire);
            }
        }
        else if (currentAnimatorInfo.IsName("攻撃３"))
        {
            if (this.evasionDire != null)
            {
                anim.SetTrigger(this.evasionDire);
            }
        }
        else if (currentAnimatorInfo.IsName("ため状態"))
        {
            if (!this.charge)
            {
                if (this.chargeAttack)
                {
                    anim.SetTrigger("ChargeAttack");
                    this.chargeAttack = false;
                }
                anim.SetBool("Charge", false);
            }
            if (player.unHitTime >= playerTable.unHitTime && player.firstDamage)
            {
                anim.SetTrigger("Damaged");
            }
        }
        else if(currentAnimatorInfo.IsName("ため攻撃"))
        {
            anim.SetBool("ChargeAttack", false);
        }
        else if(currentAnimatorInfo.IsName("必殺技"))
        {
            
        }
        else if (currentAnimatorInfo.IsName("左回避"))
        {

        }
        else if (currentAnimatorInfo.IsName("右回避"))
        {

        }
        else if(currentAnimatorInfo.IsName("被ダメージ"))
        {
            player.firstDamage = false;
        }
        else if(currentAnimatorInfo.IsName("ジャンプ"))
        {
            if (this.rdby.velocity.y < float.Epsilon)
            {
                anim.SetBool("Jump", false);
            }
            if (player.unHitTime >= playerTable.unHitTime && player.firstDamage)
            {
                anim.SetTrigger("Damaged");
            }
        }
        else if(currentAnimatorInfo.IsName("死亡"))
        {
            //死亡処理
        }
    }
}
