using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : Photon.MonoBehaviour {
	// public int m_GamePoint;
	public int m_Hp;
	void Start () {
		// m_GamePoint = 0;
		m_Hp = 5;
	}

	// public void AddPoints (float distance) {
	// 	if (distance < 0.5f) {
	// 		m_GamePoint += 50;
	// 	} else if (distance < 1f){
	// 		m_GamePoint += 30;
	// 	} else if (distance < 2f) {
	// 		m_GamePoint += 10;
	// 	} else {
	// 		m_GamePoint += 5;
	// 	}
	// }

	[PunRPC]
    public void Damage () {
        m_Hp--;
        if (m_Hp <= 0) {
        	Respawn();
        }
    }

	void Respawn ()
	{
		print("Dead");
		transform.position = new Vector3 (0, 0, 0);
		m_Hp = 5;
	}

}
