/*
 *     class:CameraAttention.cs
 * copyright:戸軽隆二
 *
 * 概要
 * 魔法を構える際に少し寄りめになる制御をするクラス
*/
using UnityEngine;
using System.Collections;

public class CameraAttention : MonoBehaviour
{

    CameraConfig cameraConfig;
    ControllerGetInput input;

    Transform cameraObj;
    Transform parent;

    float kariRange;
    Vector3 kariLookAdjust;
    Vector3 kariPosAdjust;

    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public CameraAttention(CameraConfig config, GameObject obj){
        cameraConfig = config;
        input = new ControllerGetInput();
        cameraObj = obj.transform;
        parent = obj.transform.parent;
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    public void Update(){
        //--------------------------------------------------------
        // 注目状態に移行
        if(Input.GetKeyDown(KeyCode.T)){
            cameraConfig.lookMode = CameraConfig.ModeList.ATTENSION;
            // 値の保存
            kariRange = cameraConfig.range;
            kariLookAdjust = cameraConfig.lookAdjust;
            kariPosAdjust = cameraConfig.posAdjust;
            // 注目状態中の値に変更
            //cameraConfig.range = 2;
            //cameraConfig.lookAdjust = parent.position + (cameraConfig.forwardMove * 1000);
            cameraConfig.posAdjust = cameraObj.right + (cameraObj.up / 2);
        }
        //--------------------------------------------------------
        // 注目状態の終了
        else if(Input.GetKeyUp(KeyCode.T)){
            cameraConfig.lookMode = CameraConfig.ModeList.NORMAL;
            // 値を戻す
            cameraConfig.range = kariRange;
            cameraConfig.lookAdjust = kariLookAdjust;
            cameraConfig.posAdjust = kariPosAdjust;
        }
        //----------------------------------------------------------
        // 注目中
        if(cameraConfig.lookMode == CameraConfig.ModeList.ATTENSION){
            //Vector3 pos = cameraObj.position + cameraConfig.forwardMove;
            ////pos += cameraObj.right + cameraObj.up;
            Vector3 forwardMove = cameraConfig.forwardMove * 10;
            cameraConfig.lookAdjust = parent.position + forwardMove;
        }

    }
}
