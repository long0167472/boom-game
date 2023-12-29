using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody2D rigidbody {get; private set;}
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    
    //Player General
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    //Byte scene
    public AnimatedSpriteRenderer spriteRendererTakeDamage;

    private string sceneName;

    // Player settings
    public int heartCount = 3;
    private bool isEvening = false;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        rigidbody = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Update()
    {
        
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
            return;
        }
        if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);
            return;
        }
        if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
            return;
        }
        if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
            return;
        }
        if (direction != Vector2.zero)
        {
            SetDirection(Vector2.zero, spriteRendererDown);
            return;
        }
    }

    private void FixedUpdate()
    {
        if (!isEvening) 
        {
            Vector2 position = rigidbody.position;
            Vector2 translation = direction * speed * Time.fixedDeltaTime;

            rigidbody.MovePosition(position + translation);
        }
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        if (!isEvening)
        {
            direction = newDirection;

            spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
            spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
            spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
            spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;

            activeSpriteRenderer = spriteRenderer;
            activeSpriteRenderer.idle = direction == Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            SubtractBlood();
        }
    }

    private void SubtractBlood()
    {
        if (isEvening)
        {
            return;
        }
        spriteRendererUp.enabled = false;
        spriteRendererDown.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = false;

        if (SceneConst.SCENE_HAS_ITEMS.Equals(sceneName))
        {
            spriteRendererTakeDamage.enabled = false;
        }

        // lock heart
        isEvening = true;
        StartCoroutine(ResetIsEveningChange());

        heartCount--;
        Debug.Log("Blood: " + heartCount);
        Debug.Log("Blood: " + (heartCount <= 0));
        if (heartCount <= 0)
        {
            spriteRendererDeath.enabled = true;
            Invoke(nameof(OnPlayerDeath), 1.25f);
        } else
        {
            if (SceneConst.SCENE_HAS_ITEMS.Equals(sceneName))
            {
                spriteRendererTakeDamage.enabled = true;
            }
            Invoke(nameof(AfterSubtractBlood), 1f);
        }
    }

    private void AfterSubtractBlood()
    {
        gameObject.SetActive(true);
        spriteRendererDown.enabled = true;
        if (SceneConst.SCENE_HAS_ITEMS.Equals(sceneName))
        {
            spriteRendererTakeDamage.enabled = false;
        }
    }

    private void OnPlayerDeath()
    {
        gameObject.SetActive(false);
        GetComponent<BombController>().enabled = false;
        //FindObjectOfType<GameManager>().CheckWinState();
    }

    IEnumerator ResetIsEveningChange()
    {
        yield return new WaitForSeconds(1.0f);
        isEvening = false;
    }
    public void AddHeart()
    {
        if (heartCount == 3)
        {
            return;
        }else
        {
            heartCount++;
        }
        Debug.Log("Blood: " + heartCount);
    }
}
