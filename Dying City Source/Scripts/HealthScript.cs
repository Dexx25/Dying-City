using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthScript : MonoBehaviour
{
    public float Health = 100f;
    private CharacterAnimation Anim;
    private EnemyMovement EnemyMove;
    private bool CharacterDead;
    public  bool IsAPlayer;
    public bool IsABoss = false;
    private GameObject Enemy;
    private HealthUI HpBar;

    
    
    private string CurrentsceneName;
    void Awake(){
        Anim = GetComponentInChildren<CharacterAnimation>();

        if (IsAPlayer){
            HpBar = GetComponent<HealthUI>();
        }
        EnemyMove = GetComponent<EnemyMovement>();
    }
    void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        CurrentsceneName = currentScene.name;
        
    }


    public void ApplyDamage(float Damage,bool KnockDown){
        if (CharacterDead){
            return;
        }
        Health -= Damage;
        if (IsAPlayer){
            HpBar.DisplayHP(Health);
        }
        if (Health <= 0f){
            Anim.Death();
            CharacterDead = true;
            if (IsAPlayer){
                StartCoroutine(WaitAndLoadLoseScene());
            }
            return;
        }
        
        if (!IsAPlayer&&!IsABoss){
            if (KnockDown){
                if (Random.Range(0,2)>0){
                    Anim.KnockDown();
                }
            }else{
                if (Random.Range(0,3)>1){
                    Anim.hit();
                }
            }
        }
        if (!IsAPlayer && IsABoss){
            if (KnockDown){
                if (Random.Range(0,7)>5){
                    Anim.KnockDown();
                }
            }else{
                if (Random.Range(0,3)>5){
                    Anim.hit();
                }
            }
        }

    }
    IEnumerator WaitAndLoadLoseScene()
    {
        yield return new WaitForSeconds(3.5f);  // Wait for 5 seconds
        SceneManager.LoadScene("Lose");       // Load the "Lose" scene
    }
}
