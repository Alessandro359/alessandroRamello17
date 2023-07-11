using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawUp : MonoBehaviour
{
   [SerializeField] private float damage;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake() {
        leftEdge = transform.position.y - distance;
        rightEdge = transform.position.y ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Update() {
        if(movingLeft){
            if(transform.position.y > leftEdge){
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }else{
                movingLeft = false;
            }
        }else{
            if(transform.position.y < rightEdge){
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }else{
                movingLeft = true;
            }
        }
        
    }
}
