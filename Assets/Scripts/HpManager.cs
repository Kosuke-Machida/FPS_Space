using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour {

	// public int m_GamePoint;
	public int m_Hp;

	// Use this for initialization
	void Start () {
		// m_GamePoint = 0;
		m_Hp = 5;
	}

	// public void AddPoints (float distance) {
	// 	if (distance < 0.5f) {
	// 		m_GamePoint += 50;
	// 	} else if (distance < 1f){
	// 		m_GamePoint += 30;
	// 	} else if (distance < 2f) {
	// 		m_GamePoint += 10;
	// 	} else {
	// 		m_GamePoint += 5;
	// 	}
	// }

	public void Damage ()
	{
		
	}

}
