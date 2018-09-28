/*
 *     class:CameraController.cs
 * copyright:戸軽隆二
 *
 * 概要
 * プレイヤーのカメラ周りの処理
*/
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    CameraConfig cameraConfig;
    ControllerGetInput input;

    CameraMove cameraMove;
    CameraAttention cameraAttention;

    // CameraAttentionのサンプル
    bool flg = false;
    float kariRange;


    // KARI
    Vector3 kariAdjust;

    //===============================================================================
    // 初期化
    //===============================================================================
    void Start()
    {
        cameraConfig = gameObject.GetComponent<CameraConfig>();
        input = new ControllerGetInput();

        cameraMove = new CameraMove(this, cameraConfig, gameObject);
        cameraAttention = new CameraAttention(cameraConfig, gameObject);
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    void Update(){
        //--------------------------------------------------------
        //// CameraAttentionのサンプル
        //if(Input.GetKeyDown(KeyCode.T)){
        //    flg = !flg;
        //    if(flg){
        //        kariRange = range;
        //        kariAdjust = adjust;
        //        range = 2;
        //    }
        //    else{
        //        range = kariRange;
        //        adjust = kariAdjust;
        //    }
        //}
        //if(flg){
        //    adjust = cameraPos + forwardMove;
        //}

        cameraMove.Update();
        cameraAttention.Update();

        //if(Input.GetKeyDown(KeyCode.Y) ){
        //    string str = "あいうえお！！！あいうえお！！！あいうえお！！！あいうえお！！！あいうえお！！！";
        //    MessageManager.Instance.Create(str, "Iphone", 32);
        //}
    }
}
