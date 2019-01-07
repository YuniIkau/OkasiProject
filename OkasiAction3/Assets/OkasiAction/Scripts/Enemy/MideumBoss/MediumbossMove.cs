using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中山
//内容：中ボスの移動を制御する

public partial class MediumBoss : MonoBehaviour
{
    //プレイヤーへの向き
    Vector3 vec;
    public void MediumBossMove()
    {
        if (currentAnimatorInfo.IsName("移動"))
        {
            //回転
            Rot();
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            LowerChaseTime();
        }
    }
    //プレイヤーと自身が一定距離離れているか
    public bool CheckDistance()
    {
        dist = Vector3.SqrMagnitude(playertr.position - this.transform.position);
        //プレイヤーとの距離が離れていたら
        if (dist > chengeMoveDist)
        {
            return true;
        }
        return false;
    }
    //突進攻撃時の移動
    public void ChargeAttack()
    {
        //設定した場所へ移動
        this.transform.position = Vector3.MoveTowards(this.transform.position,
            new Vector3(targetPosition.x, 0, targetPosition.z), 10 * Time.deltaTime);
        //目的地との距離が一定以内だったら
        if (Vector3.SqrMagnitude(targetPosition - this.transform.position) < 5)
        {
            tossinFlag = false;
            this.GetComponentInChildren<MediumBossAttack>().attacktrigger1 = false;
        }
    }
    //プレイヤーに向かって回転する
    public void Rot()
    {
        vec = playertr.position - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), 0.8f);
    }
    //突進の目的地設定
    public void DestinationSet()
    {
        this.Rot();
        targetPosition = playertr.position;
    }
}
