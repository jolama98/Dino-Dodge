using UnityEngine;

public class Enemy : Character
{
    public Vector3 movementDir;
    public bool onCooldown;
    private Transform playerLocation;
    private Animator animator;

    new void Start()
    {
        animator = GetComponent<Animator>();
        base.Start(); // call the base class start
        // Get the players position
        playerLocation = GameObject.FindGameObjectWithTag("Player")?.transform;
movementDir = (playerLocation.position - transform.position).normalized;     }

    // Update is called once per frame
    void Update()
    {
        if (onCooldown) return; // don't move if on cooldown

        transform.position += movementDir * Time.deltaTime * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (onCooldown) return;
        if (collision.gameObject.tag == "Player")
        {
            onCooldown = true; // set the cooldown
            movementDir = Vector3.zero; // stop moving

            // Get the game object we collided with
            Character player = collision.GetComponent<Character>();

            player.takeDamage(1); // BITE! 💢
            animator.SetBool("isAttacking", true);
            Invoke("ReActivate", 0.5f);
        }
    }

    void ReActivate()
    {
        animator.SetBool("isAttacking", false);
        onCooldown = false;

        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        movementDir = (playerLocation.position - transform.position).normalized;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}