using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中島
//内容：プレイヤーに追従するカメラの動きを制御する

public class PlayerCamera : MonoBehaviour
{
    //X軸の回転率
    float angleX;
    //Y軸の回転率
    float angleY;
    //カメラの高さ
    float height;
    
    //ターゲット
    GameObject target;
    //ターゲットとの距離ベクトル
    Vector3 distVec;
    //自身の座標
    Vector3 pos;
    //反転用
    float reverseValue;
    //カメラに近づく割合
    float approachRate;

    //カメラとの基本距離
    float dist;     //★
    

    void Start()
    {
        this.angleX = 0;
        this.height = 1;
        this.dist = 3;
        this.approachRate = 8;

        try
        {
            this.target = GameObject.FindGameObjectWithTag("Player");
        }
        catch
        {
            //エラーメッセージ
            Debug.LogError("Playerタグを持ったオブジェクトが検出できませんでした。(PlayerCamera.cs)");
        }
        this.distVec = new Vector3(Mathf.Sin(this.angleY) * this.dist, this.height, -Mathf.Cos(this.angleY) * this.dist);
        this.pos = target.transform.position + this.distVec;
        this.gameObject.transform.position = this.pos;
        this.reverseValue = 1;
    }

    void Update()
    {
        this.UpdatePostion();
    }
    //------------------------------------------------------------------------------
    //座標の更新
    void UpdatePostion()
    {
        this.pos = target.transform.position + this.distVec;
        Vector3 vector = new Vector3(this.gameObject.transform.position.x, target.transform.position.y+this.height, this.gameObject.transform.position.z);
        //ターゲットとの距離を保つ
        this.gameObject.transform.position = Vector3.Lerp(vector, this.pos, this.approachRate * Time.deltaTime);
    }
    //------------------------------------------------------------------------------
    //回転するように移動する
    public void RotateY(float hori)
    {
        var camera = Resources.Load("CameraTable") as CameraTable;
        //角度の更新
        this.angleY += hori * camera.addAngle * Time.deltaTime * this.reverseValue;
        this.transform.rotation = Quaternion.Euler(this.angleX * Mathf.Rad2Deg, -this.angleY * Mathf.Rad2Deg, 0);
        //回転にあわせて距離ベクトルを更新する
        this.distVec = new Vector3(Mathf.Sin(this.angleY) * this.dist, this.height, -Mathf.Cos(this.angleY) * this.dist);
        //入力がある場合
        if (hori != 0)
        {
            this.approachRate = 15;
        }
        else
        {
            this.approachRate = 8;
        }
    }
    //------------------------------------------------------------------------------
    //上下に移動して高さを変更する
    public void UpDownPosition(float vert)
    {
        var camera = Resources.Load("CameraTable") as CameraTable;
        //高さに合わせて角度調整
        if (camera.minHeight < this.height && this.height < camera.maxHeight)
        {
            this.angleX += vert * Time.deltaTime;
            this.angleX = Mathf.Max(this.angleX, 0);
        }
        //高さの加算
        this.height += vert * camera.addHeight * Time.deltaTime;
        //下限より下回らないようにする
        this.height = Mathf.Max(this.height, camera.minHeight);
        //上限より上回らないようにする
        this.height = Mathf.Min(this.height, camera.maxHeight);
    }
    //------------------------------------------------------------------------------
    //左右の操作反転
    public void Reverse()
    {
        CameraReverse.Set();
        this.reverseValue *= -1;
    }
    //------------------------------------------------------------------------------
    //カメラの位置リセット(未実装)
    //void ResetPosition()
    //{

    //}
    //------------------------------------------------------------------------------
    //カメラの向きリセット
    void  ResetRotation()
    {
        var camera = Resources.Load("CameraTable") as CameraTable;
        this.angleY = -target.transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
        this.transform.rotation = Quaternion.Euler(this.angleX * Mathf.Rad2Deg, -this.angleY * Mathf.Rad2Deg, 0);
        //回転にあわせて距離ベクトルを更新する
        this.distVec = new Vector3(Mathf.Sin(this.angleY) * this.dist, this.height, -Mathf.Cos(this.angleY) * this.dist);
    }
    //------------------------------------------------------------------------------
    //カメラリセット
    public void ResetCamera()
    {
        this.ResetRotation();
    }
}
