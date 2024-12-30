using Unity.VisualScripting;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
{
    public LayerMask HitBoxLayer;
    public float radius;
    public float damage = 10f;
    public bool IsAPlayer, IsAEnemy;
    public GameObject HitFX;

    void Update()
    {
        DetectHitBoxCollision();
    }

    private void DetectHitBoxCollision()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, HitBoxLayer); //set player and enemy on different layer!
        if (hitColliders.Length == 0) return;

        Collider target = hitColliders[0];

        if (IsAPlayer)
        {
            HandlePlayerAttack(target);
        }

        if (IsAEnemy)
        {
            HandleEnemyAttack(target);
        }
        gameObject.SetActive(false);
    }

    private void HandlePlayerAttack(Collider target)
    {
        Vector3 hitFXPosition = target.transform.position;
        hitFXPosition.y += 1.3f; //when spawning it would be under so +1.3 of y axis to be higher

        if (HitFX.transform.forward.x > 0)//make sure it at center
        {
            hitFXPosition.x += 0.3f;
        }else if (HitFX.transform.forward.x < 0)//make sure it at center
        {
            hitFXPosition.x -= 0.3f;
        }
        Instantiate(HitFX, hitFXPosition, Quaternion.identity);
        bool isCritical = gameObject.CompareTag("LeftHand") || gameObject.CompareTag("LeftFoot");//animation contain Left Hand and Foot will count as critical
        target.GetComponent<HealthScript>().ApplyDamage(damage, isCritical);
    }

    private void HandleEnemyAttack(Collider target)
    {
        target.GetComponent<HealthScript>().ApplyDamage(damage, true);
    }
}
