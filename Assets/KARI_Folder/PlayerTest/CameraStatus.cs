/*
 *     class:CameraStatus.cs
 * copyright:戸軽隆二
 *
 * 概要
 * カメラの状態を管理するクラス
*/
using UnityEngine;
using System.Collections;

public class CameraStatus : MonoBehaviour
{
    // カメラの角度調整
    Vector3 adjust;
    // プレイヤー
    Transform parent;
    // プレイヤーとの距離
    float range;
    // 視点の移動スピード
    float speed;
    // 状態遷移
    bool attension;
    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public CameraStatus(){
        
    }
}
