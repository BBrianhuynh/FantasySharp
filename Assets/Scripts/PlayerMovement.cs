using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentState=PlayerState.walk;
        animator=GetComponent<Animator>();
        myRigidbody=GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX",0);
        animator.SetFloat("moveY",-1);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("attack") && currentState!=PlayerState.attack)
        {
            StartCoroutine(AttackCo());
        }
    }
    
        void FixedUpdate()
        {
        change=Vector3.zero;
        change.x=Input.GetAxisRaw("Horizontal");
        change.y=Input.GetAxisRaw("Vertical");
        if(currentState==PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
        }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking",true);
        currentState=PlayerState.attack;
        //Wait 1 frame
        yield return null;
        animator.SetBool("attacking",false);
        yield return new WaitForSeconds(0.3f);
        currentState=PlayerState.walk;
    }

    void UpdateAnimationAndMove(){
        if(change!=Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX",change.x);
            animator.SetFloat("moveY",change.y);
            animator.SetBool("moving", true);
        }else{
            animator.SetBool("moving",false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position+change*speed*Time.deltaTime
        );
    }
}
