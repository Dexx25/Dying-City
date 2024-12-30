using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation EnemyAnim;
    private Rigidbody EnemyBody;
    public float EnemyWalkSpeed = 1.5f;
    private Transform targetPlayer;
    public float DistanceTriggerAttack;
    [SerializeField]
    private float FollowPlayerAfterAttack;
    private float CurrentAttackTime;
    private float DefaultAttackTime = 1f;
    private bool FollowPlayer;
    private bool Attack;

    void Awake()
    {
        EnemyAnim = GetComponentInChildren<CharacterAnimation>();
        EnemyBody = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        FollowPlayer = true;
        CurrentAttackTime = DefaultAttackTime;
    }

    void Update()
    {
        FollowTarget();
        PerformAttack();
    }

    void FollowTarget()
    {
        if (!FollowPlayer) return;

        float distanceToPlayer = Vector3.Distance(transform.position, targetPlayer.position);

        if (distanceToPlayer > DistanceTriggerAttack)
        {
            transform.LookAt(targetPlayer);
            EnemyBody.linearVelocity = transform.forward * EnemyWalkSpeed;

            if (EnemyBody.linearVelocity.sqrMagnitude > 0)//check for velocity if >0 then set boolen of walk to true
            {
                EnemyAnim.Walk(true);//sometimes return error to player, idk why
            }
        }
        else
        {
            EnemyBody.linearVelocity = Vector3.zero;
            EnemyAnim.Walk(false);
            FollowPlayer = false;
            Attack = true;
        }
    }

    void PerformAttack()
    {
        if (!Attack) return;

        CurrentAttackTime += Time.deltaTime;

        if (CurrentAttackTime > DefaultAttackTime)
        {
            EnemyAnim.EnemyAttack(Random.Range(1, 3));
            CurrentAttackTime = 0f;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, targetPlayer.position);

        if (distanceToPlayer > DistanceTriggerAttack + FollowPlayerAfterAttack)
        {
            FollowPlayer = true;
            Attack = false;
        }
    }
}
