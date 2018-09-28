using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : ControllerGetInput {

    GameObject player;
    CameraConfig cameraConfig;
    ControllerGetInput input;

    //===============================================================================
    // コンストラクタ
    //===============================================================================
    public PlayerMove(GameObject obj, CameraConfig config)
    {
        player = obj;
        cameraConfig = config;
        input = new ControllerGetInput();
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    public void Update()
    {
        Vector3 it = input.GetLStick();
        //Vector3 vector = new Vector3(
        //    cameraController.forwardMove.x * it.x,
        //    0,
        //    cameraController.forwardMove.z * it.z
        //);
        Vector3 vector = cameraConfig.forwardMove * (-it.z);
        player.transform.Translate(vector);
    }
}
