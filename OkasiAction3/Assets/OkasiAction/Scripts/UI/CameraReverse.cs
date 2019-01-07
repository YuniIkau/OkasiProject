using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//制作者：中島
//内容：カメラ操作反転を知らせるUI

public class CameraReverse : MonoBehaviour
{
    //Imageクラス
    Image image;
    //Colorクラス
    static Color afterColor; 

    void Start()
    {
        this.image = this.gameObject.GetComponent<Image>();
        afterColor = this.image.color;
    }

    void Update()
    {
        this.FadeOut();
    }
    //-----------------------------------------------------------------------------------
    //フェードアウト
    void FadeOut()
    {
        if (afterColor.a > 0)
        {
            afterColor.a -= Time.deltaTime;
        }
        else
        {
            afterColor.a = 0;
        }
        this.image.color = afterColor;
    }

    public static void Set()
    {
        afterColor.a = 1;
    }
}
