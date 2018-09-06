/*
 *     class:CameraController.cs
 * copyright:戸軽隆二
 *
 * 概要
 * プレイヤーのカメラ周りの処理
*/
using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    // プレイヤーとカメラとの距離
    [SerializeField]
    [Range(1.0f, 10.0f)]
    float range;
    // カメラ移動の速さ
    [SerializeField]
    [Range(0.0f, 100.0f)]
    float speed = 50;
    // カメラの角度調整
    [SerializeField]
    Vector3 adjust;

    // プレイヤー
    Transform parent;
    // カメラの座標(と初期座標)
    Vector3 cameraPos;
    Vector3 startPos;
    // コントローラーの移動量
    Vector2 move;

    bool flg = false;
    float kariRange;

    CameraMove cameraMove;
    CameraAttention cameraAttention;

    //===============================================================================
    // 初期化
    //===============================================================================
    void Start()
    {
        parent = transform.parent;

        cameraPos = transform.position;
        startPos = transform.position;

        move = Vector3.zero;
        move.y = 0.6f;

        cameraMove = new CameraMove();
        cameraAttention = new CameraAttention();
    }
    //===============================================================================
    // 毎フレーム更新
    //===============================================================================
    void Update(){
        // 入力された値の計算
        float frame = Time.deltaTime * (speed / 100);
        float x = Input.GetAxis("Horizontal") * frame;
        float y = Input.GetAxis("Vertical") * frame;
        // 入力されていない時は処理しない
        //if(x == 0 && y == 0) return;

        move += new Vector2(x, y);

        // 値の制限
        move.y = Mathf.Clamp(move.y, -0.3f + 0.5f, 0.3f + 0.5f);

        // 球面座標系変換
        cameraPos.x = range * Mathf.Sin( move.y * Mathf.PI) * Mathf.Cos(move.x * Mathf.PI);
        cameraPos.y = -range * Mathf.Cos(move.y * Mathf.PI);
        cameraPos.z = -range * Mathf.Sin( move.y * Mathf.PI) * Mathf.Sin(move.x * Mathf.PI);

        // 座標の更新
        transform.position = cameraPos + parent.position;
        // プレイヤーの方を向く
        transform.LookAt(parent.position + adjust);

        //--------------------------------------------------------
        // CameraAttentionのサンプル
        if(Input.GetKeyDown(KeyCode.T)){
            flg = !flg;
            if(flg){
                kariRange = range;
                range = 2;
            }
            else{
                range = kariRange;
            }
        }
    }
}
