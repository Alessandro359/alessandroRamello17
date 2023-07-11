using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float lifeTime;
    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update() {
        if(hit) return;
        float movmentSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movmentSpeed,0,0);
        lifeTime += Time.deltaTime;
        if(lifeTime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("Explode");
    }
    public void SetDirection(float _direction){
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        float localScalex = transform.localScale.x;
        if(Mathf.Sign(localScalex) != direction){
            localScalex = -localScalex;
        }
        transform.localScale = new Vector3(localScalex, transform.localScale.y,transform.localScale.z);

    }
    private void Deactivate(){
        gameObject.SetActive(false);
    }

}
