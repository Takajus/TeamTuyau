using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private float force = 15;
    private int jumpSpeed = 25;
    [SerializeField] 
    private GameObject platform;

    private Transform tr;
    private Rigidbody2D rb;
    private BoxCollider2D coll;    
    
    [Header("Keybinding")]
    [SerializeField]
    private KeyCode jump = KeyCode.Space;
    [SerializeField]
    private KeyCode forward = KeyCode.D;
    [SerializeField]
    private KeyCode backward = KeyCode.Q;
    [SerializeField]
    private KeyCode crouch = KeyCode.A;
    [SerializeField]
    private KeyCode platformCreation = KeyCode.E;
    [SerializeField]
    private KeyCode platformUpCreation = KeyCode.T;
    
    private bool _canJump = true;
    private bool _isCrouch = false;
    private bool _isAnimationEnd = true;

    [SerializeField]
    private Vector2 crouchSize = new Vector2(1, 0.5f);
    private Vector2 defaultCrouchSize = new Vector2(1, 1);

    [SerializeField, Header("Animation delay")] 
    private float animationPlatformCreation = 1f;

    [SerializeField, Header("Position platform")] 
    private Vector2 positionInstantiateUpPlatform = new Vector2(0,0.75f);
    [SerializeField]
    private Vector2 positionInstantiateLeftPlatform = new Vector2(-2,0.5f);
    [SerializeField]
    private Vector2 positionInstantiateRightPlatform = new Vector2(2,0.5f);

    private Vector2 _positionToCreatePlatform;

    private Coroutine _currentCoroutine = null;
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        _positionToCreatePlatform = positionInstantiateRightPlatform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Interaction();
    }

    private void Movement()
    {
        if (!_isAnimationEnd) return;
        
        if (Input.GetKeyDown(jump))
        {
            if (_canJump)
            {
                _canJump = false;
                Jump();
            }
        }

        if (Input.GetKeyDown(crouch))
        {
            ToggleCrouch();
        }
        
        if (Input.GetKey(forward))
        {
            SetPositionToCreatePlatform(positionInstantiateRightPlatform);
            tr.rotation = new Quaternion(0, 0, 0,0);
            Move(Vector2.right);
        }
        else if (Input.GetKey(backward))
        {
            SetPositionToCreatePlatform(positionInstantiateLeftPlatform);
            tr.rotation = new Quaternion(0, -180, 0,0);
            Move(Vector2.left);
        }
    }

    private void Interaction()
    {
        if (Input.GetKeyDown(platformCreation))
            CreatePlatform();
        
        if (Input.GetKeyDown(platformUpCreation))
        {
            SetPositionToCreatePlatform(positionInstantiateUpPlatform);
            CreatePlatform();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * (force * jumpSpeed));
        
        if (_isCrouch)
            ToggleCrouch(); 
    }

    private void ToggleCrouch()
    {
        _isCrouch = !_isCrouch;

        coll.size = _isCrouch ? crouchSize : defaultCrouchSize;
    }

    private void Move(Vector3 dir)
    {
        tr.position += dir * (speed * Time.deltaTime);
    }

    private void CreatePlatform()
    {
        if (!_canJump) return;
        
        _isAnimationEnd = false;
            
        Vector2 currentPlayerPosition = tr.position;
        Vector2 position = currentPlayerPosition + _positionToCreatePlatform;

        _currentCoroutine = StartCoroutine(DelayCreatePlatform(animationPlatformCreation));
        Instantiate(platform, position, Quaternion.identity);
    }
    
    private void SetPositionToCreatePlatform(Vector2 new_position)
    {
        _positionToCreatePlatform = new_position;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
            _canJump = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            _canJump = false;
    }
    
    private IEnumerator DelayCreatePlatform(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        _isAnimationEnd = true;
        
        StopCoroutine(_currentCoroutine);
    }
}
