using UnityEngine;

public class UfoProjectile : MonoBehaviour
{
    public Transform targetPosition; // The position to move towards
    public float speed = 1f; // Movement speed
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if (collision.collider.CompareTag("Player"))
        {
            gameManager.LosePlayerLife();
            Destroy(this.gameObject);
        }
    }

}
