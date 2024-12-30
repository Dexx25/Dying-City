using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation AnimationP;
    private Rigidbody Body;
    public float Horizontal_WalkSpeed = 2f;
    public float Vertical_Walkspeed = 2f;
    private int FacingRight = -90;

    void Start()
    {
        AnimationP = GetComponentInChildren<CharacterAnimation>();
        Body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandlePlayerAnimation();
        HandlePlayerDirection();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Body.linearVelocity = new Vector3(
            Input.GetAxisRaw("Horizontal") * -Horizontal_WalkSpeed,//boost velocity horizontal Left or Right of x and boost velocity horizontal Left or Right of y
            Body.linearVelocity.y,
            Input.GetAxisRaw("Vertical") * -Vertical_Walkspeed
        );
    }

    void HandlePlayerDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0)//horizontal Right direction of x
        {
            transform.rotation = Quaternion.Euler(0, -MathF.Abs(FacingRight), 0);
        }
        else if (horizontal < 0)//horizontal Left direction of x
        {
            transform.rotation = Quaternion.Euler(0, MathF.Abs(FacingRight), 0);
        }
        else if (vertical < 0)//vertical Right direction y
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (vertical > 0)//vertical Left direction y
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    void HandlePlayerAnimation()
    {
        bool isWalking = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        AnimationP.Walk(isWalking);
    }
}
