using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：木下
//内容：雑魚アリの攻撃

public class EnemyAttack : MonoBehaviour
{
    //最初の座標を保存
    public Vector3 startpos;
    //EnemyApproacheで切り替える
    public bool attacktrigger;
    //private Transform playertr;
    ////回転スピード
    //private float rotspeed;
    void Start ()
    {
        this.startpos = this.gameObject.transform.localPosition;
        ////回転に必要な情報
        //playertr = GameObject.FindGameObjectWithTag("Player").transform;
        //rotspeed = 0.5f;
        //TypeCheckより自分の種類を取りこむ
    }
	void Update ()
    {
        //EnemyApproacheでフラグを立てる
        //攻撃可能範囲内なら
        if (attacktrigger)
        {
            if (!this.gameObject.GetComponentInParent<Enemy>().waitFlag)
            {
                //攻撃判定用のコライダーを出す
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                //-1.0まで動かす
                if (this.gameObject.transform.localPosition.x > -1.0f)
                {
                    this.AttackMove();
                }
                else
                {
                    //あたり判定を無効化し、初期値に戻す
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    this.gameObject.transform.localPosition = this.startpos;
                    //一回当てたらしばらく攻撃しない
                    this.gameObject.GetComponentInParent<Enemy>().waitFlag = true;
                }
            }
        }
        //攻撃可能範囲外に出たら
        else
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.transform.localPosition = this.startpos;
            this.GetComponentInParent<Enemy>().UnAttackTimeReset();
        }

        //
    }
    public void AttackMove()
    {
        //左方向へ振る
        this.gameObject.transform.localPosition += Vector3.left * Time.deltaTime * 5;
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
