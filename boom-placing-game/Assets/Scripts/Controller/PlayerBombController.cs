using System.Collections;
using UnityEngine;

public class PlayerBombController : MonoBehaviour
{
    //Player General
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;

    // Player settings
    public int heartCount = 3;
    private bool isEvening = false;

    private void Awake()
    {
        Debug.Log("Instance PlayerBombController is creating...");
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
        spriteRendererDeath.enabled = true;

        // lock heart, movement
        isEvening = true;
        OnEveningMovementController(true);

        StartCoroutine(ResetIsEveningChange());

        heartCount--;
        Debug.Log("Blood: " + heartCount);
        Debug.Log("Blood: " + (heartCount <= 0));
        if (heartCount <= 0)
        {
            Invoke(nameof(OnPlayerDeath), 1.25f);
        }
        else
        {
            Invoke(nameof(AfterSubtractBlood), 1f);
        }
    }

    private void AfterSubtractBlood()
    {
        spriteRendererDown.enabled = true;
        spriteRendererDeath.enabled = false;
    }

    private void OnPlayerDeath()
    {
        gameObject.SetActive(false);
        GetComponent<BombController>().enabled = false;
    }

    IEnumerator ResetIsEveningChange()
    {
        yield return new WaitForSeconds(1.0f);
        OnEveningMovementController(false);
        isEvening = false;
    }

    private void OnEveningMovementController(bool isEvening)
    {
        PlayerMovementController movementScript = GetComponent<PlayerMovementController>();
        movementScript.isEvening = isEvening;
    }
}
