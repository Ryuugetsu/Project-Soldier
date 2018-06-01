using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController _characterController;
    private Actions _actions;
    private PlayerController _playerController;



    [SerializeField]
    private Camera _playerCamera;
    [SerializeField]
    private GameObject _akShotPrefab;
    [SerializeField]
    private GameObject _shotgunShotPrefab;
    [SerializeField]
    private GameObject _sniperShotPrefab;

    private Enemy _enemy;
    private UIManager _uiManager;
    private CapsuleCollider _collider;


    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _hightSpeed;
    private float _gravity = 9.81f;
    private float _weapon;
    private float _fireRate;
    private float _canFire = 0;
    private int _weaponDamage;
    private float _shotDistance;
    public int _life;
    public bool _isDead = false;
    public bool _lock = false;
    private int _z = 0;

    private float _verticalVelocity;
    private float _jumpForce;
    public SphereCollider groundTest;
    
    
	// Use this for initialization
	void Start () {
        _characterController = GetComponent<CharacterController>();
        _actions = GetComponent<Actions>();
        _playerController = GetComponent<PlayerController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        _uiManager.UpdateLifes(_life);
    }

    // Update is called once per frame
    void Update()
    {
        if (_lock == false)
        {
            if (_isDead == false)
            {
                CalculateMovement();
                WeaponChange();                
            }
            else
            {
                Death();
            }
        }
    }
    
    private void CalculateMovement()
    {
        float move = _speed;

        

        //calculo do metodo Run + Running Jump
        if (Input.GetButton("Run"))
        {
            move = _hightSpeed;
            _actions.Run();

            _akShotPrefab.SetActive(false);
            
            Jump();
        }

        //calcuar direção, velocidade e gravidade
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 velocity = direction * move;
        velocity.y -= _gravity;
        transform.position = new Vector3(transform.position.x, transform.position.y, _z);

        //calcular rotação do player
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
                
        //animação Walk/Stay e metodo Move + Walking jump and Stay Jump
        if (Input.GetAxis("Horizontal") > 0.3 || Input.GetAxis("Horizontal") < -0.3)
        {
            if(move == _speed)
            {
                _akShotPrefab.SetActive(false);

                _actions.Walk();
                Jump();
                
            }
            
            _characterController.Move(velocity * Time.deltaTime);
        }
        else
        {
            _actions.Stay();
            Jump();            
            Aiming();
            Shot();
        }
               
    }

    private void Jump()
    {
        //Pular
        if (Input.GetButtonDown("Jump"))
        {
            _actions.Jump();
        }
    }

    private void WeaponChange()
    {

        if (Input.GetAxis("D-Pad Y") > 0 || Input.GetButtonDown("Up"))
        {
            _playerController.SetArsenal("Empty");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 0;
        }
        else if (Input.GetAxis("D-Pad Y") < 0 || Input.GetButtonDown("Down"))
        {
            _playerController.SetArsenal("Shotgun");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 1;
        }
        else if (Input.GetAxis("D-Pad X") > 0 || Input.GetButtonDown("Right"))
        {
            _playerController.SetArsenal("AK-74M");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 2;
        }
        else if (Input.GetAxis("D-Pad X") < 0 || Input.GetButtonDown("Left"))
        {
            _playerController.SetArsenal("Sniper Rifle");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 3;
        }
    }

    private void Aiming() {
        if (Input.GetButton("Fire2"))
        {
            _actions.Aiming();
        }
    }

    private void RayCast()
    {
        Ray rayOrigin = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo, _shotDistance))
        {

            if (hitInfo.transform.tag == "Enemy")
            {
                _enemy = hitInfo.transform.GetComponent<Enemy>();
                _enemy._life -= _weaponDamage; 

            }
        }
    }

    private void Shot()
    {
        if (Input.GetButton("Fire1"))
        {
            


            //teste do tipo de tiro
            if (_weapon == 0)       //Mãos livres
            {
                _actions.Attack();
            }
            else if(_weapon == 1 && Input.GetButtonDown("Fire1") && Time.time > _canFire)        //Shotgun
            {
                _actions.Attack();
                _shotgunShotPrefab.SetActive(true);
                Instantiate(_shotgunShotPrefab, _shotgunShotPrefab.transform.position, transform.rotation);
                RayCast();

                _canFire = Time.time + _fireRate;
            }
            else if (_weapon == 2 && Time.time > _canFire)      //AK-74M
            {
                _actions.Attack();
                _akShotPrefab.SetActive(true);
                Instantiate(_akShotPrefab, _shotgunShotPrefab.transform.position, transform.rotation);
                RayCast();

                _canFire = Time.time + _fireRate;
                
            }
            else if (_weapon == 3 && Input.GetButtonDown("Fire1") && Time.time > _canFire)     //Sniper Rifle
            {
                _actions.Attack();
                _sniperShotPrefab.SetActive(true);
                Instantiate(_sniperShotPrefab, _sniperShotPrefab.transform.position, transform.rotation);
                RayCast();

                _canFire = Time.time + _fireRate;
            }
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            _akShotPrefab.SetActive(false);            
        }
    }
    
    public void Death()
    {
        if(_life <= 0)
        {
            _life = 0;
            _actions.Death();
            _isDead = true;
        }
    }
    
}
