using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteLayer : MonoBehaviour
{
    [SerializeField] private int sortingStartingNumber = 1000;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer colorRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        int positionInTheLine = GetComponentInParent<Follower>().numberInLine;
        int sortingOrder = sortingStartingNumber - (positionInTheLine * 2);
        myRenderer.sortingOrder = sortingOrder;
        colorRenderer.sortingOrder = sortingOrder + 1;
    }
}
