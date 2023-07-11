using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;

    private void Awake() {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float damage){
        currentHealth = Mathf.Clamp(currentHealth - damage,0,startingHealth);
        if(currentHealth > 0){

        }else{
            GetComponent<PlayerMovment>().enabled = false;

        }
    }
    public void AddHealt(float value){
        currentHealth = Mathf.Clamp(currentHealth + value,0,startingHealth);
    }
}
