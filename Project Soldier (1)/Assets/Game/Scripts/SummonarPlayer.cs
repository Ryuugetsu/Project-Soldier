using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonarPlayer : MonoBehaviour {
        
    private Player _player;
    private GameObject _playerMesh;
    [SerializeField] private GameObject _godRay;
    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audio;



    // Use this for initialization
    void Start () {
        _playerMesh = GameObject.Find("Soldier");
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
        
        
        //seta a posição do godray aonde o player estiver
        transform.position = _player.transform.position;

        
        _playerMesh.SetActive(false);
        _player.enabled = false;
        audioSource.clip = audio;
        audioSource.Play();
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

        if (_dialogBox.activeInHierarchy == false)
        {
            
            _player.enabled = true;
        }

        Destroy(this.gameObject);
        
    }
}
