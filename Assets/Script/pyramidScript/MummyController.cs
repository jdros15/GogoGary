﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyController : MonoBehaviour {

    public float _moveSpeed;
    public bool _ground;
    public bool moveRight;

    public Transform WallChecker;
    public float wallCheckRadius;
    public LayerMask WhatisWall;
    [SerializeField]
    private bool HittingWall;
    [SerializeField]
    private bool HittingEdge;
    public Transform EdgeChecker;

    [Header("MummyManager")]

    public bool IsMove;
    public Rigidbody2D MummyRigid;
    public Collider2D MummyMainCollider;

    [Header("MummyEffect")]
    public Rigidbody2D PlayerRigid;
    public playercontroller PlayerControllerScript;
    public MummyManager MummyManagerScript;
    public float EffectLengthCounter;
    public bool effectMode;
    public float posX1;
    public float posY1;
    public float posX2;
    public float posY2;
    private Animator MyAnimation;

    private SpriteRenderer mySpriteRenderer;


    void Start() 
    {
        IsMove = true;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        MyAnimation = GetComponent<Animator>();
        PlayerRigid = GameObject.Find("player").GetComponent<Rigidbody2D>();
        PlayerControllerScript = GameObject.Find("player").GetComponent<playercontroller>();
        MummyManagerScript = GameObject.Find("MummyManager").GetComponent<MummyManager>();
    }

    void Update() 
    {
       
            HittingWall = Physics2D.OverlapCircle(WallChecker.position, wallCheckRadius, WhatisWall);
            HittingEdge = Physics2D.OverlapCircle(EdgeChecker.position, wallCheckRadius, WhatisWall);
            if (IsMove)
            {
                if (HittingWall || !HittingEdge)
                    moveRight = !moveRight;
            }
            if (!HittingEdge)
            {
                IsMove = false;
                StartCoroutine(isMoveEnabled());

            }
         
            if (moveRight)
            {
                //transform.localScale = new Vector3(-24f, 30f, 0);
                transform.localScale = new Vector3(posX1, posY1, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }
            else if (!moveRight)
            {
                //transform.localScale = new Vector3(24f, 30f, 0);
                transform.localScale = new Vector3(posX2, posY2, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-_moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }

           
        
    }
    public void MummyAttackMethod() 
    {
        MummyMainCollider.enabled = false;
        MummyManagerScript.ActivateMummyeffect(effectMode, EffectLengthCounter);
        _moveSpeed = 0;
        MyAnimation.SetBool("isAttack", false);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Hitbox"))
        {
            
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player"))
        {
                /*MummyMainCollider.enabled = false;
                MummyManagerScript.ActivateMummyeffect(effectMode, EffectLengthCounter);
                _moveSpeed = 0;
                MyAnimation.SetBool("isAttack", false);*/
            //
            /*if (PlayerControllerScript.ifRight == true && moveRight == true && PlayerControllerScript.grounded == true || PlayerControllerScript.grounded == false)
            {
                //moveRight = false;
                MummyAttackMethod();
            }
           if (PlayerControllerScript.ifRight == false && moveRight == false && PlayerControllerScript.grounded == true || PlayerControllerScript.grounded == false)
            {
                //moveRight = true;
                MummyAttackMethod();
            }
            //end
           if (PlayerControllerScript.ifRight == false && moveRight == true && PlayerControllerScript.grounded == true || PlayerControllerScript.grounded == false)
           {
               moveRight = false;
               MummyAttackMethod();

           }
           if (PlayerControllerScript.ifRight == true && moveRight == false && PlayerControllerScript.grounded == true || PlayerControllerScript.grounded == false)
           {
               moveRight = true;
               MummyAttackMethod();

           }
            if (PlayerControllerScript.ifRight == false && moveRight == true && PlayerControllerScript.grounded == true || PlayerControllerScript.grounded == false)
            {
                moveRight = false;
                MummyAttackMethod();

            }
            if (PlayerControllerScript.ifRight == true && moveRight == false && PlayerControllerScript.grounded == true || PlayerControllerScript.grounded == false)
            {
                moveRight = true;
                MummyAttackMethod();

            }*/
            //p
            if (PlayerControllerScript.ifRight == true && moveRight == true && PlayerControllerScript.grounded == true)
            {
                //moveRight = false;
                MummyAttackMethod();
            }
            if (PlayerControllerScript.ifRight == false && moveRight == false && PlayerControllerScript.grounded == true)
            {
                //moveRight = true;
                MummyAttackMethod();
            }
            if (PlayerControllerScript.ifRight == false && moveRight == true && PlayerControllerScript.grounded == true)
            {
                moveRight = false;
                MummyAttackMethod();

            }
            else if (PlayerControllerScript.ifRight == false && moveRight == true && PlayerControllerScript.grounded == false)
            {
                moveRight = false;
                MummyAttackMethod();
            }
            if (PlayerControllerScript.ifRight == true && moveRight == false && PlayerControllerScript.grounded == true)
            {
                moveRight = true;
                MummyAttackMethod();

            }
            else if (PlayerControllerScript.ifRight == true && moveRight == false && PlayerControllerScript.grounded == false)
            {
                moveRight = true;
                MummyAttackMethod();
            }
          
          
            //p
            if (PlayerControllerScript.grounded == true)
            {
                PlayerControllerScript.MummyCollide = false;
            }
               
              
              
        }
        

        if (other.gameObject.CompareTag("HitBoxCam"))
        {

            gameObject.SetActive(false);
           
        }
      
    }



    void OnTriggerExit2D(Collider2D other)
    {
        _moveSpeed = 3;
        MyAnimation.SetBool("isAttack", true);
        mySpriteRenderer.flipX = false;
        PlayerControllerScript.MummyCollide = true;
    }

    IEnumerator isMoveEnabled()
    {
        yield return new WaitForSeconds(0.300f);
        IsMove = true;
    }
}
