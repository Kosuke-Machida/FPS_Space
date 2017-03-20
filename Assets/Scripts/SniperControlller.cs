using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperControlller : MonoBehaviour {

	[SerializeField] GameObject m_Snipe;
	[SerializeField] int m_SnipeFieldOfView;
	[SerializeField] int m_NormalFieldOfView;

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
		if (Input.GetMouseButtonDown(1)) {
			if (m_SniperMode) {
				m_SniperMode = false;
				m_Camera.fieldOfView = m_NormalFieldOfView;
				m_SnipeRederer.enabled = false;
			} else {
				m_SniperMode = true;
				m_Camera.fieldOfView = m_SnipeFieldOfView;
				m_SnipeRederer.enabled = true;
			}
		}
	}
}
