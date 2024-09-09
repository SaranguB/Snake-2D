using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSnakeController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right;
    public int speed;

    private float moveDelay = .1f;
    private float moveTimer;

    public GameObject tailPrefab;
    public List<Transform> tail = new List<Transform>();

    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject TopWall;
    public GameObject BottomWall;

    public bool isFlag = false;
    private void Start()
    {
        transform.position = new Vector2(0.5f, 0.5f);
        tail.Add(transform);
    }
    private void Update()
    {
        HandleInput();
        move();
        IfInsideTheBox();
    }

    private void IfInsideTheBox()
    {
       if(transform.position.x >14f)
        {
            transform.position = LeftWall.transform.position;
        }
    }

    private void HandleInput()
    {


        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            && moveDirection != Vector2.right)
        { moveDirection = Vector2.left; }

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.S))
            && moveDirection != Vector2.left)
        { moveDirection = Vector2.right; }

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            && moveDirection != Vector2.down)
        { moveDirection = Vector2.up; }

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            && moveDirection != Vector2.up)
        { moveDirection = Vector2.down; }

    }

    private void move()
    {

        moveTimer += Time.deltaTime;
        if (moveTimer >= moveDelay)
        {
            for (int i = tail.Count - 1; i > 0; i--)
            {
                tail[i].position = tail[i - 1].position;
            }

            moveTimer = 0;
            transform.position = new Vector2(Mathf.Round(transform.position.x + moveDirection.x * speed),
              Mathf.Round(transform.position.y + moveDirection.y * speed));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Food")
        {
            Grow();
        }

        if (other.tag == "Tail")
        {
            if (isFlag)
            {
               // Debug.Log("dead");
            }

            isFlag = true;
        }
    }

    public void Grow()
    {
        GameObject tailSegment = Instantiate(tailPrefab);
        tailSegment.transform.position = tail[tail.Count - 1].position;
        tail.Add(tailSegment.transform);
    }

}
