using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void Walk(bool move){
        Anim.SetBool("Movement",move);
    }
    public void Punch1(){
        Anim.SetTrigger("Punch1");
    }
    public void Punch2(){
        Anim.SetTrigger("Punch2");
    }
    public void Punch3(){
        Anim.SetTrigger("Punch3");
    }
    public void Kick1(){
        Anim.SetTrigger("Kick1");
    }
    public void Kick2(){
        Anim.SetTrigger("Kick2");
    }
    //Enemy Animation
    public void EnemyAttack(int Attack){
        if (Attack == 1){
            Anim.SetTrigger("Attack1");
        }
        if (Attack == 2){
            Anim.SetTrigger("Attack2");
        }
        if (Attack == 3){
            Anim.SetTrigger("Attack3");
        }
        
    }
    // public void EnemyIdle(){
    //     Anim.Play("Idle");
    // }

    public void KnockDown(){
        Anim.SetTrigger("KnockDown");
    }
    public void StandUp(){
        Anim.SetTrigger("StandUp");
    }
    public void hit(){
        Anim.SetTrigger("Hit");
    }
    public void Death(){
        Anim.SetTrigger("Death");
    }
}
