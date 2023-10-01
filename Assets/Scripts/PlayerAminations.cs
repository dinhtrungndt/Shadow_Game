using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAminations : MonoBehaviour
{
    public Rigidbody2D rgb;
    public Animator animator;
    public float Speed;
    public bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Speed = 0f;
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetUpAnimator();
    }

    public void SetUpAnimator()
    {
        animator.SetBool("isOnGround", isOnGround);
        animator.SetFloat("Speed", Speed);
    }

    public void SetJumping(bool value)
    {
        isOnGround = value;
    }
    public void SetRunning(float value)
    {
        Speed = value;
    }
}
