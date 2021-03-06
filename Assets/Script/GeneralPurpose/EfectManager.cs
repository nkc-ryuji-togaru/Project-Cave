﻿//================================================================================================================
// EfectManager.cs
// 製作者：戸軽隆二
//================================================================================================================
/* 概要
		Resources/Efectフォルダ内からデータを取得して
		エフェクトを生成する処理
*/
//================================================================================================================
/* バージョン
		戸軽隆二		1.0 クラス生成
		戸軽隆二		2.0 NetworkInstantiate
*/
//================================================================================================================
using UnityEngine;
using System.Collections;

public class EfectManager : MonoBehaviour {

	// 取得したエフェクトデータの配列
	static GameObject[] efects = new GameObject[0];

	//============================================================================================================-
	/// <summary>
	/// エフェクトを生成する関数
	/// </summary>
	/// <param name="pos">生成する座標</param>
	/// <param name="name">生成するエフェクトの名前</param>
	/// <param name="network">ネットワーク接続判定</param>
	/// <returns></returns>
	//============================================================================================================-
	public static GameObject Instantiate(Vector3 pos, string name, bool network) {
		// 一度だけエフェクトデータを取得する
		if (efects.Length <= 0) Init();
		//-------------------------------------------------------------------------------------
		// 名前と一致するエフェクトデータを検索して一致したものを返す
		foreach (GameObject efect in efects) {
			if (efect.name == name) {
				GameObject obj = null;
				//--------------------------------------------------------------------------
				// ネットワーク接続に応じて生成方法を変更
				if(network)
					obj = (GameObject)Network.Instantiate(efect, pos, efect.transform.rotation, 1);
				else
					obj = (GameObject)Instantiate(efect, pos, efect.transform.rotation);
				obj.name = efect.name;
				return obj;
			}
		}

		// エラー処理
		Debug.Log("エラー。Efectの名前が一致しません。:" + name);
		return null;
	}
	//============================================================================================================
	// 初期化　エフェクトデータを取得
	//============================================================================================================
	public static void Init() {
		efects = Resources.LoadAll<GameObject>("Efect");
	}
}
