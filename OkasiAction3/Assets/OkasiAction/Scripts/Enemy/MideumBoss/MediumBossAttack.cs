using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中山
//内容：中ボスの攻撃の動きを制御する

public class MediumBossAttack : MonoBehaviour
{
    //最初の座標を保存
    public Vector3 startpos;
    //EnemyApproacheで切り替える
    public bool attacktrigger;
    public bool attacktrigger1;
    BoxCollider box;
    void Start()
    {
        this.startpos = this.gameObject.transform.localPosition;
        box = this.gameObject.GetComponent<BoxCollider>();
    }
    void Update()
    {
        //EnemyApproacheでフラグを立てる
        //攻撃可能範囲内なら
        if (attacktrigger)
        {
            Attack();
        }
        else if (attacktrigger1)
        {
            Attack1();
        }
        else if (!attacktrigger1)
        {
            //あたり判定を無効化し、初期値に戻す           
            this.box.enabled = false;
            this.box.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.gameObject.transform.localPosition = this.startpos;
            //一回当てたらしばらく攻撃しない
            this.gameObject.GetComponentInParent<MediumBoss>().waitFlag = true;
        }
        else
        {
            AttackReset();
        }
    }
    //噛みつき攻撃
    public void Attack()
    {
        if (!this.gameObject.GetComponentInParent<MediumBoss>().waitFlag)
        {
            //攻撃判定用のコライダーを出す
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            this.box.enabled = true;
            //-1.0まで動かす
            if (this.gameObject.transform.localPosition.x > -1.0f)
            {
                this.AttackMove();
            }
            else
            {
                //あたり判定を無効化し、初期値に戻す
                this.box.enabled = false;
                this.gameObject.transform.localPosition = this.startpos;
                //一回当てたらしばらく攻撃しない
                this.gameObject.GetComponentInParent<MediumBoss>().waitFlag = true;
            }
        }
    }
    //当たり判定等のリセット
    public void AttackReset()
    {
        this.box.enabled = false;
        this.gameObject.transform.localPosition = this.startpos;
        this.GetComponentInParent<MediumBoss>().UnAttackTimeReset();
    }
    public void AttackMove()
    {
        //左方向へ振る
        this.gameObject.transform.localPosition += Vector3.left * Time.deltaTime * 5;
    }
    //突進攻撃するときに当たり判定を前方に出す
    public void Attack1()
    {
        if (!this.box.enabled)
        {
            //攻撃判定用のコライダーを出す
            this.box.enabled = true;
            this.gameObject.transform.localPosition = new Vector3(0, 0.5f, 2);
            this.box.transform.localEulerAngles = new Vector3(0, 90.0f, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            //プレイヤーに当たったら自身の敵tagを取得
            other.gameObject.GetComponent<PlayerReflect>().PlayerThisDamage(gameObject.transform.parent.tag);
        }
    }
}
