using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中山
//内容：アイテムとプレイヤーとの接触判定

public class ItemGet : MonoBehaviour
{
    //回転角度
    float angle;
    //プレイヤー情報
    Player player;
    //プレイヤのステータスの取得用クラス
    PlayerReflect playerReflect;
    //アイテムの種類
    public enum ItemType
    {
        None,
        HPUP,
        AttackUP,
        SpeedUP,
        Recovery
    }
    public ItemType itemtype;

    // Use this for initialization
    void Awake()
    {
        angle = 3.0f;
        try
        {
            //プレイヤークラスの取得
            this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
        catch
        {
            //エラーメッセージ
            Debug.LogError("Not Player Error from PlayerController.cs");
        }
        playerReflect = player.GetComponent<PlayerReflect>();
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムを上下に揺らす
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 3) / 8.0f+1, transform.position.z);
        transform.Rotate(0, angle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触しているか
        if (other.gameObject.tag == "Player")
        {
            //自身のアイテムの種類を渡す
            playerReflect.GetItem(this.itemtype);
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
    }
    //アイテムの種類を受け取る
    public void SetType(int type)
    {
        this.itemtype = (ItemType)type;
    }
}
