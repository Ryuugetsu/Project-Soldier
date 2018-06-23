using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour {
    
    public Animator _animator;
    public bool _atacando = false;
    

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        


    }
	
    public void Stay()
    {
        _animator.SetFloat("speed", 0f);
    }

    public void Walk()
    {
        _animator.SetFloat("speed", 0.5f);
        
    }

    public void Run()
    {
        _animator.SetFloat("speed", 1f);
    }

    public void Attack()
    {
        _animator.SetFloat("speed", 0f);
        _animator.SetTrigger("attack");
        _atacando = true;
    }

    public void Damage()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("dead")) return;

        _animator.SetTrigger("damage");
    }

    public void Dead()
    {
        _animator.SetTrigger("dead");
    }
}
