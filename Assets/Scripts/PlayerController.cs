using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    float horizontal;
    float vertical;
    public float speed = 5.0f;
    Animator animator;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }
    void Update(){

        horizontal=Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        
    }
    private void FixedUpdate(){
        animator.SetBool("IsUp",false);
        animator.SetBool("IsDown",false);
        animator.SetBool("IsHorizontal",false);
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
        if(horizontal!=0){
            
            animator.SetBool("IsHorizontal",true);
            
            if(horizontal>0){
                renderer.flipX=false;
            }
            else if(horizontal<0){
               renderer.flipX=true;
            }
        }
        else if(vertical!=0){
            
            if(vertical>0){
               animator.SetBool("IsUp",true); 
               
            }
            else if(vertical<0){
               
               animator.SetBool("IsDown",true);
            }
        }
        
    }
}
