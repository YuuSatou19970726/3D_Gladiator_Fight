using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float health = 100f;

    private float x_Death = -90f;
    private float death_Smooth = 0.9f;
    private float rotate_Time = 0.23f;
    private bool playerDied;

    public bool isPlayer;

    void Update()
    {
        if (playerDied)
        {
            RotateAfterDeath();
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0f;
            GetComponent<Animator>().enabled = false;
            // print("The character died");
            StartCoroutine(AllowRotate());

            if (isPlayer)
            {
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<PlayerAttackInput>().enabled = false;

                // the player is not the parent game object
                // for the camera anymore
                Camera.main.transform.SetParent(null);

                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<EnemyController>().enabled = false;
                GameObject.FindGameObjectWithTag(Tags.ENEMY_TAG).GetComponent<NavMeshAgent>().enabled = false;
            }
            else
            {
                GetComponent<EnemyController>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }

    void RotateAfterDeath()
    {
        transform.eulerAngles = new Vector3(
            Mathf.Lerp(transform.eulerAngles.x, x_Death, Time.deltaTime * death_Smooth),
            transform.eulerAngles.y, transform.eulerAngles.z);
    }

    IEnumerator AllowRotate()
    {
        playerDied = true;
        yield return new WaitForSeconds(rotate_Time);
        playerDied = false;
    }
}