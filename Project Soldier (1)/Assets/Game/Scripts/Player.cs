using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody _characterRigidbody;
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
    [SerializeField]
    private GameObject _hitMarker;
    
    private Enemy _enemy;
    private UIManager _uiManager;
    private CapsuleCollider _collider;
    
    [SerializeField]
    private float _walkSpeed;
    [SerializeField]
    private float _runSpeed;
    private Vector3 velocity = Vector3.zero;
    private float _speed;
    private float _gravity = 9.81f;
    private float _weapon;
    private float _fireRate;
    private float _canFire = 0;
    private int _weaponDamage;
    private float _shotDistance;
    private bool _isAttacking = false;
    private int selectedWeapon = 2;
    
    public int _life;
    public bool _isDead = false;
    public bool _lock = false; //serve para paralisar totalmente o player
    private int _z = 0;

	public float _jumpForce;    
	private float tempoPulando;
	public float maxTempoPulando = 0.5f;
	public float maxParaTempoPular = 0.1f;
    private float _distToGround;


	// Use this for initialization
	void Start () {
		_characterRigidbody = GetComponent<Rigidbody>();
        _actions = GetComponent<Actions>();
        _playerController = GetComponent<PlayerController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _collider = GetComponent<CapsuleCollider>();

        _uiManager.UpdateLifes(_life);
        _distToGround = _collider.bounds.extents.y;
		tempoPulando = maxTempoPulando + 1f;


    }

    // Update is called once per frame
    void Update()
    {        
        if (_lock == false)
        {
            if (_isDead == false)
            {                
                CalculateMovement();
                   
                if(_isAttacking == false)
                {
                    WeaponChange();
                    Jump();
                }
            }
            else
            {
                Death();
            }
        }      
    }
    
    private void CalculateMovement()
    {

        _speed = _walkSpeed;
        Run();
        

        //calcuar direção
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        //travar o eixo Z
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
                
		//animação Idle, Walk e Run + Idle Actions
        if (Input.GetAxis("Horizontal") > 0.3 || Input.GetAxis("Horizontal") < -0.3)
        {
            //testa se esta andando ou correndoe dispara a animação correspondente
            if(_speed == _walkSpeed)
            {
                _akShotPrefab.SetActive(false);
                _actions.Walk();

            }
            else
            {
                _actions.Run();
                _akShotPrefab.SetActive(false);
                
            }
            
			velocity.Set(direction.x * _speed, velocity.y, 0f);
        }
        else
        {
            //Se estiver parado solta o idle
            _actions.Stay();                        
            Aiming();
            Shot();
        }

		_characterRigidbody.AddForce (velocity);
    }    

    private void Jump()
    {        

        if (Input.GetButtonDown("Jump") && tempoPulando > maxTempoPulando && !IsNotGounded())
        {
            _actions.Jump();
            tempoPulando = 0;

        }
        if (tempoPulando > maxParaTempoPular && tempoPulando < maxTempoPulando)
        {
            velocity.Set(0, _jumpForce, 0);
        }
        else
        {
            velocity.Set(0, -_gravity, 0);
        }
        tempoPulando += Time.deltaTime;
    }

    private void Run()
    {
        if (Input.GetButton("Run"))
        {
            _speed = _runSpeed;
        }
    }

    private void WeaponChange()
    {


        if (Input.GetAxis("D-Pad Y") > 0 || Input.GetButtonDown("Up"))
        {
            selectedWeapon = 1;
            _playerController.SetArsenal("Empty");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 0;
        }
        else if (Input.GetAxis("D-Pad Y") < 0 || Input.GetButtonDown("Down") )
        {
            selectedWeapon = 2;
            _playerController.SetArsenal("Shotgun");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 1;
        }
        else if (Input.GetAxis("D-Pad X") > 0 || Input.GetButtonDown("Right"))
        {
            selectedWeapon = 3;
            _playerController.SetArsenal("AK-74M");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 2;
        }
        else if (Input.GetAxis("D-Pad X") < 0 || Input.GetButtonDown("Left"))
        {
            selectedWeapon = 4;
            _playerController.SetArsenal("Sniper Rifle");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 3;
        }


        if (selectedWeapon == 1)
        {
            _playerController.SetArsenal("Empty");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 0;
        }
        else if (selectedWeapon == 2)
        {
            _playerController.SetArsenal("Shotgun");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 1;
        }
        else if (selectedWeapon == 3)
        {
            _playerController.SetArsenal("AK-74M");
            _fireRate = _playerController._fireRate;
            _weaponDamage = _playerController._damage;
            _shotDistance = _playerController._shotDistance;
            _weapon = 2;
        }
        else if (selectedWeapon == 4)
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
            _isAttacking = true;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            _isAttacking = false;
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
                Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                _enemy = hitInfo.transform.GetComponent<Enemy>();
                _enemy.transform.position = _enemy.transform.position;
                _enemy._navMesh.speed = 0 * Time.deltaTime;                

                hitInfo.transform.GetComponent<EnemyActions>().Damage();
                _enemy._life -= _weaponDamage; 

            }
        }
    }

    private void Shot()
    {
        if (Input.GetButton("Fire1") && !IsNotGounded())
        {
            _isAttacking = true;
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
            _isAttacking = false;
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

    public bool IsNotGounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }
}
