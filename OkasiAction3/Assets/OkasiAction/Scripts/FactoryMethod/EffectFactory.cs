using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：エフェクトの生成

public class EffectFactory : Factory
{
    public override void Create(string createType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = (GameObject)Resources.Load("Effect/" + createType);
        Instantiate(obj, position, quaternion);
    }
    public override void Create(string createType,Transform transform)
    {
        GameObject obj = (GameObject)Resources.Load("Effect/" + createType);
        Instantiate(obj, transform.position, transform.rotation);
        //obj.SetActive(false);
    }
    public override void Create(string createType, Vector3 position, Quaternion quaternion, Transform parent)
    {
        GameObject obj = (GameObject)Resources.Load("Effect/" + createType);
        Instantiate(obj, position, quaternion, parent);
    }
    public override void Create(string createType, Transform transform, Transform parent)
    {
        GameObject obj = (GameObject)Resources.Load("Effect/" + createType);
        Instantiate(obj, transform, parent);
    }
}