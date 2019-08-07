using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int playerNumber;
    private Follower follower;
    [SerializeField] private bool shouldAutoExpand = true;
    [SerializeField] private float autoExpandCDInSeconds = 2f;
    private bool alive = true;

    public Follower bodyChunk;
    private Coroutine expanding;
    private SnakeMovement myMovement;

    private Score score;

    void Start()
    {
        autoExpandCDInSeconds = GameOptions.delay;
        myMovement = GetComponent<SnakeMovement>();
        if (shouldAutoExpand)
        {
            expanding = StartCoroutine(AutoExpand());
        }

        score = GameObject.FindObjectOfType<Score>();
    }

    void FixedUpdate() {
        if (follower) {
            follower.AddStep(transform.position);
        }
    }

    private IEnumerator AutoExpand() {
        do {
            yield return new WaitForSeconds(autoExpandCDInSeconds);
            SpawnFollower();
        } while (true);
    }

    private void SpawnFollower() {
        Follower newFollower = GameObject.Instantiate<Follower>(bodyChunk, TailPosition(), Quaternion.identity, transform.parent);
        newFollower.transform.localScale = Vector3.one * GameOptions.snakeScale;
        if (follower) {
            follower.AddFollower(newFollower);
        }
        else {
            follower = newFollower;
            follower.InitializeSteps(transform.position);
        }
    }

    private Vector2 TailPosition() {
        Vector2 position = transform.position;
        if (follower) {
            position = follower.GetLastFollowerPosition();
        }
        return position;
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log("Checking collision");
        if(alive && col.gameObject != follower.gameObject)
        this.Kill();
    }

    public void Kill() {
        if (alive) {
            myMovement.Stop();
            follower.StopAll();
            StopCoroutine(expanding);
            alive = false;
            score.PlayerKill(this);
        }
    }
}
