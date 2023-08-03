using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    public Transform firePoint;
    

    private Animator animator;
    private PlayerMovement playerMovement;

    public GameObject fireball;

    private float cooldownTimer1;
    private float cooldownTimer2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // Increase cooldownTimer by Time.deltaTime
        cooldownTimer1 += Time.deltaTime;
        cooldownTimer2 += Time.deltaTime;

        // Check if the attack button is pressed, player is grounded, and cooldownTimer has reached attackCooldown
        if (Input.GetMouseButton(0) && playerMovement.grounded && cooldownTimer1 >= attackCooldown)
        {
            Attack();
        }

        if (Input.GetMouseButton(1) && playerMovement.grounded && cooldownTimer2 >= attackCooldown)
        {
            Fire();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        cooldownTimer1 = 0; //Reset cooldown timer to zero after the attack
    }

    private void Fire()
    {
        animator.SetTrigger("fire_projectile");
        cooldownTimer2 = 0;

        Instantiate(fireball, firePoint.position, firePoint.rotation);
        
    }
    

}

