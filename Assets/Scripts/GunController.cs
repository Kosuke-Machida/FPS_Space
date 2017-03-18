using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] private GameObject m_Muzzle;

	private int m_BulletNum;
	private int m_BulletLimit = 10;
	private int m_BulletBoxLimit = 150;
	private float m_CoolTime = 2.0f;
	private float m_Interval = 2.0f;
	private RaycastHit hit;
	private Vector3 m_HitPoint;
	private AudioClip m_AudioClip;
	private AudioSource m_AudioSource;


	// Use this for initialization
	void Start () {
		m_BulletNum = m_BulletLimit;
		m_AudioSource = gameObject.GetComponent<AudioSource>();
		m_AudioClip = m_AudioSource.clip;
	}

	// Update is called once per frame
	void Update () {
		if (m_Interval < 0.5f) {
			m_Interval += Time.deltaTime;
		} else {
			if (Input.GetMouseButtonDown(0) && m_BulletNum > 0) {
				m_AudioSource.PlayOneShot (m_AudioClip);
				Shoot ();
				m_Interval = 0;
			}
		}
	}

	void Shoot () {
		Vector3 cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);
		Ray ray = Camera.main.ScreenPointToRay(cameraCenter);
		m_BulletNum --;
		if (Physics.Raycast(ray,out hit)){
			m_HitPoint = hit.point - ray.direction;
			GameObject m_HitObjectSparkle = (GameObject)Resources.Load ("Prefabs/HitObjectSparkle");
			GameObject m_MuzzleSparkle = (GameObject)Resources.Load ("Prefabs/MuzzleSparkle");
			if (hit.collider) {
				GameObject HitObjectSparkle = Instantiate (
					m_HitObjectSparkle,
					m_HitPoint,
					Camera.main.transform.rotation
				);
				GameObject MuzzleSparkle = Instantiate (
					m_MuzzleSparkle,
					m_Muzzle.transform.position,
					Camera.main.transform.rotation
				);
				Destroy(MuzzleSparkle, 0.1f);
				Destroy(HitObjectSparkle, 0.5f);
			}
		}
	}
}
