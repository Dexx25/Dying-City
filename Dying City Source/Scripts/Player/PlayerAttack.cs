using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private enum AvailableForCombos{
        None,
        Punch1,
        Punch2,
        Punch3,
        Kick1,
        Kick2
    }
    private CharacterAnimation CAnim;
    private bool ComboReset;
    private float DefaultComboDuration=0.5f;
    private float CurrentComboDuration;
    private AvailableForCombos CurrentComboActive;

    void Awake(){
        CAnim = GetComponentInChildren<CharacterAnimation>();
    }
    void Start()
    {
        CurrentComboDuration=DefaultComboDuration;
        CurrentComboActive = AvailableForCombos.None;
    }

    void Update()
    {
        CheckForCombo();
        ResetCombo();
    }
    void CheckForCombo(){
        if (Input.GetKeyDown(KeyCode.J)){
            
            if (CurrentComboActive >= (AvailableForCombos)3){ // also we can do CurrentComboActive == AvailableForCombos.Punch3 || CurrentComboActive == AvailableForCombos.Kick1 ... return;
                return;
            }
            CurrentComboActive +=1;//This will refer to INDEX of "AvailableForCombos",we can do CurrentComboActive++ 
            ComboReset = true;
            CurrentComboDuration = DefaultComboDuration;
            if (CurrentComboActive == AvailableForCombos.Punch1){
                CAnim.Punch1();
            }
            if (CurrentComboActive == AvailableForCombos.Punch2){
                CAnim.Punch2();
            }
            if (CurrentComboActive == AvailableForCombos.Punch3){
                CAnim.Punch3();
            }
        }
        if (Input.GetKeyDown(KeyCode.K)){
            
            if (CurrentComboActive == AvailableForCombos.Kick2|| CurrentComboActive == AvailableForCombos.Punch3){
                return;
            }

            if (CurrentComboActive == AvailableForCombos.None || CurrentComboActive == AvailableForCombos.Punch1 || CurrentComboActive == AvailableForCombos.Punch2){
                CurrentComboActive = AvailableForCombos.Kick1;
            }else if(CurrentComboActive == AvailableForCombos.Kick1) {
                CurrentComboActive = AvailableForCombos.Kick2;
            }

            ComboReset = true;
            CurrentComboDuration = DefaultComboDuration;

            if (CurrentComboActive == AvailableForCombos.Kick1){
                CAnim.Kick1();
            }
            if (CurrentComboActive == AvailableForCombos.Kick2){
                CAnim.Kick2();
            }
        }
    }
    void ResetCombo(){
        if (ComboReset){
            CurrentComboDuration -= Time.deltaTime;
            if (CurrentComboDuration <=0f){
                CurrentComboActive = AvailableForCombos.None;
                ComboReset = false;
                CurrentComboDuration = DefaultComboDuration;
            }
            
        }
    }
}
