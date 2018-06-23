using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCapsule_Sort : MonoBehaviour {

    private Player _player;    
    [SerializeField]private int _minIndexToSort;
    [SerializeField] private int _maxIndexToSort;
    private int _currentIndex;

    [SerializeField] private Spawn[] _spawn;





    // Update is called once per frame
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _currentIndex = Random.Range(_minIndexToSort, _maxIndexToSort + 1);
    }

    void Update()
    {
        if (_currentIndex != 0)
        {
            float currentDistance = Vector3.Distance(transform.position, _player.transform.position);
            if (currentDistance <= 10)
            {
                SetIndex(_currentIndex);
                Destroy(this.gameObject);
            }
        }

    }

    public void SetIndex(int index)
    {
        foreach (Spawn i in _spawn)
        {
            if (i.index == _currentIndex)
            {
                Instantiate(i.prefab, this.transform.position, Quaternion.identity);
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
