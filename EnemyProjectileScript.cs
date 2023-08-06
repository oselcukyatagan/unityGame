using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileScript : MonoBehaviour
{
   
    // Start is called before the first frame update
    public float speed = 10f;
    [SerializeField] public float time = 0.8f;

    private Animator animator;

    public bool hit = false;

    public Transform playerTransform;
    public float direction;
    public float projectileTimer;

    public float damage = 50;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        // Get Player Location
        playerTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
        direction = Mathf.Sign(playerTransform.localScale.x);

        // Direction of the projectile
        transform.localScale = new Vector3(direction * 0.8f, 0.8f, 1);

    }

    private void Update()
    {
        if (hit) return;

        // Move projectile
        Vector2 bulletMovement = new Vector2(speed * Time.deltaTime * direction, 0f);
        transform.Translate(bulletMovement);

        // After 8 seconds, destroy projectile.
        projectileTimer += Time.deltaTime;

        if (projectileTimer > 8f)
            handleProjectile();

    }

    // When object hits something, this function is called.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        EnemyScript enemyScript = collision.GetComponent<EnemyScript>();

        if (enemyScript != null)
            enemyScript.enemyTakeDamage(damage);


        hit = true;
        animator.SetTrigger("fireballExplode");
        Destroy(gameObject, time);
    }

    private void handleProjectile()
    {
        Destroy(gameObject);
    }

}
