/*
 *     class:TitleOOInput.cs
 * copyright:戸軽隆二
 *
 * 概要
 * TitleOnlyOnceシーンで使用
 * ボタンの入出力に応じてアニメーションを管理
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleOOInput : ControllerGetInput {

    public GameObject character, waitText, camera, fade, titleText, audio;
    	
	void Update () {
        if(Input.GetKeyDown(KeyCode.A)){
            character.GetComponent<Animator>().SetBool("Start", true);
            fade.GetComponent<Animator>().SetBool("Start", true);
            waitText.GetComponent<Animator>().SetBool("End", true);
            camera.GetComponent<Animator>().SetBool("End", true);
            titleText.GetComponent<Animator>().SetBool("Start", true);
            audio.GetComponent<Animator>().SetBool("End", true);
        }
	}
}
