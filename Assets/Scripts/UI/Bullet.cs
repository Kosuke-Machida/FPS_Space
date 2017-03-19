using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {
	private float m_BulletNum;

	// Use this for initialization
	void Start () {
		m_BulletNum = 0;
	}

	// Update is called once per frame
	void Update () {
		m_BulletNum = GunController.m_CurrentBulletNum;
		GetComponent<Text>().text = "Bullet : " + m_BulletNum;
	}
}
