using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 8.0f; // Movement speed of the paddle
    private float halfWidth; // �����̕���ۑ�����ϐ�
    public float minX = -2.0f; // Minimum x position
    public float maxX = 2.0f; // Maximum x position

    void Start()
    {
        halfWidth = transform.localScale.x / 2; // Paddle�̔����̕����v�Z
        minX += halfWidth; // minX�ɔ����̕���ǉ�
        maxX -= halfWidth; // maxX���甼���̕������Z
    }

    void Update()
    {
        float horizontalInput = 0.0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1.0f; // Move left
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1.0f; // Move right
        }

        Vector2 newPosition = transform.position;
        newPosition.x += horizontalInput * speed * Time.deltaTime; // Calculate new position
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); // Clamp position to screen bounds
        transform.position = newPosition; // Set new position
    }
}
