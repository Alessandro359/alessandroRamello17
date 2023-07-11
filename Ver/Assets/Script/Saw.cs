using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake() {
        leftEdge = transform.position.x - distance;
        rightEdge = transform.position.x + distance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Update() {
        if(movingLeft){
            if(transform.position.x > leftEdge){
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }else{
                movingLeft = false;
            }
        }else{
            if(transform.position.x < rightEdge){
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }else{
                movingLeft = true;
            }
        }
        
    }
}
