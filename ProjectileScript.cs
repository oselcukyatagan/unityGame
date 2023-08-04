using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    [SerializeField] public float time = 0.8f;

    private Animator animator;

    public bool hit = false;

    public Transform playerTransform;
    public float direction;
    public float projectileTimer;

    private void Awake()
    {  
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;

        // Get Player Location
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        direction = Mathf.Sign(playerTransform.localScale.x);

        // Move projectile
        Vector2 bulletMovement = new Vector2(speed * Time.deltaTime * direction, 0f);
        transform.Translate(bulletMovement);

        // Direction of the projectile
        transform.localScale = new Vector3(direction * 0.8f, 0.8f, 1);



        // After 8 seconds, destroy projectile.
        projectileTimer += Time.deltaTime;

        if (projectileTimer > 8f)
            handleProjectile();


    }

    // When object hits something, this function is called.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        animator.SetTrigger("fireballExplode");
        Destroy(gameObject, time);
    }

    private void handleProjectile()
    {
        Destroy(gameObject);
    }

}
