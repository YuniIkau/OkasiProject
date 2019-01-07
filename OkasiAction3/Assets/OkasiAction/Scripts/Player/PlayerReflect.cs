using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：プレイヤ側の各判定処理
//プレイヤがダメージを受けた時の処理
//死亡時の処理
//プレイヤが敵を攻撃したときの処理
//これらのメソッドを各判定時に呼び出す

public class PlayerReflect : MonoBehaviour
{
    PlayerState playerState;
    PlayerTable player;
    EnemyTable enemy;
    HPSystem hPSystem;
    void Start()
    {
        playerState = GetComponent<PlayerState>();
        player = Resources.Load("PlayerTable") as PlayerTable;
        enemy = Resources.Load("EnemyTable") as EnemyTable;
        hPSystem = GameObject.FindGameObjectWithTag("HP").GetComponent<HPSystem>();
    }
    //プレイヤの被ダメージ処理
    public void PlayerThisDamage(string enemyType)
    {
        if (playerState.hP > 0)
        {
            //無敵時間中は攻撃を受け付けない
            if (playerState.unHitTime > 0)
            {
                return;
            }
            float save = 0;
            //引数渡されたtag名でだれからの攻撃かを判断
            switch (enemyType)
            {
                case "Normal_Ant":
                    playerState.hP = Mathf.Max(playerState.hP - enemy.normalAttack, 0);
                    save = playerState.hP + enemy.normalAttack;
                    break;
                case "Armor_Ant":
                    playerState.hP = Mathf.Max(playerState.hP - enemy.armorAttack, 0);
                    save = playerState.hP + enemy.armorAttack;
                    break;
                case "Shogun_Ant":
                    playerState.hP = Mathf.Max(playerState.hP - enemy.shogunAttack, 0);
                    save = playerState.hP + enemy.shogunAttack;
                    break;
                case "Thorn_Ant":
                    playerState.hP = Mathf.Max(playerState.hP - enemy.thornAttack, 0);
                    save = playerState.hP + enemy.thornAttack;
                    break;
            }
            Debug.Log(playerState.hP);
            hPSystem.Renovation(save);
        }
        if (playerState.hP <= 0)
        {
            //死亡関数
            this.gameObject.GetComponent<Player>().Death();
            return;
        }
        playerState.unHitTime = player.unHitTime;
    }

    //プレイヤが敵を攻撃したら
    public void EnemyAttack()
    {
        if (playerState.sP < player.maxSP)
        {
            playerState.sP += player.addSP;
        }
        //敵側にあるダメージを与えるメソッドの呼び出し
    }

    //アイテム処理
    public void GetItem(ItemGet.ItemType itemType)
    {
        //アイテムの種類によって処理を変える
        switch(itemType)
        {
            //HP上限UP
            case ItemGet.ItemType.HPUP:
                if (playerState.maxHP == player.stageMaxHP0)
                {
                    playerState.maxHP = player.stageMaxHP1;
                }
                else if(playerState.maxHP == player.stageMaxHP1)
                {
                    playerState.maxHP = player.stageMaxHP2;
                }
                else if (playerState.maxHP == player.stageMaxHP2)
                {
                    playerState.maxHP = player.stageMaxHP3;
                }
                Debug.Log("HpUp! " + playerState.maxHP);
                hPSystem.Renovation();
                break;
                //Atack上昇
            case ItemGet.ItemType.AttackUP:
                if (playerState.attack == player.stageAttack0)
                {
                    playerState.attack = player.stageAttack1;
                }
                else if (playerState.attack == player.stageAttack1)
                {
                    playerState.attack = player.stageAttack2;
                }
                else if (playerState.attack == player.stageAttack2)
                {
                    playerState.attack = player.stageAttack3;
                }
                Debug.Log("AtaackUP! " + playerState.attack);
                break;
                //Speed上昇
            case ItemGet.ItemType.SpeedUP:
                if (playerState.speed == player.stageSpeed0)
                {
                    playerState.speed = player.stageSpeed1;
                }
                else if (playerState.speed == player.stageSpeed1)
                {
                    playerState.speed = player.stageSpeed2;
                }
                else if (playerState.speed == player.stageSpeed2)
                {
                    playerState.speed = player.stageSpeed3;
                }
                Debug.Log("SpeedUp! " + playerState.speed);
                break;
                //HP回復
            case ItemGet.ItemType.Recovery:
                playerState.hP += player.recoveryPoint;
                playerState.hP = playerState.hP > playerState.maxHP ? playerState.maxHP : playerState.hP;
                hPSystem.Renovation();
                Debug.Log("Recovery! " + (playerState.hP - player.recoveryPoint) + "/" + playerState.hP);
                break;
            default:
                Debug.Log("未実装！");
                break;
        }
    }
}
