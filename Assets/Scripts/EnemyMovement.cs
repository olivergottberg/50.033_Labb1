using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }

    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }

    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    // note that this is Update(), which still works but not ideal. See below.
    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {
            // move goomba
            Movegoomba();
        }
        else
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            Movegoomba();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLLISION: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("MARIO HIT GOOMBA");

            if (collision.transform.position.y > transform.position.y)
            {
                Debug.Log("PLAYER JUMPED ON GOOMBA");
            }
        }
    }

    public void Stomp()
    {
        GetComponent<Animator>().Play("GoombaStomp");
    }

    public void RemoveGoomba()
    {
        gameObject.SetActive(false);
    }

    public void GameRestart()
    {
        transform.localPosition = startPosition;
        originalX = transform.position.x;
        moveRight = -1;
        ComputeVelocity();
    }
}