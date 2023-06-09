using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    private bool left, center, right, isGround;

    void Start()
    {
        player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        left = true;
        right = true;
        center = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && left)
        {
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && right)
        {
            moveRight();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround || Input.GetKeyDown(KeyCode.UpArrow) && isGround)
        {
            jump();
        }
    }

    void moveLeft()
    {
        if (left && !center) // Para esquerda
        {
            player.position = new Vector3(-3f, player.position.y, player.position.z);
            left = false;
            right = true;
            center = true;
        }
        else if (!right && center) // Para o centro
        {
            player.position = new Vector3(0f, player.position.y, player.position.z);
            center = false;
            left = true;
            right = true;
        }
    }

    void moveRight()
    {
        if (right && !center) // Para direita
        {
            player.position = new Vector3(3f, player.position.y, player.position.z);
            right = false;
            left = true;
            center = true;
        }
        else if (!left && center) // Para o centro
        {
            player.position = new Vector3(0f, player.position.y, player.position.z);
            center = false;
            left = true;
            right = true;
        }
    }

    void jump()
    {
        rb.AddForce(new Vector3(0f, 7f, 0f), ForceMode.Impulse);
        isGround = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}
