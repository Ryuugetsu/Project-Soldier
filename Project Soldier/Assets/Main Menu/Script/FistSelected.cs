using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FistSelected : MonoBehaviour {
    public GameObject gameObject;
	// Use this for initialization
	void Start () {
        EventSystem.current.SetSelectedGameObject(gameObject);
       
	}
}
