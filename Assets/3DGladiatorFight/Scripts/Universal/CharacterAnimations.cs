using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Defend(bool defend)
    {
        anim.SetBool(AnimationTags.DEFEND_PARAMETER, defend);
    }

    public void Attack_1()
    {
        anim.SetTrigger(AnimationTags.ATTACK_1_TRIGGER);
    }

    public void Attack_2()
    {
        anim.SetTrigger(AnimationTags.ATTACK_2_TRIGGER);
    }

    void FreezeAnimation()
    {
        anim.speed = 0f;
    }

    public void UnFreezeAnimation()
    {
        anim.speed = 1f;
    }
}
