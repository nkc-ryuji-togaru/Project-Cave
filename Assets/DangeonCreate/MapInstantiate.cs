/*
 *     class:MapInstantiate.cs
 * copyright:戸軽隆二
 *
 * 概要
 * ２次元配列の情報を元にダンジョンのモデルを生成するクラス
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstantiate : MonoBehaviour {


    int[,] map = new int[5,5]{
        {0,0,0,0,0},
        {0,0,0,0,0},
        {0,0,0,0,0},
        {0,0,0,0,0},
        {0,0,0,0,0}
    };

	void Start () {
        int ylength = map.GetLength(0);
        int xlength = map.GetLength(1);

        for(int y = 0; y < ylength; y++){
            for(int x = 0; x < xlength; x++){
                Vector3 pos = new Vector3(x, y, 0);
            }
        }


    }
	
}