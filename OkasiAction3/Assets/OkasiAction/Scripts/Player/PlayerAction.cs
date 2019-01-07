using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：Playerスクリプトのモーションのステータスをもらいそのモーションに応じた処理をする
//(Playerスクリプトのコード量が多すぎるため分割した)

public partial class Player : MonoBehaviour
{
    public void Action()
    {
        if (currentAnimatorInfo.IsName("死亡"))
        {
            //死亡処理

        }
        else
        {
            if (currentAnimatorInfo.IsName("攻撃１"))
            {
                if (this.firstAttack)
                {
                    this.firstAttack = false;
                }
                this.AttackMove(0);
            }
            else if (currentAnimatorInfo.IsName("攻撃２"))
            {
                if (this.firstAttack)
                {
                    weapon.Effectiveness();
                    this.firstAttack = false;
                }
                this.AttackMove(1);
            }
            else if (currentAnimatorInfo.IsName("攻撃３"))
            {
                if (weapon.GetComponent<BoxCollider>().enabled)
                {
                    if (this.firstAttack)
                    {
                        //Normal_AnteffectFactory.Create("Attack3Effect", this.transform);
                        this.firstAttack = false;
                    }
                }
                this.AttackMove(2);
            }
            else if (currentAnimatorInfo.IsName("ため状態"))
            {
                if (player.chargeTimeNow > 0)
                {
                    player.chargeTimeNow -= Time.deltaTime;
                }
                else
                {
                    player.chargeTimeNow = 0;
                    this.chargeAttack = true;
                }
            }
            else if (currentAnimatorInfo.IsName("ため攻撃"))
            {
                //ため攻撃時の処理
            }
            else if (currentAnimatorInfo.IsName("必殺技"))
            {
                this.ultimateAttack = false;
                anim.SetBool("Ulti", false);
            }
            else if (currentAnimatorInfo.IsName("被ダメージ"))
            {
                //被ダメージ処理
            }
            else if(this.ReturnEvasion())
            {

            }
            else
            {
                player.attackMoveDistNow[0] = playerTable.attackMoveDist[0];
                if (this.moveVec != Vector3.zero)
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(Vector3.up * (this.angleY + this.camAngleY));
                    this.gameObject.transform.Translate(this.moveVec * player.speed * Time.deltaTime);
                }
            }
            //回避
            this.Evasion();
        }
    }
}