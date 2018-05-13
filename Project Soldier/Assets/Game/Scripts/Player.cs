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




    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _hightSpeed;
    private float _gravity = 9.81f;
    private float _weapon;
    private float _fireRate;
    private float _canFire = 0;
    private int _loopCount;

    
	// Use this for initialization
	void Start () {
        _characterController = GetComponent<CharacterController>();
        _actions = GetComponent<Actions>();
        _playerController = GetComponent<PlayerController>();

              
        _loopCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        WeaponChange();

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
            _weapon = 0;
        }
        else if (Input.GetAxis("D-Pad Y") < 0 || Input.GetButtonDown("Down"))
        {
            _playerController.SetArsenal("Shotgun");
            _weapon = 1;
        }
        else if (Input.GetAxis("D-Pad X") > 0 || Input.GetButtonDown("Right"))
        {
            _playerController.SetArsenal("AK-74M");
            _weapon = 2;
        }
        else if (Input.GetAxis("D-Pad X") < 0 || Input.GetButtonDown("Left"))
        {
            _playerController.SetArsenal("Sniper Rifle");
            _weapon = 3;
        }
    }

    private void Aiming() {
        if (Input.GetButton("Fire2"))
        {
            _actions.Aiming();
        }
    }

    private void Shot()
    {
        if (Input.GetButton("Fire1"))
        {
            // teste de colisão do tiro                        
            Ray rayOrigin = _playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.transform.tag == "Enemy")
                {

                }
            }


            //teste do tipo de tiro
            if (_weapon == 0)       //Mãos livres
            {
                _actions.Attack();
            }
            else if(_weapon == 1 && Input.GetButtonDown("Fire1") && Time.time > _canFire)        //Shotgun
            {
                _fireRate = 0.5f;
                _actions.Attack();
                _shotgunShotPrefab.SetActive(true);
                Instantiate(_shotgunShotPrefab, _shotgunShotPrefab.transform.position, Quaternion.Euler(0, 90, 0));

                _canFire = Time.time + _fireRate;
            }
            else if (_weapon == 2 && Time.time > _canFire)      //AK-74M
            {
                _fireRate = 0.1f;
                _actions.Attack();
                _akShotPrefab.SetActive(true);

                Instantiate(_akShotPrefab, _shotgunShotPrefab.transform.position, Quaternion.Euler(0, 90, 0));
                _canFire = Time.time + _fireRate;
                
            }
            else if (_weapon == 3 && Input.GetButtonDown("Fire1") && Time.time > _canFire)     //Sniper Rifle
            {
                _fireRate = 0.7f;
                _actions.Attack();
                _sniperShotPrefab.SetActive(true);
                Instantiate(_sniperShotPrefab, _sniperShotPrefab.transform.position, Quaternion.Euler(0, 90, 0));

                _canFire = Time.time + _fireRate;
            }

            _loopCount++;
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            _akShotPrefab.SetActive(false);

            _loopCount = 0;
        }
    }
    

    
}
