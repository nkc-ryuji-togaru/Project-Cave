/*
 *     class:PlayerController.cs
 * copyright:戸軽隆二
 *
 * 概要
 *
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    MoveTurn moveTurn;

    //===============================================================================
    // 初期化
    //===============================================================================
    void Start()
    {
        moveTurn = new MoveTurn(gameObject);
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    void Update()
    {
        //moveTurn.Update(Vector3.forward);
    }
}
