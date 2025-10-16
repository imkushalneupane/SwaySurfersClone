using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;  //endless forward movement speed
    private float _newMoveSpeed;
    [SerializeField]
    private float _jumpeForce = 5f; //jump force
    [SerializeField]
    private float _slideSpeed = 5f;
    [SerializeField]
    private Rigidbody _rb; //refrence to rigidbody
    [SerializeField]
    private RawImage _gameOver;
   

    [Space]

    [SerializeField]
    private Vector3 _offset = new Vector3 (0,1,-10); //camera offset
    [SerializeField]
    private Transform _camera;
    [SerializeField]
    private float _smoothCamera = .5f;

    [SerializeField]
    private Animator _animator;
    
    private Vector3 _targetPos;
    private int _currentLane = 0;

    private Vector3 _spawnPosition;

    private BoxCollider _boxCollider;
    private Vector3 _originalCenter;
    private Vector3 _originalSize;

    
    private bool onGround = true; 
    private bool isAlive = false;

    void Start()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
        }

        _boxCollider = GetComponent<BoxCollider>();
        _originalCenter = _boxCollider.center;
        _originalSize = _boxCollider.size;
        _spawnPosition = transform.position;
        transform.position = _spawnPosition;
        isAlive = true;
        _gameOver.enabled = false;
        _newMoveSpeed = _moveSpeed;
    }
   

    // Update is called once per frame
    void Update()
    { 
        //for forward movement;
        if (isAlive)
        {
            _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, _newMoveSpeed); /*using _rb.linearVelocity.y to
                                                                                    preserves the gravity and jumps*/

            //User Inputs!!
            if (Input.GetKeyDown(KeyCode.RightArrow) || (Input.GetKeyDown(KeyCode.D)))
            {
                if (_currentLane < 1)
                {
                    _currentLane++;
                    _animator.SetBool("isRight",true);
                }
            }
            else
            {
                _animator.SetBool("isRight",false);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A)))
            {
                if (_currentLane > -1)
                {
                    _currentLane--;
                    _animator.SetBool("isLeft",true); 
                }
            }
            else
            {
                _animator.SetBool("isLeft",false);
            }

            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && onGround)
            {
                _rb.AddForce(Vector3.down, ForceMode.Impulse);
                //_animator.SetBool("isSliding", true); // for sliding animation

                //srinking the box collider
                _boxCollider.size = new Vector3(_originalSize.x, _originalSize.y * .3f, _originalSize.z);
                //_boxCollider.center = new Vector3(_originalCenter.x,_originalCenter.y - .5f , _originalCenter.z);
            }
            else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            {
                //_rb.AddForce(Vector3.down, ForceMode.Impulse);
                _animator.SetBool("isSliding", true); // for sliding animation

                //srinking the box collider
                _boxCollider.size = new Vector3(_originalSize.x, _originalSize.y * .3f, _originalSize.z);
                //_boxCollider.center = new Vector3(_originalCenter.x,_originalCenter.y - .5f , _originalCenter.z);
            }
            else
            {
                _animator.SetBool("isSliding", false); // for going back to running animation

                // for resetting the collider dimensions
                _boxCollider.size = _originalSize;
                //_boxCollider.center = _originalCenter;

            }


            if ((Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.UpArrow)) && onGround)
            {
                _rb.AddForce(Vector3.up * _jumpeForce, ForceMode.Impulse);
                _animator.SetBool("isJumping",true);
            }
            else
            {
                _animator.SetBool("isJumping",false);
            }


            //changing the lane
            _targetPos = new Vector3(_currentLane, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _slideSpeed * Time.deltaTime);


            // to counter , the natural fly jumps
            if (transform.position.y > 1.6f && !(Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.UpArrow)))
            {
                _rb.AddForce(Vector3.down * 1f , ForceMode.Impulse); 
            }
        }

    }
    private void LateUpdate()
    {
       Vector3 DesiredPositin = transform.position + _offset; //desired camera position
       _camera.position = Vector3.Lerp(_camera.position,DesiredPositin,_smoothCamera * Time.deltaTime); //camera smoothly follows

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            Debug.Log("DOWN");
            _animator.SetBool("isJumping",false);
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            Die();
        }
    }
    private void OnCollisionExit(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            Debug.Log("UP");
            _animator.SetBool("isJumping",true);
        }
    }

    private void Die()
    {
        isAlive = false;
        _gameOver.enabled = true;
        Debug.Log("I'm Dead My nigga!");
        _rb.linearVelocity = new Vector3(0,0,0);

        //for die animation and setting to ground
        _animator.SetBool("isDead",true);
        _boxCollider.size = new Vector3(_originalSize.x, _originalSize.y * .3f, _originalSize.z);
      
    }
    
  
    public void IncreaseSpeed(float amount)
    {
        _newMoveSpeed += amount * Time.deltaTime;
    }
}
