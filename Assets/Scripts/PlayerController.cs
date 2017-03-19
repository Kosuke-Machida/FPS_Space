using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static int m_GamePoint;

	// Use this for initialization
	void Start () {
		m_GamePoint = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	public void AddPoints (int point) {
		m_GamePoint += point;
	}
}
