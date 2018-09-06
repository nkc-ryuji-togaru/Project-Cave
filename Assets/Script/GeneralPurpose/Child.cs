using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Child {
	//======================================================================================
	/// <summary>
	/// 子供関係にある全ての階層のオブジェクトを取得
	/// </summary>
	/// <param name="obj">子供関係を取得したいオブジェクト</param>
	/// <returns></returns>
	//======================================================================================
	public static GameObject[] GetAllChildren(this GameObject obj) {
		GameObject[] allChildren = new GameObject[0];
		GetAllChild(obj, ref allChildren);
		return allChildren;
	}
	static void GetAllChild(GameObject obj, ref GameObject[] allChildren) {
		Transform children = obj.GetComponentInChildren<Transform>();
		//子要素がいなければ終了
		if (children.childCount == 0) {
			return;
		}
		foreach (Transform ob in children) {
			allChildren = allChildren.Add(ob.gameObject);
			GetAllChild(ob.gameObject, ref allChildren);
		}
	}
	//======================================================================================
	/// <summary>
	/// 子供関係に１つ下の階層のオブジェクトを取得
	/// </summary>
	/// <param name="obj">子供関係を取得したいオブジェクト</param>
	/// <returns></returns>
	//======================================================================================
	public static GameObject[] GetChildren(this GameObject obj) {
		GameObject[] allChildren = new GameObject[0];
		GetChild(obj, ref allChildren);
		return allChildren;
	}
	static void GetChild(GameObject obj, ref GameObject[] children) {
		Transform child = obj.GetComponentInChildren<Transform>();

		foreach (Transform ob in child) {
			children = children.Add(ob.gameObject);
			//GetAllChild(ob.gameObject, ref children);
		}
	}
}