﻿/*
 *     class:PlayerController.cs
 * copyright:戸軽隆二
 *
 * 概要
 *
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    MoveTurn moveTurn;
    PlayerMove playerMove;
    CameraConfig cameraConfig;
    ControllerGetInput input;

    public GameObject camera;

    //===============================================================================
    // 初期化
    //===============================================================================
    void Start()
    {
        input = new ControllerGetInput();

        cameraConfig = camera.GetComponent<CameraConfig>();
        moveTurn = new MoveTurn(gameObject);
        playerMove = new PlayerMove(gameObject, cameraConfig);

    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    void Update()
    {
        playerMove.Update();
    }
}
