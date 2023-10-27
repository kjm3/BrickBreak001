using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 8.0f; // Movement speed of the paddle
    public float minX = -8.0f; // Minimum x position
    public float maxX = 8.0f; // Maximum x position
    private bool canMove = true; // Paddle�������邩�ǂ����𔻒f����t���O

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �ڐG�����I�u�W�F�N�g�̃^�O��"Wall"�̏ꍇ
        if (collision.gameObject.tag == "Wall")
        {
            canMove = false; // Paddle�̓������~�߂�
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // �ڐG���������ꂽ�I�u�W�F�N�g�̃^�O��"Wall"�̏ꍇ
        if (collision.gameObject.tag == "Wall")
        {
            canMove = true; // Paddle�̓������ĊJ
        }
    }
}
