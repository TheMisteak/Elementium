using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    Animator animator;

    public float speedliftWall = 1f;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = speedliftWall;
    }

    // Update is called once per frame
    void Update()
    {

        bool moveforward = Input.GetKey("w");
        animator.SetBool("walk", moveforward);

        bool liftwall = Input.GetKeyDown("r");
        animator.SetBool("liftWall", liftwall);

    }
}
