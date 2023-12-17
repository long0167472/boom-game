using UnityEngine;

public class MovementController : MonoBehaviour
{
    public new Rigidbody2D rigidbody {get; private set;}
    private Vector2 direction = Vector2.down;
    public float speed = 5f;


    [Header("Input")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;

    //[Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        Debug.Log("Update calling...");
        if (Input.GetKey(inputUp)) {
            Debug.Log("up");
            SetDirection(Vector2.up, spriteRendererUp);
        } else if (Input.GetKey(inputDown)) {
            Debug.Log("down");
            //SetDirection(Vector2.down);
            SetDirection(Vector2.down, spriteRendererDown);
        } else if (Input.GetKey(inputLeft)) {
            Debug.Log("left");
            //SetDirection(Vector2.left);
            SetDirection(Vector2.left, spriteRendererLeft);
        } else if (Input.GetKey(inputRight)) {
            Debug.Log("right");
            //SetDirection(Vector2.right);
            SetDirection(Vector2.right, spriteRendererRight);
        } else {
            Debug.Log("zero");
            //SetDirection(Vector2.zero);
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
    //    {
    //        DeathSequence();
    //    }
    //}

    //private void DeathSequence()
    //{
    //    enabled = false;
    //    GetComponent<BombController>().enabled = false;

    //    spriteRendererUp.enabled = false;
    //    spriteRendererDown.enabled = false;
    //    spriteRendererLeft.enabled = false;
    //    spriteRendererRight.enabled = false;
    //    spriteRendererDeath.enabled = true;

    //    Invoke(nameof(OnDeathSequenceEnded), 1.25f);
    //}

    //private void OnDeathSequenceEnded()
    //{
    //    gameObject.SetActive(false);
    //    GameManager.Instance.CheckWinState();
    //}

}
