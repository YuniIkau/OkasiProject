using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者：中島
//内容：チュートリアルのテキストイメージの表示

public class TutorialUI : UIAnimation
{
    //プレイヤ
    GameObject player;
    //指示UI
    GameObject[] imagesUI;
    //指示UIのイメージ
    Image[] images;
    //切り替え地点の座標
    Vector3[] switchingPoint;
    //現在地点の番号
    int nowPoint;

    void Awake()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.imagesUI = new GameObject[this.gameObject.transform.childCount];
        this.images = new Image[this.gameObject.transform.childCount];
        this.switchingPoint = new Vector3[this.gameObject.transform.childCount];
        //上から順に自身の子オブジェクトを入れる
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
        {
            this.imagesUI[i] = this.gameObject.transform.GetChild(i).gameObject;
            images[i] = this.imagesUI[i].GetComponent<Image>();
            if (i > 0)
            {
                this.imagesUI[i].SetActive(false);
            }
        }
        //とりあえず一つ
        for(int i = 0; i < this.switchingPoint.Length; ++i)
        {
            this.switchingPoint[i].z = (i+1) * 10;
        }
    }
    void Update()
    {
        AlphaMove(this.images[nowPoint], 0.8f, 0.8f, 0, false);
        if (this.nowPoint + 1 < this.switchingPoint.Length)
        {
            if (player.transform.position.z > this.switchingPoint[this.nowPoint].z)
            {
                this.imagesUI[this.nowPoint].SetActive(false);
                this.imagesUI[this.nowPoint + 1].SetActive(true);
                ++this.nowPoint;
            }
        }
        if (player.transform.position.z > this.switchingPoint[this.switchingPoint.Length - 1].z + 10)
        {
            Destroy(this.gameObject);
        }
    }
}
