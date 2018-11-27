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
    // カメラ設定の取得
    CameraConfig cameraConfig;
    // 入出力クラス
    ControllerGetInput input;

    Transform cameraObj;
    Transform parent;

    float kariRange;
    float nowRange;
    float rangeDis;
    float kariFrame;
    bool modeChange;
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
        nowRange = config.range;
        kariFrame = -1;
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
            nowRange = 2;
            rangeDis = Mathf.Abs(kariRange - nowRange);
            //cameraConfig.range = 2;
            //cameraConfig.lookAdjust = parent.position + (cameraConfig.forwardMove * 1000);
            cameraConfig.posAdjust = cameraObj.right + (cameraObj.up / 2);
            modeChange = true;
        }
        //--------------------------------------------------------
        // 注目状態の終了
        else if(Input.GetKeyUp(KeyCode.T)){
            cameraConfig.lookMode = CameraConfig.ModeList.NORMAL;
            // 値を戻す
            //cameraConfig.range = kariRange;
            nowRange = kariRange;
            rangeDis = Mathf.Abs(kariRange - nowRange);
            cameraConfig.lookAdjust = kariLookAdjust;
            cameraConfig.posAdjust = kariPosAdjust;

            kariFrame = -1;

            modeChange = true;
        }
        //----------------------------------------------------------
        // 注目中
        if(cameraConfig.lookMode == CameraConfig.ModeList.ATTENSION){
            //Vector3 pos = cameraObj.position + cameraConfig.forwardMove;
            ////pos += cameraObj.right + cameraObj.up;
            Vector3 forwardMove = cameraConfig.forwardMove * 10;
            cameraConfig.lookAdjust = parent.position + forwardMove;

            // 緩急をつけて距離を縮める
            if(nowRange < cameraConfig.range){
                kariFrame += Time.deltaTime * 3;
                float ft = rangeDis * ( kariFrame * kariFrame );
                cameraConfig.range = kariRange - (rangeDis - ft);

                if(kariFrame > 0){
                    kariFrame = -1;
                    cameraConfig.range = nowRange;
                }
            }
        }
        //---------------------------------------------------------
        // モード切り替え時のカメラの移動
        //if(modeChange){
        //    // 緩急をつけて距離を縮める
        //    if(nowRange < cameraConfig.range){
        //        kariFrame += Time.deltaTime * 3;
        //        float ft = rangeDis * ( kariFrame * kariFrame );
        //        cameraConfig.range = kariRange - (rangeDis - ft);

        //        if(kariFrame > 0){
        //            kariFrame = -1;
        //            cameraConfig.range = kariRange;
        //            modeChange = false;
        //        }
        //    }

        //}

    }
}
