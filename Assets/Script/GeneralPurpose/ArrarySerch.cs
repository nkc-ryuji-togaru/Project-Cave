//================================================================================================================
// ArryaSerch.cs
// 製作者：戸軽隆二
//================================================================================================================
/* 概要
		配列に関してのクラス
		以下の処理を実装している
		・配列の中の特定の値の数を検索
		・配列の中の特定の値の取得
*/
//================================================================================================================
/* バージョン
		2017/05/12 戸軽隆二			1.0 クラス生成
		2017/06/28 戸軽隆二			1.1 AudioClip, GameObject, Objectに対応
										List（動的配列）に対応
*/
//================================================================================================================
using UnityEngine;
using System.Collections.Generic;

public static class ArraySerch {
	//================================================================================================================
	// 配列の中の特定の値がいくつあるかを検索する関数郡(arrayバージョン)
	//================================================================================================================
	//-----------------------------------------------------------
	// boolの配列用
	public static int AllCount(this bool[] array, bool word) {
		int count = 0;
		foreach (bool flg in array) {
			if (flg == word)
				count++;
		}
		return count;
	}
	//-----------------------------------------------------------
	// intの配列用
	public static int AllCount(this int[] array, int word) {
		int count = 0;
		foreach (int it in array) {
			if (it == word)
				count++;
		}
		return count;
	}
	//-----------------------------------------------------------
	// floatの配列用
	public static int AllCount(this float[] array, float word) {
		int count = 0;
		foreach (float flt in array) {
			if (flt == word)
				count++;
		}
		return count;
	}
	//-----------------------------------------------------------
	// charの配列用
	public static int AllCount(this char[] array, char word) {
		int count = 0;
		foreach (char cha in array) {
			if (cha == word)
				count++;
		}
		return count;
	}
	//-------------------------------------------------------------------
	// GameObjectの配列用（名前で検索）
	public static int AllCount(this GameObject[] objects, string name) {
		int count = 0;
		foreach (GameObject obj in objects) {
			if (obj.name == name)
				count++;
		}
		return count;
	}
	// GameObjectの配列用（オブジェクトで検索）
	public static int AllCount(this GameObject[] objects, GameObject ob) {
		int count = 0;
		foreach (GameObject obj in objects) {
			if (obj == ob)
				count++;
		}
		return count;
	}
	//----------------------------------------------------------------------
	// Objectの配列用（名前で検索）
	public static int AllCount(this Object[] objects, string name) {
		int count = 0;
		foreach (GameObject obj in objects) {
			if (obj.name == name)
				count++;
		}
		return count;
	}
	// Objectの配列用（オブジェクトで検索）
	public static int AllCount(this Object[] objects, Object ob) {
		int count = 0;
		foreach (GameObject obj in objects) {
			if (obj == ob)
				count++;
		}
		return count;
	}
	//================================================================================================================
	// 配列の中の特定の値がいくつあるかを検索する関数郡(Listバージョン)
	//================================================================================================================
	//-----------------------------------------------------------
	// boolの配列用
	public static int AllCount(this List<bool> array, bool word) {
		int count = 0;
		foreach (bool flg in array) {
			if (flg == word)
				count++;
		}
		return count;
	}
	//-----------------------------------------------------------
	// intの配列用
	public static int AllCount(this List<int> array, int word) {
		int count = 0;
		foreach (int it in array) {
			if (it == word)
				count++;
		}
		return count;
	}
	//-----------------------------------------------------------
	// floatの配列用
	public static int AllCount(this List<float> array, float word) {
		int count = 0;
		foreach (float flt in array) {
			if (flt == word)
				count++;
		}
		return count;
	}
	//-----------------------------------------------------------
	// charの配列用
	public static int AllCount(this List<char> array, char word) {
		int count = 0;
		foreach (char cha in array) {
			if (cha == word)
				count++;
		}
		return count;
	}
	//-------------------------------------------------------------------
	// GameObjectの配列用
	public static int AllCount(this List<GameObject> objects, string name) {
		int count = 0;
		foreach (GameObject obj in objects) {
			if (obj.name == name)
				count++;
		}
		return count;
	}
	//----------------------------------------------------------------------
	// Objectの配列用
	public static int AllCount(this List<object> objects, string name) {
		int count = 0;
		foreach (GameObject obj in objects) {
			if (obj.name == name)
				count++;
		}
		return count;
	}
	//================================================================================================================
	// 配列の中の特定の値を取得する関数群
	//================================================================================================================
	//--------------------------------------------------------------------------
	// AudioClipの配列用
	public static AudioClip GetAudioClip(this AudioClip[] list, string name) {
		AudioClip clip = new AudioClip();
		foreach (AudioClip cp in list) {
			if (cp.name == name) {
				clip = cp;
				break;
			}
		}
		return clip;
	}
	//--------------------------------------------------------------------------
	// GameObjectの配列用
	public static GameObject GetObject(this GameObject[] list, string name) {
		GameObject obj = null;
		foreach (GameObject ob in list) {
			if (ob.name == name) {
				obj = ob;
				break;
			}
		}
		return obj;
	}
	//--------------------------------------------------------------------------
	// Objectの配列用(GameObjectに変換)
	public static GameObject GetObject(this Object[] list, string name) {
		GameObject obj = null;
		foreach (GameObject ob in list) {
			if (ob.name == name) {
				obj = ob;
				break;
			}
		}
		return obj;
	}
	//================================================================================================================
	// 配列の中にnullがあったら前に詰める
	//================================================================================================================
	public static List<GameObject> NullClear(this List<GameObject> list) {
		List<GameObject> nowlist = new List<GameObject>();
		foreach (GameObject obj in list) {
			if (obj != null) {
				nowlist.Add(obj);
			}
		}
		return nowlist;
	}
	//================================================================================================================
	// 配列の後ろに要素を追加する(List未対応)
	//================================================================================================================
	public static Type[] Add<Type>(this Type[] list , Type cla) {
		Type[] array = new Type[list.Length + 1];
		array[array.Length - 1] = cla;

		int count = 0;
		foreach (Type type in list) {
			array[count] = type;
			count++;
		}
		return array;
	}
	//================================================================================================================
	// 配列内のnullを除いて前詰めする
	//================================================================================================================
	public static Type[] NullClear<Type>(this Type[] list) {
		Type[] array = new Type[list.Length];
		int count = 0;
		foreach (Type type in list) {
			if (type != null) {
				array[count] = type;
				count++;
			}
		}
		//-------------------------------------------
		// 配列内のnullを削除してサイズをその分詰める
		Type[] nowlist = new Type[count];
		for (int i = 0; i < count; i++) {
			nowlist[i] = array[i];
		}
		return nowlist;
	}
}