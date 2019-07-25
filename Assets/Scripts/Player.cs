using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly string wallTag = "Obstacle";
    private int playerNumber;
    private Follower follower;
    [SerializeField] private bool shouldAutoExpand = true;
    [SerializeField] private float autoExpandCDInSeconds = 2f;
    private bool alive = true;

    public Follower bodyChunk;
    private Coroutine expanding;
    private SnakeMovement myMovement;

    void Start()
    {
        myMovement = GetComponent<SnakeMovement>();
        if (shouldAutoExpand) {
            expanding = StartCoroutine(AutoExpand());
        }
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
        Debug.Log("Checking collision");
        if(alive && col.gameObject != follower.gameObject)
        this.Kill();
    }

    public void Kill() {
        if (alive) {
            myMovement.Stop();
            follower.StopAll();
            StopCoroutine(expanding);
            alive = false;
        }
    }
}
