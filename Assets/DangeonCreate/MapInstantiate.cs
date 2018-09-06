/*
 *     class:MapInstantiate.cs
 * copyright:戸軽隆二
 *
 * 概要
 * ２次元配列の情報を元にダンジョンのモデルを生成するクラス
*/
using System;
using System.Collections.Generic;

using UnityEngine;

public class MapInstantiate : MonoBehaviour {

    // マップ自動生成のアルゴリズム
    RandomMapGenerate randomMapGenerate;

	void Start () {
        MapCreate();
    }

    void MapCreate(){
        randomMapGenerate = new RandomMapGenerate();
    }
	
}