using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static int m_GamePoint;

	// Use this for initialization
	void Start () {
		m_GamePoint = 0;
	}

	public void AddPoints (float distance) {
		if (distance < 0.5f) {
			m_GamePoint += 50;
		} else if (distance < 1f){
			m_GamePoint += 30;
		} else if (distance < 2f) {
			m_GamePoint += 10;
		} else {
			m_GamePoint += 5;
		}
	}
}
