using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWingBehaviourScript : MonoBehaviour
{
    private const int UP = 0;
    private const int DOWN = 1;
    private const int LEFT = 2;
    private const int RIGHT = 3;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting...");
    }

    // Update is called once per frame
    void Update()
    {
        int? direction = GetArrowKeyPressed();

        if (direction.HasValue)
        {
            Move(direction);
        }
    }

    int? GetArrowKeyPressed()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return UP;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return DOWN;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            return LEFT;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return RIGHT;
        }

        return null; // Không nhận diện được phím nào
    }

    void Move(int? direction)
    {
        Vector3 moveDirection = Vector3.zero;

        switch (direction)
        {
            case UP:
                moveDirection = Vector3.up;
                break;
            case DOWN:
                moveDirection = Vector3.down;
                break;
            case LEFT:
                moveDirection = Vector3.left;
                break;
            case RIGHT:
                moveDirection = Vector3.right;
                break;
            default:
                // Trường hợp không nhận diện được hướng
                break;
        }

        // Di chuyển đối tượng theo hướng đã xác định
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}