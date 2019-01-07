using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：宮内
//内容：MinMapCameraがプレイヤに追従する(座標のみ)

public class MinMapCamera : MonoBehaviour
{
    //追従するプレイヤの選択
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //positionのX,Z座標をプレイヤに指定
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
    }
}
