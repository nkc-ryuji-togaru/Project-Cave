/*
 *     class:EnemyStatus.cs
 * copyright:戸軽隆二
 *
 * 概要
 *
*/
using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour
{
    int hp;
    int exp;
    public enum State{
      PATROL, AREAMOVE, ATTACK 
    };
    public State state;
    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public EnemyStatus(){
        state = State.PATROL;
    }
}
