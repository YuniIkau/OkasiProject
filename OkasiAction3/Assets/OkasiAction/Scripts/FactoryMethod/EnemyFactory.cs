using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：敵の生成

public class EnemyFactory : Factory
{
    public enum ItemType
    {
        None,
        HPUP,
        AttackUP,
        SpeedUP,
        Recovery
    }
    public override void Create(string createType, int itemSetType, Vector3 position, Quaternion quaternion)
    {
        GameObject obj = (GameObject)Resources.Load("Enemy/" + createType);
        obj.GetComponent<Enemy>().itemtype = (Enemy.ItemType)itemSetType;
        Instantiate(obj, position, quaternion);
        obj.GetComponent<Enemy>().itemtype = Enemy.ItemType.None;
    }
    public override void Create(string createType, int itemSetType, Transform transform)
    {
        GameObject obj = (GameObject)Resources.Load("Enemy/" + createType);
        obj.GetComponent<Enemy>().itemtype = (Enemy.ItemType)itemSetType;
        Instantiate(obj, transform);
        obj.GetComponent<Enemy>().itemtype = Enemy.ItemType.None;
    }
}
