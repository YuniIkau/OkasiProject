using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：木下
//内容：雑魚アリの自動移動

public partial class Enemy : MonoBehaviour
{
    public void EnemyMove()
    {
        if (!deadFlag)
        {
            Vector3 vec;
            //EnemySearchのほうでフラグを立てる
            //プレイヤーを見つけておらずかつ攻撃していないとき
            if (movetrigger == false && this.GetComponentInChildren<EnemyAttack>().attacktrigger == false)
            {
                moveDist = Vector3.SqrMagnitude(this.transform.position - targetPosition);
                //敵位置との目的地の値がchengeMoveDist以下なら
                if (moveDist < chengeMoveDist)
                {
                    //目的地を再設定
                    targetPosition = GetRandomPosition();
                }
                vec = targetPosition - this.transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotspeed);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            //プレイヤーを見つけていて攻撃していないとき
            else if (movetrigger == true && this.GetComponentInChildren<EnemyAttack>().attacktrigger == false)
            {
                vec = playertr.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotspeed);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                //var y = (float)(Mathf.Sin(Time.time) * 3);
                //playertr.transform.position = new Vector3(0, y, 0);
                //transform.LookAt(playertr.transform);
            }
            else if(this.GetComponentInChildren<EnemyAttack>().attacktrigger)
            {
                if(!damage)
                {
                vec = playertr.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(vec.x, 0, vec.z)), rotspeed);
                }
            }
            //それ以外は止まる
        }
    }
    //ランダムな座標設定
    public Vector3 GetRandomPosition()
    {
        float levelSize = 50f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
}
