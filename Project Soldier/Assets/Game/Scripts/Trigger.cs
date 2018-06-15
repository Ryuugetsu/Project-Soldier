using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Metodo de Colisão do ataque do inimigo

public class Trigger : MonoBehaviour{
    
    private Player _player;
    [SerializeField]
    private int _attackForce;
    [SerializeField]
    private EnemyActions _enemyActions;

    private UIManager _uiManager;

    private bool _canAttack = true;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();                
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("colidindo ");
        if (other.transform.tag == "Player")
        {
            //Debug.Log("colidindo com o player");
            if (_player._isDead == false && _enemyActions._atacando == true && _canAttack == true)
            {
                _canAttack = false;
                StartCoroutine(Attack());                
            }
        }        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);

        //Debug.Log("Acertando o player");
        _player._life -= _attackForce;
        _uiManager.UpdateLifes(_player._life);
        _player.Death();
        _enemyActions._atacando = false;

        _canAttack = true;
    }
}