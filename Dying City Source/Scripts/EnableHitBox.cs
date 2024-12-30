using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnableHitBox : MonoBehaviour
{
    private AudioClip Whoosh, fall, groundHit, Dead, EnemyDead,PlayerDeath;
    public GameObject LeftHandHitBox,RightHandHitBox,
    LeftFootHitBox,RightFootHitBox;
    public float StandUpDelay= 2f;
    private CharacterAnimation Anim;
    private AudioSource AudioS;
    [SerializeField]    
    private EnemyMovement EnemyM;
    private string sceneName;

    public Text Kills;
    public StoreKill sk;

    void Awake(){
        Anim = GetComponent<CharacterAnimation>();
        AudioS = GetComponent<AudioSource>();
        if (gameObject.CompareTag("Enemy")){
            EnemyM = GetComponentInParent<EnemyMovement>(); 
        }
    }
    void Start(){
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "Endless"){
        GameObject killTextObject = GameObject.Find("Kill");
        Kills = killTextObject.GetComponent<Text>();      
        GameObject Kill = GameObject.Find("Kill");
        sk = Kill.GetComponent<StoreKill>();
        }
    }
    void Update(){
    }
    void EnableHitBoxLeftHand(){
        LeftHandHitBox.SetActive(true);
    }
    void DisableHitBoxLeftHand(){
        if(LeftHandHitBox.activeInHierarchy){
            LeftHandHitBox.SetActive(false);
        }
    }
    //
    void EnableHitBoxRightHand(){
        RightHandHitBox.SetActive(true);
    }
    void DisableHitBoxRightHand(){
        if(RightHandHitBox.activeInHierarchy){
            RightHandHitBox.SetActive(false);
        }
    }
    //
    void EnableHitBoxLeftFoot(){
        LeftFootHitBox.SetActive(true);
    }
    void DisableHitBoxLeftFoot(){
        if(LeftFootHitBox.activeInHierarchy){
            LeftFootHitBox.SetActive(false);
        }
    }
    //
    void EnableHitBoxRightFoot(){
        RightFootHitBox.SetActive(true);
    }
    void DisableHitBoxRightFoot(){
        if(RightFootHitBox.activeInHierarchy){
            RightFootHitBox.SetActive(false);
        }
    }
    //
    void DisableAllHitBox(){
        DisableHitBoxRightFoot();
        DisableHitBoxLeftFoot();
        DisableHitBoxRightHand();
        DisableHitBoxLeftHand();
    }
    void LeftHandTag(){
        LeftHandHitBox.tag = "LeftHand";
    }

    void LeftHandUnTag(){
        LeftHandHitBox.tag = "Untagged";
    }

    void LeftFootTag(){
        LeftFootHitBox.tag = "LeftFoot";
    }

    void LeftFootUnTag(){
        LeftFootHitBox.tag = "Untagged";
    }

    void Enemy_StandUpDelay(){
        StartCoroutine(Stand_Up());
    }

    IEnumerator Stand_Up(){
        yield return new WaitForSeconds(StandUpDelay);
        Anim.StandUp();
    }

    public void Player_Death(){
        AudioS.volume = 0.2f;
        AudioS.clip = PlayerDeath;
        AudioS.Play();
    }
    public void Attack_WhooshSound(){
        AudioS.volume = 0.2f;
        AudioS.clip = Whoosh;
        AudioS.Play();
    }
    public void Enemy_fallSound(){
        AudioS.volume = 0.2f;
        AudioS.clip = fall;
        AudioS.Play();
    }
    public void Enemy_groundHitSound(){
        AudioS.volume = 0.2f;
        AudioS.clip = groundHit;
        AudioS.Play();
    }
    public void Character_DeadSound(){
        AudioS.volume = 0.2f;
        AudioS.clip = Dead;
        AudioS.Play();
    }

    public void Enemy_DeadSound(){
        AudioS.volume = 0.2f;
        AudioS.clip = EnemyDead;
        AudioS.Play();
    }
    void DisableEnemyMovement(){
        EnemyM.enabled = false;
        transform.parent.gameObject.layer = 0;
    }
    void EnableEnemyMovement(){
        EnemyM.enabled = true;
        transform.parent.gameObject.layer = 10;
    }

    public void CharacterDead()
    {
        Destroy(transform.parent.gameObject, 2f);
        if (sceneName == "Endless"){
            sk.Kills++;//here where problem start
            Kills.text = "Kills: " + sk.Kills.ToString();
            Invoke("EndlessSpawn",1f);
        }
    }   

    void EndlessSpawn(){
        EnemyWaves.instance.Endless();//for exclusive endless mode
    }
}
