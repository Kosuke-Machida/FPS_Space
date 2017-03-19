using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

	[SerializeField] GameObject m_Target;

	private Animator anim;
	private int m_Life;
	private int m_MaxLife = 5;
	private float m_PassedTimeAfterDead;

	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_Life = m_MaxLife;
		m_PassedTimeAfterDead = 0;
		anim = m_Target.GetComponent<Animator>();
		m_AudioSource = m_Target.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {
		if (m_Life == 0) {
			anim.SetBool("IsDead", true);
			m_PassedTimeAfterDead += Time.deltaTime;
			if (m_PassedTimeAfterDead > 5.0f){
				anim.SetBool("IsDead", false);
				m_Life = 5;
				m_PassedTimeAfterDead = 0;
			}
		}
	}

	public void Hit () {
		m_Life --;
		m_AudioSource.PlayOneShot (m_AudioSource.clip);
	}
}
