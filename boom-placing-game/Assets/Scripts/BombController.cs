using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController : MonoBehaviour
{
    [Header("Bomb")]
    public GameObject bombPrefab;
    public KeyCode inputKey = KeyCode.LeftShift;
    public float bombFuseTime = 3f;
    public int bombAmount = 1;
    private int bombsRemaining;

    [Header("Explosion")]
    //public Explosion explosionPrefab;
    public LayerMask explosionLayerMask;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;

    //[Header("Destructible")]
    //public Tilemap destructibleTiles;
    //public Destructible destructiblePrefab;

    private void OnEnable()
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
        }
    }

    private IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        //Debug.Log(position.x + " " + position.y);

        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);
        Debug.Log(position.x + " " + position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        //Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        //explosion.SetActiveRenderer(explosion.start);
        //explosion.DestroyAfter(explosionDuration);

        //Explode(position, Vector2.up, explosionRadius);
        //Explode(position, Vector2.down, explosionRadius);
        //Explode(position, Vector2.left, explosionRadius);
        //Explode(position, Vector2.right, explosionRadius);

        //...
        Destroy(bomb);
        bombsRemaining++;
    }

   
}
