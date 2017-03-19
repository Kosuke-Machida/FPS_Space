using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float m_PassedTime;

	// Use this for initialization
	void Start () {
		m_PassedTime = 0;
	}

	// Update is called once per frame
	void Update () {
		m_PassedTime += Time.deltaTime;
		GetComponent<Text>().text = "Time : " + m_PassedTime.ToString("f1");
	}
}
