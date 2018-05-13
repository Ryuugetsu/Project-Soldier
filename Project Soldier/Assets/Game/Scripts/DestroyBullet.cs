using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
