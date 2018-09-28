/*
 *     class:PlayerStatus.cs
 * copyright:戸軽隆二
 *
 * 概要
 * プレイヤーの体力やその他設定などを保持するクラス
*/
using UnityEngine;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour
{
    int _hp;
    int _exp;
    int _speed;
    public int speed{ get { return _speed;} }

    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public PlayerStatus()
    {
        _speed = 10;
    }
}
