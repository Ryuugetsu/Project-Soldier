using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour {
    private GameObject _player;
    private float _posY;
    private float _posZ;
    
	// Use this for initialization
	void Start () {
        _player = GameObject.Find("Player");
        _posY = transform.position.y - _player.transform.position.y;
        _posZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _posY, _player.transform.position.z + _posZ);
	}
}
