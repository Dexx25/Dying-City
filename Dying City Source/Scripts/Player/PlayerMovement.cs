using System;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.TextCore;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation AnimationP;
    private Rigidbody Body;
    public float Horizontal_WalkSpeed = 2f;
    public float Vertical_Walkspeed = 1f;
    private int FacingRight = -90; //rotation of Y: -90 is right, 90 is left
    //private float SpeedChangeDirection = 15f;
    void Start()
    {
        AnimationP = GetComponentInChildren<CharacterAnimation>();
        Body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerWalkAnimation();
        ChangeDirectionPlayer();
        
    }
    void FixedUpdate(){
        CheckForMoveMent();
    }

    void CheckForMoveMent(){
        Body.linearVelocity = new Vector3(
            Input.GetAxisRaw("Horizontal")*(-Horizontal_WalkSpeed),//X
            Body.linearVelocity.y,
            Input.GetAxisRaw("Vertical")*(-Vertical_Walkspeed)//Z 
        );
    }
    void ChangeDirectionPlayer(){
        if (Input.GetAxisRaw("Horizontal")>0){
            transform.rotation = Quaternion.Euler(0,-MathF.Abs(FacingRight),0);
        }else if (Input.GetAxisRaw("Horizontal")<0){
            transform.rotation = Quaternion.Euler(0,MathF.Abs(FacingRight),0);
        }else if (Input.GetAxisRaw("Vertical")<0){
            transform.rotation = Quaternion.Euler(0,MathF.Abs(0),0);
        }else if (Input.GetAxisRaw("Vertical")>0){
            transform.rotation = Quaternion.Euler(0,-MathF.Abs(180),0);
        }
        
    }
    void PlayerWalkAnimation(){
        if (Input.GetAxisRaw("Horizontal") !=0 || Input.GetAxisRaw("Vertical") !=0){
            AnimationP.Walk(true);
        }else {
            AnimationP.Walk(false);
        }
    }
}
