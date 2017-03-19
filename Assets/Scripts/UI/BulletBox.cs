using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBox : MonoBehaviour {

	private float m_BulletBoxNum;

	// Use this for initialization
	void Start () {
		m_BulletBoxNum = 0;
	}

	// Update is called once per frame
	void Update () {
		m_BulletBoxNum = GunController.m_CurrentBulletBoxNum;
		GetComponent<Text>().text = "BulletBox : " + m_BulletBoxNum;
	}

}
