using UnityEngine;

public class SetSpriteLayer : MonoBehaviour
{
    [SerializeField] int layerNumberStepMultiplier = 2;
    [SerializeField] int layerNumberOffset = 0;
    private int sortingStartingNumber = 50;
    private int numberInLine;


    void Start()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();

        int sortingOrder = sortingStartingNumber - (numberInLine * layerNumberStepMultiplier) + layerNumberOffset;
        myRenderer.sortingOrder = sortingOrder;
    }

    public void SetNumberInLine(int linePosition) {
        numberInLine= linePosition;
    }
}
