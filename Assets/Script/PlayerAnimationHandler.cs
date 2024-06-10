using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        animator.SetBool("isWalking", isWalking);
    }

    public void SetJumping(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping);
    }

    public void SetFalling(bool isFalling)
    {
        animator.SetBool("isFalling", isFalling);
    }
}
