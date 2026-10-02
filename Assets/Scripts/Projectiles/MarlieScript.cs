using UnityEngine;

public class MarlieScript : MonoBehaviour
{
    [SerializeField] ProjectileData projectileData;

    [Header("Movement")]
    private float moveSpeed = 10f;

    [Header("Player Following")]
    [SerializeField] private float yOffset = 0f;

    private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private int direction = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Pogba");
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        // Keep the dog's Y relative to the player
        float targetY = player.transform.position.y + yOffset;

        // Move horizontally
        Vector2 newPosition = new Vector2(
            rb.position.x + direction * moveSpeed * Time.fixedDeltaTime,
            targetY
        );

        rb.MovePosition(newPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable enemy = collision.GetComponentInParent<IDamageable>();

            if (enemy != null)
            {
                enemy.TakeDmg(projectileData.damage);
            }
        }

        if (collision.CompareTag("WorldBoarder"))
        {
            TurnAround();
        }
    }

    private void TurnAround()
    {
        direction *= -1;

        // Flip sprite depending on direction
        spriteRenderer.flipX = direction < 0;
    }
}