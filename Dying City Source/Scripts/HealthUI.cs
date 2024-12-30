using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image HealthBar;
    void Awake()
    {
        HealthBar = GameObject.FindWithTag("HealthUI").GetComponent<Image>();
    }

    public void DisplayHP(float Health){
        Health /= 100f;
        if(Health < 0f){
            Health = 0f;
        }
        HealthBar.fillAmount = Health;
    }
}
