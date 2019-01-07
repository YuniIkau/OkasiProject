using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：アイテムの生成

public class ItemFactory : Factory
{
    public enum CreateType { None, HPUP, AttackUP, SpeedUP, Recovery, }
    public override void Create(string createType, Vector3 position)
    {
        if(createType=="None")
        {
            Debug.Log("アイテムのセットがされていないよ");
            return;
        }
        GameObject obj = (GameObject)Resources.Load("Item/" + createType);
        Instantiate(obj, position, Quaternion.identity);
    }
}
