using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNullDestroy : MonoBehaviour {

    [SerializeField] private GameObject mob;
	
	// Update is called once per frame
	void Update () {
		if(mob == null)
        {
            Destroy(this.gameObject);
        }
	}
}
