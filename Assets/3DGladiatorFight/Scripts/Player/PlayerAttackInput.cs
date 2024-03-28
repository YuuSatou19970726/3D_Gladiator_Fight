using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimation;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        // defend when J pressed
        PressedDefend();
        PressedAttack();
    }

    void PressedDefend()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerAnimation.Defend(true);
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
        }
    }

    void PressedAttack()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
            }
            else
            {
                playerAnimation.Attack_2();
            }
        }
    }
}
