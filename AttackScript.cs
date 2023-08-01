using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // Increase cooldownTimer by Time.deltaTime
        cooldownTimer += Time.deltaTime;

        // Check if the attack button is pressed, player is grounded, and cooldownTimer has reached attackCooldown
        if (Input.GetMouseButton(0) && playerMovement.grounded && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0; // Reset cooldownTimer to zero after the attack
    }
}
