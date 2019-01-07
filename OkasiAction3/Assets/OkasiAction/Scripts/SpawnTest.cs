using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：プレイヤの位置によって敵を生成する処理のテスト

public class SpawnTest : MonoBehaviour
{
    ItemFactory itemFactory;
    EnemyFactory enemyFactory;
    PlayerFactory playerFactory;
    EffectFactory effectFactory;

    [SerializeField]
    private int spawnNum;
    [SerializeField]
    private Vector2 randPosMin;
    [SerializeField]
    private Vector2 randPosMax;
    [SerializeField]
    private enum CreateType
    {
        Normal_Ant,
        Armor_Ant,
        Shogun_Ant,
        Thorn_Ant,
        Mair
    }
    [SerializeField]
    private CreateType createType;
    [SerializeField]
    private enum ItemType
    {
        None,
        HPUP,
        AttackUP,
        SpeedUP,
        Recovery
    }
    [SerializeField]
    private ItemType itemtype;
    void Start()
    {
        itemFactory = GameObject.FindGameObjectWithTag("Factory").GetComponent<ItemFactory>();
        enemyFactory = GameObject.FindGameObjectWithTag("Factory").GetComponent<EnemyFactory>();
        playerFactory = GameObject.FindGameObjectWithTag("Factory").GetComponent<PlayerFactory>();
        effectFactory = GameObject.FindGameObjectWithTag("Factory").GetComponent<EffectFactory>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //オブジェクトの座標
            for (int i = 0; i < spawnNum; ++i)
            {
                float x = Random.Range(randPosMin.x, randPosMax.x);
                float z = Random.Range(randPosMin.y, randPosMax.y);
                enemyFactory.Create(this.createType.ToString(), (int)this.itemtype, this.transform.position + new Vector3(x, 0, z), new Quaternion(0, 0, 0, 1));
            }
            Destroy(this.gameObject);
        }
    }
}
