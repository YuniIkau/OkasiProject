using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMoveTest : MonoBehaviour
{
    SceneMove sceneMove;
    // Use this for initialization
    void Start()
    {
        sceneMove = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            sceneMove.SceneNext();
        }
    }
}
