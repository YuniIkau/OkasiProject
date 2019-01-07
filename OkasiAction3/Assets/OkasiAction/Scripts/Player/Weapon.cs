using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：中島
//内容：武器の動きを制御する（仮）

public class Weapon : MonoBehaviour
{
    //当たり判定
    BoxCollider hitRange;
    //最初の座標を保存
    SPSystem sPSystem;
    Player player;
    

    void Awake()
    {
        this.hitRange = this.gameObject.GetComponent<BoxCollider>();
        sPSystem = GameObject.FindGameObjectWithTag("SP").GetComponent<SPSystem>();
        player = this.gameObject.GetComponentInParent<Player>();
    }
    void Update()
    {
        //あたり判定がある場合
        if (this.hitRange.enabled)
        {
            if (player.ReturnAttack())
            {
                this.hitRange.enabled = false;
            }
        }
    }
    //あたり判定を出現
    public void Effectiveness()
    {
        this.hitRange.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        //コライダーが当たったのが敵だったら
        switch(other.tag)
        {
            case "Normal_Ant":
            case "Thorn_Ant":
            case "Armor_Ant":
            case "Shogun_Ant":
                //ダメージを与える
                other.GetComponent<EnemyReflect>().EnemyThisDamage();
                sPSystem.SPChage();
                break;
            default:
                break;
        }
    }
}
