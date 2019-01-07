using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中島
//内容：プレイヤーの動きを制御する

public partial class Player : MonoBehaviour
{
    //プレイヤのステータスの取得用クラス
    PlayerState player;
    //プレイヤのテーブル(参照用)
    PlayerTable playerTable;
    //武器オブジェクト
    Weapon weapon;
    //重力
    Rigidbody rdby;
    //Y軸の回転率
    float angleY;
    //移動ベクトル
    Vector3 moveVec;
    //カメラY軸の回転率
    float camAngleY;
    //回避方向
    string evasionDire;
    //初回攻撃
    bool firstAttack;           
    //ため時間
    bool charge;
    //ため攻撃可能
    bool chargeAttack;
    //必殺技フラグ
    bool ultimateAttack;
    //死亡フラグ
    bool dead;
    //animator
    Animator anim;
    AnimatorStateInfo currentAnimatorInfo;
    void Start()
    {
        //テーブルの読み込み
        playerTable = Resources.Load("PlayerTable") as PlayerTable;
        this.camAngleY = GameObject.FindGameObjectWithTag("MainCamera").transform.eulerAngles.y;
        //パラメータ読み込み
        this.player = GetComponent<PlayerState>();
        //武器クラス取得
        this.weapon = this.gameObject.GetComponentInChildren<Weapon>();
        //重力クラスの取得
        this.rdby = this.gameObject.GetComponent<Rigidbody>();
        //animatorの習得
        anim = GameObject.FindGameObjectWithTag("Mair").GetComponent<Animator>();
    }
    void Update()
    {
        currentAnimatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        this.Think();
        if (this.dead)
        {
            return;
        }
        this.Action();
        this.camAngleY = GameObject.FindGameObjectWithTag("MainCamera").transform.eulerAngles.y;
        this.UnHitTimeUpdate();
    }
    //-----------------------------------------------------------------------------------
    //回転
    public void Rotation(float angleY)
    {
        this.angleY = angleY;
    }
    //-----------------------------------------------------------------------------------
    //移動
    public void Move(Vector3 moveVec)
    {
        this.moveVec = moveVec;
    }
    //-----------------------------------------------------------------------------------
    //攻撃
    public void Attack()
    {
        if(currentAnimatorInfo.IsName("死亡"))
        {
            return;
        }
        player.chargeTimeNow = playerTable.chargeTime;
        if (!this.firstAttack)
        {
            this.InitializeAttackMoveDist();
            this.firstAttack = true;
        }
        weapon.Effectiveness();
    }
    //-----------------------------------------------------------------------------------
    //攻撃時移動距離を初期化
    void InitializeAttackMoveDist()
    {
        currentAnimatorInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (currentAnimatorInfo.IsName("攻撃１"))
        {
            player.attackMoveDistNow[1] = playerTable.attackMoveDist[1];
        }
        else if (currentAnimatorInfo.IsName("攻撃２"))
        {
            player.attackMoveDistNow[2] = playerTable.attackMoveDist[2];
        }
    }
    //-----------------------------------------------------------------------------------
    //攻撃時移動
    void AttackMove(int index)
    {
        player.attackMoveDistNow[index] = player.attackMoveDistNow[index] - Time.deltaTime * playerTable.attackMoveDistRate[index] > 0 ?
                                        player.attackMoveDistNow[index] - Time.deltaTime * playerTable.attackMoveDistRate[index] : 0;
        this.gameObject.transform.Translate(Vector3.forward * player.attackMoveDistNow[index] * Time.deltaTime);
    }
    //-----------------------------------------------------------------------------------
    //ためる
    public void Charge()
    {
        //ためフラグを立てる
        this.charge = true;
    }
    //-----------------------------------------------------------------------------------
    //ため時間リセット
    public void ResetOrReleaseCharge()
    {
        //ためフラグをおろす
        this.charge = false;
    }
    //-----------------------------------------------------------------------------------
    //必殺技
    public void UltimateAttack()
    {
        //とりあえず5以上の場合
        if (player.sP >= 5)
        {
            this.ultimateAttack = true;
            player.sP -= 5;
        }
    }
    //-----------------------------------------------------------------------------------
    //回避中か否か
    public bool ReturnAttack()
    {
        return currentAnimatorInfo.IsName("攻撃１") || currentAnimatorInfo.IsName("攻撃２") ||
               currentAnimatorInfo.IsName("攻撃３");
    }
    //-----------------------------------------------------------------------------------
    //回避予備動作
    public void EvasionSub(float hori,float vert)
    {
        float degAng = Mathf.Atan2(hori, vert) * Mathf.Rad2Deg;
        if (!ReturnEvasion())
        {
            if (-45 < degAng && degAng <= 45)
            {
                this.evasionDire = "EvadeForward";
                
            }
            else if(45 < degAng && degAng <= 135)
            {
                this.evasionDire = "EvadeRight";
            }
            else if (-45 >= degAng && degAng > -135)
            {
                this.evasionDire = "EvadeLeft";               
            }
            else
            {
                this.evasionDire = "EvadeBack";
            }
            player.evasionDistNow = playerTable.evasionDist;
        }
    }
    //-----------------------------------------------------------------------------------
    //回避予備動作(ボタンのみ)
    public void EvasionSub()
    {
        if (!ReturnEvasion())
        {
            this.evasionDire = "EvadeBack";
            player.evasionDistNow = playerTable.evasionDist;
        }
    }
    //-----------------------------------------------------------------------------------
    //回避
    public void Evasion()
    {
        if (currentAnimatorInfo.IsName("右回避"))
        {
            this.EvasionMove("右");
        }
        else if (currentAnimatorInfo.IsName("左回避"))
        {
            this.EvasionMove("左");
        }
        else if(currentAnimatorInfo.IsName("前回避"))
        {
            this.EvasionMove("前");
        }
        else if(currentAnimatorInfo.IsName("後回避"))
        {
            this.EvasionMove("後");
        }
        else
        {
            this.evasionDire = null;
        }
    }
    //-----------------------------------------------------------------------------------
    //回避中か否か
    public bool ReturnEvasion()
    {
        return currentAnimatorInfo.IsName("左回避") || currentAnimatorInfo.IsName("右回避") ||
               currentAnimatorInfo.IsName("前回避") || currentAnimatorInfo.IsName("後回避");
    }
    //-----------------------------------------------------------------------------------
    //回避移動
    void EvasionMove(string direction)
    {
        player.evasionDistNow = player.evasionDistNow - Time.deltaTime * playerTable.evasionDistRate > 0 ?
                                  player.evasionDistNow - Time.deltaTime * playerTable.evasionDistRate : 0;
        this.gameObject.transform.rotation = Quaternion.Euler(Vector3.up * this.camAngleY);
        switch(direction)
        {
            //向きによって処理が分けられるように
            default:
                break;
            case "右":
                this.gameObject.transform.Translate(Vector3.right * player.evasionDistNow * Time.deltaTime);
                break;
            case "左":
                this.gameObject.transform.Translate(Vector3.left * player.evasionDistNow * Time.deltaTime);
                break;
            case "前":
                this.gameObject.transform.Translate(Vector3.forward * player.evasionDistNow * Time.deltaTime);
                break;
            case "後":
                this.gameObject.transform.Translate(Vector3.back * player.evasionDistNow * Time.deltaTime);
                break;
        }
    }
    //-----------------------------------------------------------------------------------
    //ジャンプ
    public void Jump()
    {
        if (currentAnimatorInfo.IsName("待機") || currentAnimatorInfo.IsName("移動"))
        {
            if (Mathf.Abs(this.rdby.velocity.y) < playerTable.jumpPow)
            {
                this.rdby.velocity = Vector3.up * playerTable.jumpPow;
            }
        }
    }
    //-----------------------------------------------------------------------------------
    //無敵時間の更新
    void UnHitTimeUpdate()
    {
        //無敵時間でない場合は処理しない
        if (player.unHitTime <= 0)
        {
            player.firstDamage = true;
            player.unHitTime = 0;
            return;
        }
        //減算する
        player.unHitTime -= Time.deltaTime;
    }
    //-----------------------------------------------------------------------------------
    //死亡処理
    public void Death()
    {
        //死亡状態に移行する
        this.moveVec = Vector3.zero;
        this.dead = true;
    }
}