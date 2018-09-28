/*
 *     class:CameraMove.cs
 * copyright:戸軽隆二
 *
 * 概要
 * 視点(カメラ)移動を制御するクラス
*/
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    CameraController cameraController;
    CameraConfig cameraConfig;

    ControllerGetInput input;

    Vector2 move;

    Transform cameraObj;
    Transform parent;

    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public CameraMove(CameraController controller, CameraConfig config, GameObject obj){
        cameraController = controller;
        cameraConfig = config;
        cameraObj = obj.transform;
        parent = obj.transform.parent;

        input = new ControllerGetInput();

        move = Vector2.zero;
        move.y = 0.6f;
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    public void Update()
    {
        // 入力された値の計算
        float frame = Time.deltaTime * (cameraConfig.speed / 100);
        Vector3 ivec = input.GetRStick();
        float x = ivec.x * frame;
        float y = ivec.z * frame;
        // 入力されていない時は処理しない
        //if(x == 0 && y == 0) return;

        move += new Vector2(x, y);

        // 値の制限
        move.y = Mathf.Clamp(move.y, -0.3f + 0.5f, 0.3f + 0.5f);

        // 球面座標系変換
        //Vector3 vec = cameraObj.position;
        Vector3 vec;
        vec.x = cameraConfig.range * Mathf.Sin( move.y * Mathf.PI) * Mathf.Cos(move.x * Mathf.PI);
        vec.y = -cameraConfig.range * Mathf.Cos(move.y * Mathf.PI);
        vec.z = -cameraConfig.range * Mathf.Sin( move.y * Mathf.PI) * Mathf.Sin(move.x * Mathf.PI);
        // 座標の更新
        cameraObj.position = vec + parent.position + cameraConfig.posAdjust;
        //---------------------------------------------
        // 向いている方向(進む方向の座標)を取得
        vec = (parent.position - (cameraObj.position - cameraConfig.posAdjust));
        vec.y = 0;
        float max = Mathf.Abs(vec.x) + Mathf.Abs(vec.z);
        vec = new Vector3(
            vec.x / max,
            0,
            vec.z / max
        );
        //cameraConfig.forwardMove = vec * Time.deltaTime * 10;
        cameraConfig.forwardMove = vec;

        // プレイヤーの方を向く
        cameraObj.LookAt(parent.position + cameraConfig.lookAdjust);
    }   
}
