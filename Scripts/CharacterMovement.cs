using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector3 _input;
    private bool _isMoving;
    private bool _canJump = true; 

    private Rigidbody2D _rigidbody;
    public float jumpForce = 5.0f;
    private CharacterAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharacterAnimations>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown("space") && _canJump) 
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            _canJump = false; 
            StartCoroutine(ResetJump());
        }
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f); 
        _canJump = true; 
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;

        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;
        }

        _animations.IsMoving = _isMoving;
    }
}