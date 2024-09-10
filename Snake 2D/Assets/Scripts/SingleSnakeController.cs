using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SingleSnakeController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right;


    private float moveDelay = .1f;
    private float moveTimer;

    public bool isShieldActive = false;
    public bool isBombSpeedActive = false;
    public bool isBoostScoreActive = false;

    public GameObject tailPrefab;
    public List<Transform> tail = new List<Transform>();

    public GameObject LeftWall;
    public GameObject RightWall;
    public GameObject TopWall;
    public GameObject BottomWall;

    private int score = 0;
    public PlayerState playerState;

    float powerupTimer = 0;
    public bool isFlag = false;
    private void Start()
    {
        playerState = PlayerState.ALIVE;
        transform.position = new Vector2(0.5f, 0.5f);
        tail.Add(transform);
    }
    private void Update()
    {
        if (GetPlayerState() == PlayerState.ALIVE)
        {
            //Debug.Log("update");
            HandleInput();
            move();
            IfInsideTheBox();

        }
    }


    private void IfInsideTheBox()
    {
        if (transform.position.x > RightWall.transform.position.x - 1f)
        {
            transform.position = new Vector2(LeftWall.transform.position.x + 1f, transform.position.y);
        }
        if (transform.position.x < LeftWall.transform.position.x + 1f)
        {
            transform.position = new Vector2(RightWall.transform.position.x - 1f, transform.position.y);
        }

        if (transform.position.y > TopWall.transform.position.y - .6f)
        {
            transform.position = new Vector2(transform.position.x, BottomWall.transform.position.y + 1f);
        }

        if (transform.position.y < BottomWall.transform.position.y + .6f)
        {
            transform.position = new Vector2(transform.position.x, TopWall.transform.position.y - 1f);
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
            transform.position = new Vector2(Mathf.Round(transform.position.x + moveDirection.x),
              Mathf.Round(transform.position.y + moveDirection.y));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "RedApple")
        {
            Grow();
            Scored();
        }

        if (other.tag == "Tail")
        {
            PlayerDeath();

        }

        if (other.tag == "BlackApple")
        {
            if (!isShieldActive)
                RemoveTail();

            DecreaseScore();
        }
        if (other.tag == "EasterEgg")
        {
            ActivateShield();
        }
        if (other.tag == "SpeedBomb")
        {
            ActivateBombSpeed();
        }
        if (other.tag == "Biscut")
        {
            if (!isBoostScoreActive)
                isBoostScoreActive = true;

        }

    }

    private void DecreaseScore()
    {
        score -= 1;
    }

    private void IncreaseScore(int point)
    {
        score += point;
    }

    private void Scored()
    {
        int n = 1;
        if (!isBoostScoreActive)
        {
            Debug.Log("Scored");

            IncreaseScore(n);
        }
        if (isBoostScoreActive)
        {
            Debug.Log("Score Boosted");
            IncreaseScore(n * 2);
            StartCoroutine(DeactivateScoreBoostAfterTime(3));
        }

    }

    private IEnumerator DeactivateScoreBoostAfterTime(int time)
    {
        yield return new WaitForSeconds(time);
        isBoostScoreActive = false;
    }

    private void PlayerDeath()
    {
        // Debug.Log("value is " + tail.Count);

        if (tail.Count < 3)
        {
            // Debug.Log(" Tail entered1");

            isFlag = false;
        }

        if (isFlag)
        {
            //Debug.Log("Shield entered");

            if (!isShieldActive)
                SetPlayerState(PlayerState.DEAD);
        }

        isFlag = true;
    }

    private void ActivateBombSpeed()
    {
        if (!isBombSpeedActive)
        {
            moveDelay = .05f;
            isBombSpeedActive = true;
            StartCoroutine(DeactivateBombAfterTime(3f));
        }
    }

    private IEnumerator DeactivateBombAfterTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        moveDelay = .1f;
        isBombSpeedActive = false;
    }

    private void ActivateShield()
    {
        if (!isShieldActive)
        {
            isShieldActive = true;
            StartCoroutine(DeactivateShieldAfterTime(3f));
        }
    }

    private IEnumerator DeactivateShieldAfterTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        isShieldActive = false;
    }

    public void Grow()
    {
        GameObject tailSegment = Instantiate(tailPrefab);
        tailSegment.transform.position = tail[tail.Count - 1].position;
        tail.Add(tailSegment.transform);
    }

    public void RemoveTail()
    {
        if (tail.Count > 1)
        {
            // Debug.Log("removed");
            Transform lastTail = tail[tail.Count - 1];
            tail.RemoveAt(tail.Count - 1);
            Destroy(lastTail.gameObject);
        }
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public void SetPlayerState(PlayerState state)
    {
        playerState = state;
    }
}
