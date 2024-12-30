using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation EnemyAnim;
    private Rigidbody EnemyBody;
    public float EnemyWalkSpeed = 5f;
    private Transform targetPlayer;
    public float DistanceTriggerAttack;
    [SerializeField]
    private float FollowPlayerAfterAttack;
    private float CurrentAttackTime;
    private float DefaultAttackTime = 1f;
    private bool FollowPlayer, Attack;
    void Awake()
    {
        EnemyAnim = GetComponentInChildren<CharacterAnimation>();
        EnemyBody = GetComponent<Rigidbody>();
        targetPlayer = GameObject.FindWithTag("Player").transform;
    }
    void Start(){
        FollowPlayer = true;
        CurrentAttackTime = DefaultAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
        Attacking();
    }
    void FollowTarget(){
        if (!FollowPlayer){
            return;
        }
        if(Vector3.Distance(transform.position,targetPlayer.position)>DistanceTriggerAttack){
            //move to player;
            transform.LookAt(targetPlayer);
            EnemyBody.linearVelocity = transform.forward * EnemyWalkSpeed;
            if (EnemyBody.linearVelocity.sqrMagnitude !=0 ){
                EnemyAnim.Walk(true);
            }
        }else if ( Vector3.Distance(transform.position,targetPlayer.position) <= DistanceTriggerAttack ){
            EnemyBody.linearVelocity = Vector3.zero;
            EnemyAnim.Walk(false);
            FollowPlayer = false;
            Attack = true;
        }
    }
    void Attacking(){
        if (!Attack){
            return;
        }
        CurrentAttackTime += Time.deltaTime;
        if (CurrentAttackTime>DefaultAttackTime){
            EnemyAnim.EnemyAttack(Random.Range(1,3));//1,4!
            CurrentAttackTime =0f;
        }
        if(Vector3.Distance(transform.position,targetPlayer.position)>DistanceTriggerAttack+FollowPlayerAfterAttack){
            FollowPlayer = true;
            Attack = false;
        }
    }
}
