using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：木下
//内容：敵の動きを制御する

public partial class Enemy : MonoBehaviour
{
    //敵のステータスの取得用クラス
    EnemyState enemy;
    //移動ベクトル
    Vector3 moveVec;
    //初回ダメージ
    [HideInInspector]
    public bool damage;
    //死亡フラグ
    bool dead;
    //移動用トリガー
    [HideInInspector]
    public bool movetrigger;
    //プレイヤーの位置
    private Transform playertr;
    //敵の回転スピード（0.0～1.0）
    private float rotspeed = 1.0f;
    //移動スピード保管
    private float speed;
    //攻撃中を判定するflag
    //[HideInInspector]
    public bool waitFlag;
    //攻撃までの時間
    public float waitTime;
    //後で消すこと
    public float timeWait;
    //死亡時移動防止用フラグ
    private bool deadFlag;
    //攻撃をランダムにする
    private int rand;

    //目的地との距離
    float moveDist;
    //目的地を変える距離
    float chengeMoveDist = 20.0f;
    //敵の目的地
    Vector3 targetPosition;
    //[SerializeField] private GameObject playertr = null;

    //animator
    Animator anim;
    AnimatorStateInfo currentAnimatorInfo;

    //アイテムドロップ用
    ItemFactory itemFactory;
    public enum ItemType
    {
        None,
        HPUP,
        AttackUP,
        SpeedUP,
        Recovery
    }
    //ファクトリー側から参照しないといけないためパブリックにしてある
    [Tooltip("落とすアイテムの種類")]
    public ItemType itemtype;

    //自身のコライダーの取得
    private BoxCollider boxcollider;

    void Start()
    {
        //パラメータ読み込み
        this.enemy = GetComponent<EnemyState>();
        //プレイヤーの位置の獲得
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
        //animatorの取得
        anim = this.GetComponentInChildren<Animator>();
        //自身のコライダーを取得
        boxcollider = GetComponent<BoxCollider>();
        //のち、テーブル等にする
        timeWait = 4;
        //攻撃待機時間の指定
        waitTime = timeWait;
        //
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
        //ファクトリーメソッドの取得
        itemFactory = GameObject.FindGameObjectWithTag("Factory").GetComponent<ItemFactory>();
    }
    void Update()
    {
        if (this.dead)
        {
            return;
        }
        currentAnimatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        //this.UnAttackTimeUpdate();
        this.Think();
        this.Action();
        this.EnemyMove();
    }
    //---------------------------------------------------------------------------------------------------
    //攻撃不能時間の更新
    void UnAttackTimeUpdate()
    { 
        waitTime-=Time.deltaTime;
        if (waitTime <= 0)
        {
            waitFlag = false;
        }
    }
    //攻撃不能時間のリセット
    public void UnAttackTimeReset()
    {
        waitTime = timeWait;
        waitFlag = true;
    }
    private void knockBack()
    {
        transform.Translate(Vector3.back * 5 * Time.deltaTime);
    }
}