using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private PlayerMovment playerMovment;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBall;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake() {
        anim = GetComponent<Animator>();
        playerMovment = GetComponent<PlayerMovment>();
    }
    private void Update() {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovment.CanAttack()){
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void Attack(){
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
        fireBall[FindFireBall()].transform.position = firePoint.position;
        fireBall[FindFireBall()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireBall(){
        for(int i = 0;i < fireBall.Length; i++){
            if(!fireBall[i].activeInHierarchy){
                return i;
            }
        }
        return 0;
    }
}
