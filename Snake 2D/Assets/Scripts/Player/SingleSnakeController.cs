using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingleSnakeController : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.right;

    [SerializeField] private bool isplayer1Active;

    private float moveDelay = .1f;
    private float moveTimer;

    private bool isShieldActive = false;
    private bool isBombSpeedActive = false;
    private bool isBoostScoreActive = false;

    [SerializeField] private PowerupUIController powerupUIController;
    [SerializeField] private GameObject tailPrefab;
    private List<Transform> tail = new List<Transform>();

    [SerializeField] private GameObject LeftWall;
    [SerializeField] private GameObject RightWall;
    [SerializeField] private GameObject TopWall;
    [SerializeField] private GameObject BottomWall;
    private int speed = 1;

    public ScoreController scoreController;

    private int score = 0;
    [SerializeField] private PlayerState playerState;

    private float powerupTimer = 0;
    private bool isFlag = false;
    private void Start()
    {
        playerState = PlayerState.ALIVE;
        //transform.position = new Vector2(0.5f, 0.5f);
        tail.Add(transform);
    }
    private void Update()
    {
        if (GetPlayerState() == PlayerState.ALIVE && SettingsController.Instance.GetGameState() == GameState.PLAY_MODE)
        {
            //Debug.Log("update");
            HandleInput();
            move();
            IfInsideTheBox();

        }

        //Debug.Log("PlayerState" + playerState);
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
        Vector2 newDirection = moveDirection;

        if (isplayer1Active)
        {
            if (Input.GetKey(KeyCode.UpArrow) && moveDirection != Vector2.down)
            {
                newDirection = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && moveDirection != Vector2.up)
            {
                newDirection = Vector2.down;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && moveDirection != Vector2.right)
            {
                newDirection = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && moveDirection != Vector2.left)
            {
                newDirection = Vector2.right;
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.W) && moveDirection != Vector2.down)
            {
                newDirection = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.D) && moveDirection != Vector2.left)
            {
                newDirection = Vector2.right;
            }
           else if (Input.GetKey(KeyCode.A) && moveDirection != Vector2.right)
            {
                newDirection = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.S) && moveDirection != Vector2.up)
            {
                newDirection = Vector2.down;
            }
        }

        if (moveDirection != newDirection)
            moveDirection = newDirection;



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

        if (other.gameObject.tag == "Cross")
        {
            if (!isShieldActive)
            {
                scoreController.ResetScore();
                SetPlayerState(PlayerState.DEAD);
            }
        }


        if (other.tag == "RedApple")
        {
            SoundManager.Instance.PlaySound(Sounds.POWERUP_SOUND);
            Grow();
            Scored();
        }

        if (other.tag == "Tail")
        {
            if (!isShieldActive)
                PlayerDeath();

        }

        if (other.tag == "BlackApple")
        {

            SoundManager.Instance.PlaySound(Sounds.POWERUP_SOUND);

            if (!isShieldActive)
                RemoveTail();

            scoreController.DecreaseScore(1);
        }
        if (other.tag == "EasterEgg")
        {
            SoundManager.Instance.PlaySound(Sounds.POWERUP_SOUND);

            ActivateShield();
        }
        if (other.tag == "SpeedBomb")
        {
            SoundManager.Instance.PlaySound(Sounds.POWERUP_SOUND);

            ActivateBombSpeed();
        }
        if (other.tag == "Biscut")
        {
            SoundManager.Instance.PlaySound(Sounds.POWERUP_SOUND);

            ActivateScoreBoost();
        }



    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "YellowSnake" || other.gameObject.tag == "GreenSnake")
        {
            if (!isShieldActive)
            {
                SetPlayerState(PlayerState.DEAD);

            }
        }

    }


    private void ActivateScoreBoost()
    {
        if (!isBoostScoreActive)
        {
            isBoostScoreActive = true;
            powerupUIController.PowerupActivated("Boost");
            StartCoroutine(DeactivateScoreBoostAfterTime(3));

        }
    }

    private void Scored()
    {
        int n = 1;
        if (!isBoostScoreActive)
        {
            //Debug.Log("Scored");

            scoreController.IncreaseScore(n);
        }
        if (isBoostScoreActive)
        {
            
            scoreController.IncreaseScore(n * 2);
        }

    }

    private IEnumerator DeactivateScoreBoostAfterTime(int time)
    {
        yield return new WaitForSeconds(time);
        powerupUIController.PowerupDeactivated("Boost");
        isBoostScoreActive = false;
    }

    private void PlayerDeath()
    {
        // Debug.Log("value is " + tail.Count);

        if (tail.Count < 3)
        {

            isFlag = false;
        }

        if (isFlag)
        {

            if (!isShieldActive)
            {

                SetPlayerState(PlayerState.DEAD);
            }
        }

        isFlag = true;
    }

    private void ActivateBombSpeed()
    {
        if (!isBombSpeedActive)
        {
            moveDelay = .05f;
            isBombSpeedActive = true;
            powerupUIController.PowerupActivated("Bomb");
            StartCoroutine(DeactivateBombAfterTime(3f));
        }
    }

    private IEnumerator DeactivateBombAfterTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        powerupUIController.PowerupDeactivated("Bomb");

        moveDelay = .1f;
        isBombSpeedActive = false;
    }

    private void ActivateShield()
    {

        if (!isShieldActive)
        {

            isShieldActive = true;
            powerupUIController.PowerupActivated("Shield");
            StartCoroutine(DeactivateShieldAfterTime(3f));
        }
    }

    private IEnumerator DeactivateShieldAfterTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        powerupUIController.PowerupDeactivated("Shield");

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
