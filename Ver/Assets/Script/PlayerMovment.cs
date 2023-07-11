using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpColldown;
    private float horiziontalInput;
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    private void Update() {
        horiziontalInput = Input.GetAxis("Horizontal");

        //Flip player when turn around

        if(horiziontalInput > 0.01f){
            transform.localScale = Vector3.one;
        }else if(horiziontalInput < -0.01f){
            transform.localScale = new Vector3(-1,1,1);
        }

        
        //Set animation
        anim.SetBool("Run", horiziontalInput != 0);
        anim.SetBool("Grounded", IsGrounded());

        if(wallJumpColldown > 0.2f){
            body.velocity = new Vector2(horiziontalInput * speed,body.velocity.y);

            if(OnWall() && !IsGrounded()){
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }else{
                body.gravityScale = 7;
            }
            if(Input.GetKey(KeyCode.Space)){
                Jump();
            }
        }else{
            wallJumpColldown += Time.deltaTime;
        }

    }
    private void Jump(){
        if(IsGrounded()){
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }else if(OnWall() && !IsGrounded()){
            if(horiziontalInput == 0){
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x)*10,0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.lossyScale.x),transform.localScale.y,transform.localScale.z);
            }else{
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x)*3,6);
            } 
            wallJumpColldown = 0;        
        }
    }

    private bool IsGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }

    private bool OnWall(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.bounds.size,0, new Vector2(transform.localScale.x,0),0.1f,wallLayer);
        return raycastHit.collider != null;
    }
    public bool CanAttack(){
        return horiziontalInput == 0 && IsGrounded() && !OnWall();
    }
}
