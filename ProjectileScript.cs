using UnityEngine;
using UnityEngine.Playables;
using System.Collections;


public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    [SerializeField] public float time = 0.8f;

    private BoxCollider2D boxCollider;
    private Animator animator;

    public bool hit = false;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit != true)
        {
            Vector2 bulletMovement = new Vector2(speed * Time.deltaTime, 0f);
            transform.Translate(bulletMovement);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        animator.SetTrigger("fireballExplode");
        Destroy(gameObject, time);
    }

}
