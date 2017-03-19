using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static int m_GamePoint;

	// Use this for initialization
	void Start () {
		m_GamePoint = 0;
	}

	public void AddPoints (int point) {
		m_GamePoint += point;
		print (m_GamePoint);
	}
}
