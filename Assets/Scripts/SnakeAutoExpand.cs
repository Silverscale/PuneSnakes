using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeHead))]
public class SnakeAutoExpand : MonoBehaviour
{
    [SerializeField] private float autoExpandCDInSeconds = 2f;
    [SerializeField] private Follower bodyChunk = default;

    private SnakeHead mySnakeHead;
    private Coroutine expanding;
    private bool ImExpanding = false;

    void Awake() {
        mySnakeHead = GetComponent<SnakeHead>();
        autoExpandCDInSeconds = GameOptions.delay;
    }

    //Controls when the snake should start or stop expanding, based on mySnakeHead.IsActive
    void Update() {
        if (mySnakeHead.IsActive && !ImExpanding) {
            //The snake should start expanding
            expanding = StartCoroutine(AutoExpand());
            ImExpanding = true;
        } 
        else if (!mySnakeHead.IsActive && ImExpanding) {
            //The snake should stop expanding
            StopCoroutine(expanding);
            ImExpanding = false;
        }
    }

    //Continually spawns a bodyChunk after waiting for autoExpandCDInSeconds seconds
    private IEnumerator AutoExpand() {
        do {
            yield return new WaitForSeconds(autoExpandCDInSeconds);
            SpawnFollower();
        } while (true);
    }

    //Spawns a bodyChunk and gives it to SnakeHead to add it to the line.
    private void SpawnFollower() {
        Follower newFollower = GameObject.Instantiate<Follower>(
                    bodyChunk,
                    mySnakeHead.TailTransform().position,
                    mySnakeHead.TailTransform().rotation,
                    transform.parent);

        newFollower.transform.localScale = Vector3.one * GameOptions.snakeScale;
        mySnakeHead.AddFollower(newFollower);
    }
}
