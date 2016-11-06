using UnityEngine;
using System.Collections;

public enum AnimationState
{
    Idle,
    Walking,
    Attacking
};

public class AnimationStateController : MonoBehaviour {
    public AnimationState currentAnimationState;
    public Animator mAnimator;
	
	void Start () {
        currentAnimationState = AnimationState.Idle;
        mAnimator = GetComponent<Animator>();
        AnimationState temp = AnimationState.Idle;
        UpdateAnimationState(temp);
	}

    void UpdateAnimationState(AnimationState newAnimationState)
    {
        currentAnimationState = newAnimationState;
        if (mAnimator != null)
        {
            switch (currentAnimationState)
            {
                case AnimationState.Idle:
                    mAnimator.SetBool("IsWalking", false);
                    mAnimator.SetBool("IsIdle", true);
                    mAnimator.SetBool("IsAttacking", false);
                    break;
                case AnimationState.Walking:
                    mAnimator.SetBool("IsWalking", true);
                    mAnimator.SetBool("IsIdle", false);
                    mAnimator.SetBool("IsAttacking", false);
                    break;
                case AnimationState.Attacking:
                    mAnimator.SetBool("IsWalking", false);
                    mAnimator.SetBool("IsIdle", false);
                    mAnimator.SetBool("IsAttacking", true);
                    break;
                default:
                    break;
            }
        }
    }
}
