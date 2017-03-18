using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	private int m_BulletNum;
	private int m_BulletLimit;
	private int m_BulletBoxLimit;
	private float m_CoolTime;
	private RaycastHit hit;
	private Vector3 m_HitPoint;
	private AudioClip audioClip;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		m_BulletNum =  30;
		m_BulletLimit = 30;
		m_BulletBoxLimit = 150;
		m_CoolTime = 2.0f;
		audioSource = gameObject.GetComponent<AudioSource>();
		audioClip = audioSource.clip;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			audioSource.PlayOneShot (audioClip);
			Shoot ();
		}
	}

	void Shoot () {
		Vector3 cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);
		Ray ray = Camera.main.ScreenPointToRay(cameraCenter);
		if (Physics.Raycast(ray,out hit)){
			m_HitPoint = hit.point;
			GameObject fire = (GameObject)Resources.Load ("Prefabs/fire");
			if (hit.collider.name != "kosuke") {
				// Instantiate (fire, m_HitPoint, Quaternion.identity);
			}
		}
	}
}
