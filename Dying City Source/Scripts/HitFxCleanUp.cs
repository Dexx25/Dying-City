using Unity.VisualScripting;
using UnityEngine;

public class HitFxCleanUp : MonoBehaviour
{
    private GameObject HitFXClone;
    
    void Start()
    {
        Invoke("CleanUpFX",3f);
        Destroy(gameObject,3f);
    }

    // Update is called once per frame
    void CleanUpFX(){
        gameObject.SetActive(false);
    }
}
