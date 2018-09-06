//================================================================================================================
// PrefabManager.cs
// 製作者：戸軽隆二
//================================================================================================================
/* 概要
		プレファブの管理をするクラス
		PrefabManager.Instantiate("プレファブの名前", 座標, 角度);
		↑の関数でプレファブを生成する
*/
//================================================================================================================
/* バージョン
		戸軽隆二		1.0 クラス生成
		戸軽隆二		2.0 NetworkInstantiateに対応
*/
//================================================================================================================
using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour {

	// プレファブデータ
	static Object[] prefabs = new GameObject[0];

	//=========================================================================================================================
	/// <summary>
	/// プレファブを生成する関数
	/// </summary>
	/// <param name="name">プレファブの名前</param>
	/// <param name="pos">生成する座標</param>
	/// <param name="rote">生成した後の角度</param>
	/// <param name="network">ネットワークの接続状態</param>
	/// <returns></returns>
	//=========================================================================================================================
	public static GameObject Instantiate(string name, Vector3 pos, Quaternion rote, bool network) {
		// プレファブデータを読み込んで無いときだけ初期化
		if (prefabs.Length <= 0) Init();

		//------------------------------------------------------------------------
		// 名前が一致すればプレファブを生成して返す
		foreach (GameObject prefab in prefabs) {
			if (prefab.name == name) {
				GameObject obj = null;
				if (!network)
					obj = (GameObject)Instantiate(prefab, pos, rote);
				else
					obj = (GameObject)Network.Instantiate(prefab, pos, rote, 1);
				obj.name = prefab.name;
				return obj;
			}
		}

		// 名前が不一致ならnullを返す
		return null;
	}
	//=========================================================================================================================
	/// <summary>
	/// プレファブを生成する関数
	/// </summary>
	/// <param name="name">プレファブの名前</param>
	/// <param name="pos">生成する座標</param>
	/// <param name="network">ネットワークの接続状態</param>
	/// <returns></returns>
	//=========================================================================================================================
	public static GameObject Instantiate(string name, Vector3 pos, bool network) {
		// プレファブデータを読み込んで無いときだけ初期化
		if (prefabs.Length <= 0) Init();

		//------------------------------------------------------------------------
		// 名前が一致すればプレファブを生成して返す
		foreach (GameObject prefab in prefabs) {
			if (prefab.name == name) {
				GameObject obj = null;
				if (!network)
					obj = (GameObject)Instantiate(prefab, pos, prefab.transform.rotation);
				else
					obj = (GameObject)Network.Instantiate(prefab, pos, prefab.transform.rotation, 1);
				obj.name = prefab.name;
				return obj;
			}
		}

		// 名前が不一致ならnullを返す
		return null;
	}
	//=========================================================================================================================
	/// <summary>
	/// プレファブを生成する関数
	/// </summary>
	/// <param name="name">プレファブの名前</param>
	/// <param name="network">ネットワークの接続状態</param>
	/// <returns></returns>
	//=========================================================================================================================
	public static GameObject Instantiate(string name, bool network) {
		// プレファブデータを読み込んで無いときだけ初期化
		if (prefabs.Length <= 0) Init();

		//------------------------------------------------------------------------
		// 名前が一致すればプレファブを生成して返す
		foreach (GameObject prefab in prefabs) {
			if (prefab.name == name) {
				GameObject obj = null;
				if (!network)
					obj = (GameObject)Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
				else
					obj = (GameObject)Network.Instantiate(prefab, prefab.transform.position, prefab.transform.rotation, 1);
				obj.name = prefab.name;
				return obj;
			}
		}

		// 名前が不一致ならnullを返す
		return null;
	}
	//=========================================================================================================================
	// 初期化の処理
	// プレファブデータを読み込む
	//=========================================================================================================================
	public static void Init() {
		prefabs = Resources.LoadAll<GameObject>("Prefab");
	}
}
