using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {

	private int m_Score;

	// Update is called once per frame
	void Update () {
		m_Score = ScoreManager.m_GamePoint;
		GetComponent<Text>().text = "Pt : " + m_Score;
	}
}
