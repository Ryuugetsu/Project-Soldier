using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnCapsule : MonoBehaviour {

   
    public int _currentIndex;

    [SerializeField]
    private Spawn[] _spawn;

    private NavMeshAgent _meshAgent;
    [SerializeField]
    private Player _player;
	
	// Update is called once per frame
	void Start () {
        _meshAgent = GetComponent<NavMeshAgent>();

        
	}

    void Update () {
        if (_currentIndex != 0)
        {
            float currentDistance = Vector3.Distance(transform.position, _player.transform.position);
            if (currentDistance <= 10)
            {
                SetIndex(_currentIndex);
            }
        }
        else
        {
            SetIndex(_currentIndex);
        }
        Destroy(this.gameObject);
    }

    public void SetIndex(int index)
    {
        foreach(Spawn i in _spawn)
        {
            if(i.index == index)
            {
                Instantiate(i.prefab);
            }
        }
    }

    [System.Serializable]
    public struct Spawn
    {
        public GameObject prefab;
        public int index;

    }
}
