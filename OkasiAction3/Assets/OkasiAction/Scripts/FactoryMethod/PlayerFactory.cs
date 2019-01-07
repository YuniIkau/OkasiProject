using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：プレイヤの生成(プレイヤは単一なので使わないかも)

public class PlayerFactory : Factory
{
    public override void Create(string createType, Transform transform)
    {
        GameObject obj = (GameObject)Resources.Load("Clair");
        Instantiate(obj, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
    }       
}
