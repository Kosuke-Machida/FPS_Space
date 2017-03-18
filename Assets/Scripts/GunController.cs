using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

	[SerializeField] private GameObject m_Muzzle;
	[SerializeField] GameObject m_HitObjectSparkle;
	[SerializeField] GameObject m_MuzzleSparkle;

	private int m_CurrentBulletNum;
	private int m_BulletLimit = 10;
	private int m_CurrentBulletBoxNum;
	private int m_BulletBoxLimit = 30;
	private float m_CoolTime = 0.5f;
	private float m_Interval;
	private RaycastHit hit;
	private Vector3 m_HitPoint;
	private AudioClip m_AudioClip;
	private AudioSource m_AudioSource;


	// Use this for initialization
	void Start () {
		m_CurrentBulletNum = m_BulletLimit;
		m_CurrentBulletBoxNum = m_BulletBoxLimit;
		m_AudioSource = gameObject.GetComponent<AudioSource>();
		m_AudioClip = m_AudioSource.clip;
		m_Interval = m_CoolTime;
	}

	// Update is called once per frame
	void Update () {
		if (m_Interval < m_CoolTime) {
			m_Interval += Time.deltaTime;
		} else {
			if (Input.GetMouseButtonDown(0) && m_CurrentBulletNum > 0) {
				m_AudioSource.PlayOneShot (m_AudioClip);
				Shoot ();
				m_Interval = 0;
			}
		}

		if (Input.GetMouseButtonDown(1) && m_CurrentBulletBoxNum > 0) {
			Reload ();
		}
	}

	void Shoot () {
		Vector3 cameraCenter = new Vector3(Screen.width/2, Screen.height/2, 0);
		Ray ray = Camera.main.ScreenPointToRay(cameraCenter);
		m_CurrentBulletNum --;
		print ("CurrentBulletBox : " + m_CurrentBulletBoxNum
			+ ", NumCurrentBulletNum" + m_CurrentBulletNum);
		if (Physics.Raycast(ray,out hit)){
			m_HitPoint = hit.point - ray.direction;
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

	void Reload () {
		int reloadedBulletNum;
		if (m_CurrentBulletNum + m_CurrentBulletBoxNum >= m_BulletLimit){
			reloadedBulletNum = m_BulletLimit - m_CurrentBulletNum;
			m_CurrentBulletBoxNum -= reloadedBulletNum;
		} else {
			reloadedBulletNum = m_CurrentBulletBoxNum;
			m_CurrentBulletBoxNum = 0;
		}
		m_CurrentBulletNum += reloadedBulletNum;
	}
}
