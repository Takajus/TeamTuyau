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
    [SerializeField]
    private float gliding = 0.5f;
    [SerializeField]
    private float distanceLeftWall = 4;
    
    private int jumpSpeed = 25;
    private float _defaultSpeed;
    private float horizontal;
    private bool _isfacingRight = true;
    
    [SerializeField] 
    private GameObject platform;
    private GameObject leftWall;
    private MenuController menu;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask platLayer;

    private Transform tr;
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    public AudioSource jumping;
    public AudioSource create;
    public Animator animator;
    
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
    private KeyCode platformUpCreation = KeyCode.Z;
    
    public bool _canJump = true;
    private bool _isCrouch = false;
    private bool _isAnimationEnd = true;
    private bool _canMove = true;
    private bool _canCreateMorePlatform = false;
    private bool _isGliding = false;
    private bool _isSmoking = false;

    [SerializeField]
    private Vector2 crouchSize = new Vector2(1, 0.5f);
    private Vector2 defaultCrouchSize = new Vector2(1, 1);

    [SerializeField, Header("Animation delay")] 
    private float animationPlatformCreation = 0.25f;

    [SerializeField, Header("Position platform")] 
    private Vector2 positionInstantiateUpPlatform = new Vector2(0,0.75f);
    [SerializeField]
    private Vector2 positionInstantiateLeftPlatform = new Vector2(-2,0.5f);
    [SerializeField]
    private Vector2 positionInstantiateRightPlatform = new Vector2(2,0.5f);

    private Vector2 _positionToCreatePlatform;

    private Coroutine _currentCoroutine = null;

    [SerializeField] 
    private int maxPlatformCanCreate = 2;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 8;
        
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        menu = GetComponent<MenuController>();

        _defaultSpeed = speed;
        
        leftWall = GameObject.FindGameObjectWithTag("LeftWall");
        _positionToCreatePlatform = positionInstantiateRightPlatform;
        GameMaster.instance.high = 0; 
        GameMaster.instance.countdown = 500;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!menu.isMenuActive)
            Movement();
        Flip();
        if (menu.index == 0) 
            Interaction();
        
        if (IsGroundedGround())
        {
            _canJump = true;
            _canCreateMorePlatform = true;
            maxPlatformCanCreate = 2;
        }
        
        if (IsGroundedPlat())
        {
            _canJump = true;
            _canCreateMorePlatform = false;
        }
    }

    private void Movement()
    {
        if (!_isAnimationEnd) return;
        if (!_canMove) return;
        
        if (Input.GetKeyDown(jump) && !_isSmoking)
        {
            if (_canJump)
            {
                Jump();
                animator.SetBool("Move", false);
                animator.SetTrigger("Jump");
                _canJump = false;
            }
        }

        /*if (Input.GetKeyDown(crouch))
        {
            ToggleCrouch();
        }*/
        
        if (Input.GetKey(forward) && !_isSmoking)
        {
            horizontal = 1;
            SetPositionToCreatePlatform(positionInstantiateRightPlatform);
          //  tr.rotation = new Quaternion(0, 0, 0,0);
            Move();
        }
        else if (Input.GetKey(backward) && Vector2.Distance(leftWall.transform.position, tr.position) < distanceLeftWall && !_isSmoking)
        {
            horizontal = -1;
            SetPositionToCreatePlatform(positionInstantiateLeftPlatform);
        //    tr.rotation = new Quaternion(0, -180, 0,0);
            Move();
        }
        else
        {
            horizontal = 0;
            animator.SetBool("Move", false);
            Move();
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

    public void PlayJump(){
        jumping.Play ();
    }

    private void Jump(float dist = 1)
    {
        rb.AddForce(Vector2.up * (dist * (force * jumpSpeed)));
        jumping.Play ();
    }


    private void Move()
    {
        if (!_isGliding && horizontal != 0)
            animator.SetBool("Move", true);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        //tr.position += dir * (speed * Time.deltaTime);
    }

    private bool IsGroundedGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private bool IsGroundedPlat()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, platLayer);
    }

    private void Flip()
    {
        if(_isfacingRight && horizontal < 0f || !_isfacingRight && horizontal > 0f)
        {
            _isfacingRight = !_isfacingRight;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }

    public void PlayCreate(){
        create.Play ();
    }

    private void CreatePlatform()
    {
        if (!_canJump || _isSmoking) return;
        
        _isAnimationEnd = false;

        Vector2 currentPlayerPosition = tr.position;
        Vector2 position = currentPlayerPosition + _positionToCreatePlatform;

        if (_canCreateMorePlatform)
        {
            create.Play ();
            animator.SetBool("Move", false);
            Smoke();
            Instantiate(platform, position, Quaternion.identity);
            _currentCoroutine = StartCoroutine(DelayCreatePlatform(animationPlatformCreation));
        }
        else
        {
            if (maxPlatformCanCreate <= 0) return;

            animator.SetBool("Move", false);
            Smoke();
            Instantiate(platform, position, Quaternion.identity);
            _currentCoroutine = StartCoroutine(DelayCreatePlatform(animationPlatformCreation));

            maxPlatformCanCreate--;
        }
    }   
    
    private void SetPositionToCreatePlatform(Vector2 new_position)
    {
        _positionToCreatePlatform = new_position;
    }
    
    public void SetCanMove(bool value)
    {
        _canMove = value;
        animator.SetBool("Move", false);
    }
    
    public void Glide()
    {
        if (_canJump && !_isGliding)
        {
            _isGliding = true;
            Smoke();
        }
    }

    public void SetTimeScale(float newSpeed)
    {
        speed = newSpeed;
        animator.SetTrigger("Idle");
    }

    public void ResetSpeed()
    {
        speed = _defaultSpeed;
    }
    
    private void ChangeGravityScale(float new_scale)
    {
        rb.gravityScale = new_scale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground" || col.gameObject.tag == "platform")
        {
            _isGliding = false;
            ChangeGravityScale(5);
            force = 33;
            animator.SetTrigger("Idle");
        }
        else if (col.gameObject.tag == "house")
        {
            animator.SetTrigger("Victory");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("platform"))
            _canJump = false;
            
        if (other.gameObject.CompareTag("LeftWall"))
            Vector2.Distance(other.transform.position, tr.position);
    }
    
    private IEnumerator DelayCreatePlatform(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        _isAnimationEnd = true;
        animator.SetTrigger("Idle");

        StopCoroutine(_currentCoroutine);
    }

    public void Smoke()
    {
        if (!_isSmoking && _canJump)
        {
            _isSmoking = true;
            animator.SetBool("Move", false);
            animator.SetTrigger("Smoke");
            StartCoroutine(DelaySmoking(2));
            GameMaster.instance.high += 16;
            GameMaster.instance.countdown -= 20;
            horizontal = 0;
            
        }
    }

    private IEnumerator DelaySmoking(float delay)
    {
        yield return new WaitForSeconds(delay);

        _isSmoking = false;
        animator.SetTrigger("Idle");
        print("wtf2");
        if (_isGliding)
        {
            print("wtf");
            animator.SetBool("Move", false);
            animator.SetTrigger("Glide");
            ChangeGravityScale(gliding);
            force = 10;

            if (_canJump)
                Jump();
        }
    }
}