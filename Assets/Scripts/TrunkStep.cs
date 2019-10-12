using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkStep

    

{

    public readonly Vector2 stepPosition;
    public readonly bool high;

    // Start is called before the first frame update

    public TrunkStep(Vector2 stepPosParam, bool isHigh)
    {
        stepPosition = stepPosParam;
        high = isHigh;
    }
    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public bool IsHigh()
    {
        return high;
    }*/
}
