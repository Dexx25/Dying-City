using Unity.VisualScripting;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
    public LayerMask HitBoxLayer;
    public float radius;
    public float damage = 10f;
    public bool IsAPlayer,IsAEnemy;
    public GameObject HitFX;
    void Start()
    {
        
    }

    void Update()
    {
        DetectHitBoxCollision();
    }

    void DetectHitBoxCollision(){
        Collider[] hit = Physics.OverlapSphere(transform.position,radius,HitBoxLayer);
        if (hit.Length >0){
            print("Hit From" + gameObject.name +" to " + hit[0].gameObject.name);
            if(IsAPlayer){
                Vector3 HitFXPos = hit[0].transform.position;
                HitFXPos.y += 1.3f;
                if(HitFX.transform.forward.x > 0){
                    HitFXPos.x += 0.3f;
                }else if(HitFX.transform.forward.x < 0){
                    HitFXPos.x -= 0.3f;
                }
                Instantiate(HitFX,HitFXPos,Quaternion.identity);

                if (gameObject.CompareTag("LeftHand")|| gameObject.CompareTag("LeftFoot")){
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage,true);
                }else{
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage,false);
                }
            }
            if (IsAEnemy){
                
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage,true);
            }
            gameObject.SetActive(false);
        }
    }

}
