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
        HealthBar.fillAmount = Health;//fillamount range from 0-1 so if it <0 (maybe 0.5) we set it to 0 for sure
    }
}
