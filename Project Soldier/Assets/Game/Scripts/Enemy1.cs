using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy1 : MonoBehaviour {
    
    private Player _player;
    private Transform _target;
    private EnemyActions _enemyActions;
    private Animator _animator;

    [SerializeField]
    private Trigger _weapon;

    
    public int _life;
    [SerializeField]
    private float _distanceToAttack;
    [SerializeField]
    private float _distanceToFollow;

    private Collider _collider;

    private int _z = 0;


    // Use this for initialization
    void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _enemyActions = GetComponent<EnemyActions>();
        _collider = GetComponent<Collider>(); 
        

    }

    // Update is called once per frame
    void Update() {
        if (_player._lock == false)
        {
            BasicMovement();
            DeadCondition();
        }
    }

    

    private void DeadCondition()
    {
        if (_life <= 0)
        {
            _life = 0;
            _enemyActions.Dead();
            Destroy(this.gameObject, 4f);

            _collider.isTrigger = true;
        }
    }
    private void BasicMovement()
    {
        if (_life > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _z);
            float currentPlayerDistance = Vector3.Distance(transform.position, _player.transform.position);
            if (currentPlayerDistance <= _distanceToAttack)
            {
                transform.position = transform.position;
                if (_player._isDead == false)
                {
                    _enemyActions.Attack();
                }
            }
            else if (currentPlayerDistance <= _distanceToFollow)
            {
                
                _enemyActions.Run();
            }
            else
            {
                transform.position = transform.position;
                _enemyActions.Stay();
            }
        }
    }

    
   
}
