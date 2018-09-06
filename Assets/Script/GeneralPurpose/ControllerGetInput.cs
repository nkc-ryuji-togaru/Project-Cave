/*
 *     class:ControllerGetInput.cs
 * copyright:戸軽隆二
 *
 * 概要
 * コントローラーの入出力を検知するクラス
 * 各関数を呼び出しで入出力を判定する
 * 
*/
using UnityEngine;
using System.Collections;

public class ControllerGetInput : MonoBehaviour {

	string GamepadF310 = "Controller (Gamepad F310)";
	string PS4 = "Wireless Controller";
	string Logicool = "Logicool Dual Action";
    string joyPad;

	// ボタンの判定
	bool circle, triangle, square, cross, l1, l2, l3, r1, r2, r3, option;

	// ボタンの名前
	string CIRCLE, TRIANGLE, SQUARE, CROSS, L1, L2, L3, R1, R2, R3, OPTION, HORIZONTAL_L, HORIZONTAL_R, VERTICAL_L, VERTICAL_R;

	//================================================================================================================================
	// コンストラクタ
	// コントローラーの種類に応じて変更
	//================================================================================================================================
	public ControllerGetInput() {
		var joystick = Input.GetJoystickNames();
		foreach (string joyname in joystick) {
			if(joyname.Length > 0) {
				joyPad = joyname;
				break;
			}
		}
		//-------------------------------------
		// PS4コントローラー
		if (joyPad == PS4) {
			CIRCLE = "Circle";
			TRIANGLE = "Triangle";
			SQUARE = "Square";
			CROSS = "Cross";
			L1 = "Fire_L1";
			L2 = "Fire_L2";
			L3 = "Fire_L3";
			R1 = "Fire_R1";
			R2 = "Fire_R2";
			R3 = "Fire_R3";
			OPTION = "Option";
			HORIZONTAL_L = "Horizontal_L";
			HORIZONTAL_R = "Horizontal_R";
			VERTICAL_L = "Vertical_L";
			VERTICAL_R = "Vertical_R";
		}
		//-------------------------------------
		// ロジクールのゲームパッド
		else if (joyPad == GamepadF310) {
			CIRCLE = "Cross";
			TRIANGLE = "Triangle";
			SQUARE = "Circle";
			CROSS = "Square";
			L1 = "Fire_L1";
			L2 = "Fire_L2_F310";
			L3 = "Fire_L3_F310";
			R1 = "Fire_R1";
			R2 = "Fire_R2_F310";
			R3 = "Fire_R3_F310";
			OPTION = "Option";
			HORIZONTAL_L = "Horizontal_L_F310";
			HORIZONTAL_R = "Horizontal_R_F310";
			VERTICAL_L = "Vertical_L_F310";
			VERTICAL_R = "Vertical_R_F310";
		}

		circle = false;
		triangle = false;
		square = false;
		cross = false;
		l1 = false;
		l2 = false;
		l3 = false;
		r1 = false;
		r2 = false;
		r3 = false;
		option = false;
	}
	//=====================================================================================================================
	/// <summary>
	/// ◯ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Circle() {
		if (Input.GetAxis(CIRCLE) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// ◯ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool CircleDown() {
		if (Input.GetAxis(CIRCLE) > 0) {
			if (circle == false) {
				circle = true;
				return true;
			}
		}
		else {
			if (circle) circle = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// △ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Triangle() {
		if (Input.GetAxis(TRIANGLE) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// △ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool TriangleDown() {
		if (Input.GetAxis(TRIANGLE) > 0) {
			if (triangle == false) {
				triangle = true;
				return true;
			}
		}
		else {
			if (triangle) triangle = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// □ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Square() {
		if (Input.GetAxis(SQUARE) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// □ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool SquareDown() {
		if (Input.GetAxis(SQUARE) > 0) {
			if (square == false) {
				square = true;
				return true;
			}
		}
		else {
			if (square) square = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// ✕ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Cross() {
		if (Input.GetAxis(CROSS) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// ✕ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool CrossDown() {
		if (Input.GetAxis(CROSS) > 0) {
			if (cross == false) {
				cross = true;
				return true;
			}
		}
		else {
			if (cross) cross = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// L1ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_L1() {
		if (Input.GetAxis(L1) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// L1ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_L1Down() {
		if (Input.GetAxis(L1) > 0) {
			if (l1 == false) {
				l1 = true;
				return true;
			}
		}
		else {
			if (l1) l1 = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// L2ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_L2() {
		if (Input.GetAxis(L2) > 0) {
			return true;
		}
		return false;
	}
	/// <summary>
	/// L2ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_L2Down() {
		if (Input.GetAxis(L2) > 0) {
			if (l2 == false) {
				l2 = true;
				return true;
			}
		}
		else {
			if (l2) l2 = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// L3ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_L3() {
		if (Input.GetAxis(L3) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// L3ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_L3Down() {
		if (Input.GetAxis(L3) > 0) {
			if (l3 == false) {
				l3 = true;
				return true;
			}
		}
		else {
			if (l3) l3 = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// R1ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_R1() {
		if (Input.GetAxis(R1) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// R1ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_R1Down() {
		if (Input.GetAxis(R1) > 0) {
			if (r1 == false) {
				r1 = true;
				return true;
			}
		}
		else {
			if (r1) r1 = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// R2ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_R2() {
		if (Input.GetAxis(R2) > 0) {
			return true;
		}
		return false;
	}
	/// <summary>
	/// R2ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_R2Down() {
		if (Input.GetAxis(R2) < 0) {
			if (r2 == false) {
				r2 = true;
				return true;
			}
		}
		else {
			if (r2) r2 = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// R3ボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_R3() {
		if (Input.GetAxis(R3) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// R3ボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool Fire_R3Down() {
		if (Input.GetAxis(R3) > 0) {
			if (r3 == false) {
				r3 = true;
				return true;
			}
		}
		else {
			if (r3) r3 = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// optionボタンを押している間の処理
	/// </summary>
	/// <returns></returns>
	public bool Option() {
		if (Input.GetAxis(OPTION) == 1)
			return true;
		return false;
	}
	/// <summary>
	/// optionボタンを押した時の処理
	/// </summary>
	/// <returns></returns>
	public bool OptionDown() {
		if (Input.GetAxis(OPTION) > 0) {
			if (option == false) {
				option = true;
				return true;
			}
		}
		else {
			if (option) option = false;
		}

		return false;
	}
	//=====================================================================================================================
	/// <summary>
	/// 左スティックを倒しているフラグを取得
	/// </summary>
	/// <returns></returns>
	public bool LStick() {
		if (Input.GetAxis(HORIZONTAL_L) != 0 || Input.GetAxis(VERTICAL_L) != 0) {
			return true;
		}
		return false;
	}
	/// <summary>
	/// 左スティックを倒している角度を取得
	/// </summary>
	/// <returns></returns>
	public Vector3 GetLStick() {
		float x = Input.GetAxis(HORIZONTAL_L);
		float z = Input.GetAxis(VERTICAL_L);
		Vector3 move = new Vector3(x, 0, z);
		return move;
	}
	//=====================================================================================================================
	/// <summary>
	/// 右スティックを倒しているフラグを取得
	/// </summary>
	/// <returns></returns>
	public bool RStick() {
		if (Input.GetAxis(HORIZONTAL_R) != 0 || Input.GetAxis(VERTICAL_R) != 0) {
			return true;
		}
		return false;
	}
	/// <summary>
	/// 右スティックを倒している角度を取得
	/// </summary>
	/// <returns></returns>
	public Vector3 GetRStick() {
		float x = Input.GetAxis(HORIZONTAL_R);
		float z = Input.GetAxis(VERTICAL_R);
		Vector3 move = new Vector3(x, 0, z);
		return move;
	}
}
