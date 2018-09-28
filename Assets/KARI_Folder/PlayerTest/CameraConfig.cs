/*
 *     class:CameraConfig.cs
 * copyright:戸軽隆二
 *
 * 概要
 * カメラの設定を管理しているクラス
*/
using UnityEngine;
using System.Collections;

public class CameraConfig : MonoBehaviour
{
    // カメラの移動速度
    [Range(0.0f, 100.0f)]
    public float speed = 50.0f;
    // プレイヤーとカメラの距離
    [Range(0.0f, 10.0f)]
    public float range = 3.0f;
    // 視点の中心からの位置調整用変数
    public Vector3 lookAdjust;
    public Vector3 posAdjust;
    // 注目モードのフラグ
    public enum ModeList{
        NORMAL, ATTENSION, MENU
    };
    public ModeList lookMode;

    public Vector3 forwardMove;

    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public CameraConfig(){
        lookMode = ModeList.NORMAL;
    }
}
