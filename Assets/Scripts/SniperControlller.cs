using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperControlller : MonoBehaviour {

	[SerializeField] GameObject m_Snipe;

	private bool m_SniperMode;
	private Camera m_Camera;
	private SpriteRenderer m_SnipeRederer;

	// Use this for initialization
	void Start () {
		m_SniperMode = false;
		m_Camera = GetComponent<Camera>();
		m_SnipeRederer = m_Snipe.GetComponent<SpriteRenderer>();
		m_SnipeRederer.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (m_SniperMode){
			if (Input.GetMouseButtonDown(1)) {
				m_SniperMode = false;
				m_Camera.fieldOfView = 60;
				m_SnipeRederer.enabled = false;
			}
		}else{
			if (Input.GetMouseButtonDown(1)) {
				m_SniperMode = true;
				m_Camera.fieldOfView = 20;
				m_SnipeRederer.enabled = true;
			}
		}
	}
}
