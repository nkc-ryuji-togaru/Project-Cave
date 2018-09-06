/*
 *     class:TitleOOText.cs
 * copyright:戸軽隆二
 *
 * 概要
 * TitleOnlyOnceSceneのみで使用
 * テキストをアニメーションのタイミングで変更するクラス
*/
using UnityEngine;
using UnityEngine.UI;

public class TitleOOText : MonoBehaviour {


    // 変更したいテキスト
    public string text1, text2;
    //----------------------------------------------------
    // テキストを変更する関数
    public void Text1Change(){
        gameObject.GetComponent<Text>().text = text1;
    }

    public void Text2Change(){
        gameObject.GetComponent<Text>().text = text2;
    }

}