using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中山
//内容：中ボスの動きを制御する

public partial class MediumBoss : MonoBehaviour
{

    //中ボスのステータスの取得用クラス
    //未完成
    //敵のステータスの取得用クラス
    EnemyState enemy;
    //武器オブジェクト
    //移動ベクトル
    Vector3 moveVec;

    bool chaseFlag = false;

    //攻撃中を判定するflag
    public bool waitFlag;
    public int waitTime;

    //死亡フラグ
    bool dead;
    //移動用トリガー
    [HideInInspector]
    //プレイヤーの位置
    private Transform playertr;
    //敵の回転スピード（0.0～1.0）
    //private float rotspeed = 1.0f;
    //移動スピード保管
    private float speed;
    //目的地との距離
    float dist;
    //目的地を変える距離
    float chengeMoveDist = 20.0f;
    //敵の目的地
    Vector3 targetPosition;
    //追跡時間
    float chaseTime = 60.0f;
    bool tossinFlag = false;
    //敵のランダム攻撃変数
    private int rand;

    //[SerializeField] private GameObject playertr = null;

    //animator
    Animator anim;
    AnimatorStateInfo currentAnimatorInfo;

    //自身のコライダーの取得
    private BoxCollider boxcollider;
    // Use this for initialization
    void Start () {
        //パラメータ読み込み
        this.enemy = GetComponent<EnemyState>();
        //プレイヤーの位置の獲得
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
        //animatorの取得
        anim = this.GetComponentInChildren<Animator>();
        //自身のコライダーを取得
        boxcollider = GetComponent<BoxCollider>();
        //のち、テーブル等にする
        //攻撃待機時間の指定
        waitTime = 60 * 2;
        //↓中ボスにはいらないかも
        //移動スピードを敵タイプごとに設定
        var enemy = Resources.Load("EnemyTable") as EnemyTable;
        switch (this.gameObject.tag)
        {
            case "Normal_Ant":
                speed = enemy.normalSpeed;
                break;
            case "Armor_Ant":
                speed = enemy.armorSpeed;
                break;
            case "Shogun_Ant":
                speed = enemy.shogunSpeed;
                break;
            case "Thorn_Ant":
                speed = enemy.thornSpeed;
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(this.dead)
        {
            return;
        }
        currentAnimatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        this.UnAttackTimeUpdate();
        this.Think();
        this.MediumBossAction();
        this.MediumBossMove();
	}
    //攻撃不能時間の更新
    void UnAttackTimeUpdate()
    {
        if(!currentAnimatorInfo.IsName("威嚇"))
        {
            return;
        }
        --waitTime;
        if (waitTime <= 0)
        {
            waitFlag = false;
        }
    }
    //攻撃不能時間のリセット
    public void UnAttackTimeReset()
    {
        //威嚇中だったらタイムをリセットしない
        if (currentAnimatorInfo.IsName("威嚇"))
        {
            return;
        }
        waitTime = 60 * 2;
        waitFlag = true;
    }
    //追跡時間を減らす
    public void LowerChaseTime()
    {
        --chaseTime;
        if (chaseTime <= 0)
        {
            chaseFlag = false;
            chaseTime = 60;
        }
    }
}
