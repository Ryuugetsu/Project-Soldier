using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonarPlayer : MonoBehaviour {

    private Player _player;
    private GameObject _playerMesh;
    [SerializeField]
    private GameObject _godRay;
    
	// Use this for initialization
	void Start () {
        _playerMesh = GameObject.Find("Soldier");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        

        transform.position = _player.transform.position;
        _playerMesh.SetActive(false);
        _player._lock = true;
        _godRay.SetActive(true);
		
	}

    // Update is called once per frame
    private void Update () {
        StartCoroutine(Summon());
	}

    private IEnumerator Summon()
    {
        yield return new WaitForSeconds(5);
        _playerMesh.SetActive(true);
        yield return new WaitForSeconds(15);
        _player._lock = false;
        Destroy(this.gameObject);
        
    }
}
