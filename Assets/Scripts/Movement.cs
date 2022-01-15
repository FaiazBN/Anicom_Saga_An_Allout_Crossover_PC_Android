using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
     Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

       
    }

    private void Move()
    {
        var deltaX = Input.GetAxisRaw("Horizontal");

        var moveX = transform.position.x + deltaX * Time.deltaTime * moveSpeed;
        Flip();
        transform.position = new Vector2(moveX, transform.position.y);
        animator.SetFloat("Speed", Mathf.Abs(deltaX));
    }

    private void Flip()
    {
 
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
