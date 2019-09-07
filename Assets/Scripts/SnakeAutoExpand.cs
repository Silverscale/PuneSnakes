using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeHead))]
public class SnakeAutoExpand : MonoBehaviour
{
    [SerializeField] private float autoExpandCDInSeconds = 2f;
    [SerializeField] private SnakeBodyChunk bodyChunk = default;

    private SnakeHead mySnakeHead;
    private Coroutine expanding;
    private bool ImExpanding = false;

    void Awake() {
        mySnakeHead = GetComponent<SnakeHead>();
        autoExpandCDInSeconds = GameOptions.delay;
    }

    //Controls when the snake should start or stop expanding, based on mySnakeHead.IsActive
    void Update() {
        Debug.Log("Is Snake Active? " + mySnakeHead.IsActive);
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
        SnakeBodyChunk newFollower = GameObject.Instantiate<SnakeBodyChunk>(
                    bodyChunk,
                    mySnakeHead.TailPosition(),
                    Quaternion.identity,
                    transform.parent);

        newFollower.transform.localScale = Vector3.one * GameOptions.snakeScale;
        mySnakeHead.AddBodyChunk(newFollower);
    }
}
