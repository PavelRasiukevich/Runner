using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterMoveDirection
{
    Up,
    Left,
    Right
}

public class Character : MonoBehaviour
{

    static readonly int FL_SPEED = Animator.StringToHash("MoveSpeed");
    static readonly int BOOL_GROUNDED = Animator.StringToHash("Grounded");

    [SerializeField] Transform[] points;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] FloorTrigger floorTrigger;

    bool isMoving;
    bool canJump;

    Animator anim;
    Rigidbody rigidB;

    int targetPointIndex;
    float moveProgress;
    Vector3 startMovePos;

    public bool IsMoving
    {
        get
        {
            return isMoving;
        }
        set
        {
            isMoving = value;
            anim.SetFloat(FL_SPEED, isMoving ? 1 : 0);
        }
    }
    public Action GameOver { get; set; }


    public void OnTriggerEnterHandler()
    {
        IsMoving = false;
        GameOver.Invoke();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigidB = GetComponent<Rigidbody>();
        startMovePos = transform.position;
    }

    private void Update()
    {
        if (IsMoving)
        {
            if (moveProgress < 1f)
            {
                moveProgress = Mathf.Clamp(moveProgress + speed * Time.deltaTime, 0, 1);
                transform.position = Vector3.Lerp(startMovePos, points[targetPointIndex].position, moveProgress);
            }
        }

        anim.SetBool(BOOL_GROUNDED, floorTrigger.IsGrounded);
    }

    public void OnRequestMove(CharacterMoveDirection _direction)
    {
        if (_direction == CharacterMoveDirection.Up)
        {
            if (rigidB.velocity.y == 0)
                canJump = true;
        }
        else
        {
            int _newIndex = targetPointIndex;

            if (_direction == CharacterMoveDirection.Left)
                _newIndex--;
            else if (_direction == CharacterMoveDirection.Right)
                _newIndex++;

            targetPointIndex = Mathf.Clamp(_newIndex, 0, points.Length - 1);

            StartMove();
        }
    }

    private void FixedUpdate()
    {
        if (canJump)
            Jump();
    }

    private void Jump()
    {
        canJump = false;
        rigidB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void StartMove()
    {
        moveProgress = 0;
        startMovePos = transform.position;
    }

}
