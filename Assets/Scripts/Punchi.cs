using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchi : MonoBehaviour
    
{
       
    private ISnakeController myController;

    //JUMP
    //private bool onAir;
    private float airTime;
    [SerializeField] private int jumpLength = 200;

    private SnakeHead myHead;
    private Animator myAnimator;
    private SnakeMovement myMovement;

    bool isJumping = false;

    //



    // Start is called before the first frame update
    void Start()
    {
        myHead = GetComponent<SnakeHead>();
        myAnimator = myHead.GetComponent<Animator>();
        myMovement = GetComponent<SnakeMovement>();
        

    }
    void Awake() {

        myController = GetComponent<ISnakeController>();
        
        //onAir = false;

    }


    void FixedUpdate()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //   Debug.Log("AirTime=" + airTime);
        //Jumpy stuff horrible
        if (airTime > 0)
        {

            airTime--;

            if (airTime == 1)
            {
                myHead.Land();
                //airTime = 0;

            }

        }


        else
        {
            // onAir = false;
            isJumping = IsJumping();
            if (isJumping)
            {

                airTime = jumpLength;
                myHead.Jump();
                myAnimator.SetTrigger("Jump");

            }
        }


    }

        public bool IsJumping() 
    {
        if (myMovement.isMoving)
        {
            return myController.GetJump();
        }
        else return false;
        //return myController.GetJump();
    }
}
