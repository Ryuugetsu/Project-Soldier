using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour {
    private Player _player;
    private float _posY;
    private float _posZ;
    private bool _locked;
    private float _alignRight = -2.7f;
    private float _alignLeft = 2.7f;
    
    
	// Use this for initialization
	void Start () {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _posY = transform.position.y - _player.transform.position.y;
        _posZ = transform.position.z;
        _locked = false;
        transform.position = new Vector3(_player.transform.position.x + _alignLeft, _player.transform.position.y + _posY, _player.transform.position.z + _posZ);

    }
	
	// Update is called once per frame
	void Update () {
        
        if (_locked == false || _player._lock == false)
        {
            if (_player.transform.rotation.y > 0)
            {
                Vector3 move = new Vector3(_player.transform.position.x + _alignLeft, _player.transform.position.y + _posY, _player.transform.position.z + _posZ);
                transform.position = Vector3.MoveTowards(transform.position, move, 0.05f);
            }
            else if (_player.transform.rotation.y < 0)
            {
                Vector3 move = new Vector3(_player.transform.position.x + _alignRight, _player.transform.position.y + _posY, _player.transform.position.z + _posZ);
                transform.position = Vector3.MoveTowards(transform.position, move, 0.05f);
            }
        }
        else
        {

            transform.position = transform.position;
            Actions actions = _player.GetComponent<Actions>();

            if (_player.transform.position.x > transform.position.x + 4.5f)
            {
                _player.transform.position = new Vector3(transform.position.x + 4.5f, _player.transform.position.y, _player.transform.position.z);
                actions.Stay();
            }
            else if (_player.transform.position.x < transform.position.x - 4.5f)
            {
                _player.transform.position = new Vector3(transform.position.x - 4.5f, _player.transform.position.y, _player.transform.position.z);
                actions.Stay();
            }
        }
    }
    
}
