/*
 *     class:MoveTurn.cs
 * copyright:戸軽隆二
 *
 * 概要
 *
*/
using UnityEngine;
using System.Collections;

public class MoveTurn : MonoBehaviour
{
    GameObject character;

    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public MoveTurn(GameObject obj)
    {
        character = obj;
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    public void Update(/*Vector3 direction*/)
    {
        //Vector3 v = character.transform.position;
        //Vector2 myPos = new Vector2(v.x, v.z);
        //v = character.transform.position + direction;
        //Vector2 gorlPos = new Vector2(v.x, v.z);


    }
}
