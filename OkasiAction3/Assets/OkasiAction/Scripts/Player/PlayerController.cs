using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中島
//内容：コントローラからの入力をプレイヤーに渡す

public class PlayerController : MonoBehaviour
{
    //プレイヤー
    Player player;
    //カメラ
    PlayerCamera playerCamera;
    //左スティック入力状態の保持
    float hori, vert;
    //右スティック入力状態の保持
    float hori2, vert2;
    //何回目の攻撃か
    //Player.Motion attackCount;
    //コンボ有効時間
    float comboNowTime;
    //コンボ有効時間の設定
    float comboLimitTime;
    bool Flag;
    //回避フラグ
    bool evasionFlag;

    void Start()
    {
        this.comboLimitTime = 0.5f;
        this.comboNowTime = this.comboLimitTime;
        try
        {
            //プレイヤークラスの取得
            this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        catch
        {
            //エラーメッセージ
            Debug.LogError("Playerクラスがうまく取得できませんでした。(PlayerController.cs)");
        }
        try
        {
            //カメラクラスの取得
            this.playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerCamera>();
        }
        catch
        {
            //エラーメッセージ
            Debug.LogError("PlayerCameraクラスがうまく取得できませんでした。(PlayerController.cs)");
        }
    }

    void Update()
    {
        this.GetLeftAxis();
        this.GetRightAxis();
        this.GetButton();

        if (this.Flag)
        {
            if (this.comboNowTime > 0)
            {
                this.comboNowTime -= Time.deltaTime;
            }
            else
            {
                this.comboNowTime = 0;
            }
        }
    }
    //-----------------------------------------------------------------------------------
    //左スティック入力の取得
    void GetLeftAxis()
    {
        this.hori = Input.GetAxis("Horizontal");
        this.vert = Input.GetAxis("Vertical");

        //入力がある場合
        if (this.hori != 0 || this.vert != 0)
        {
            //回避時
            if (this.evasionFlag)
            {
                //回転
                player.Rotation(Mathf.Atan2(this.hori, 0) * Mathf.Rad2Deg);
                //回避
                player.EvasionSub(this.hori, this.vert);
                this.evasionFlag = false;

            }
            //通常時
            else
            {
                if (!player.ReturnEvasion())
                {
                    //回転
                    player.Rotation(Mathf.Atan2(this.hori, this.vert) * Mathf.Rad2Deg);
                    //移動
                    player.Move(Vector3.forward);
                }
            }
        }
        //入力のない場合
        else
        {
            //回避時
            if (this.evasionFlag)
            {
                player.EvasionSub();
                this.evasionFlag = false;
            }
            else
            {
                //止まる
                player.Move(Vector3.zero);
            }
        }

    }
    //-----------------------------------------------------------------------------------
    //右スティック入力の取得
    void GetRightAxis()
    {
        this.hori2 = Input.GetAxis("Horizontal2");
        this.vert2 = Input.GetAxis("Vertical2");
        //回転するように移動させる
        playerCamera.RotateY(this.hori2);
        //高さを変える
        playerCamera.UpDownPosition(this.vert2);
    }
    //-----------------------------------------------------------------------------------
    //各ボタン入力の取得
    void GetButton()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            player.Jump();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            player.Attack();
        }
        if (Input.GetButton("Fire3"))
        {
            player.Charge();
        }
        if(Input.GetButtonUp("Fire3"))
        {
            player.ResetOrReleaseCharge();
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.UltimateAttack();
        }
        if (Input.GetButtonDown("Bumper R"))
        {
            this.evasionFlag = true; 
        }
        if (Input.GetButtonUp("Bumper R"))
        {
            this.evasionFlag = false;
        }
        if (Input.GetButtonDown("Reverse"))
        {
            playerCamera.Reverse();
        }
        if(Input.GetButtonDown("Reset"))
        {
            playerCamera.ResetCamera();
        }
    }
}
