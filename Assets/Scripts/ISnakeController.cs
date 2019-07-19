using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISnakeController {

    int PlayerNumber(); //returns 1 for player 1, 2 for player 2, etc.

    float GetInput();//returns the value of the inputAxis, to be used for turning.
}
