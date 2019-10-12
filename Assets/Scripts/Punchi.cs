using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punchi : MonoBehaviour
    
{
       
    private ISnakeController myController;

    //JUMP
    //private bool onAir;
    private int airTime;
    [SerializeField] private int jumpLength = 100;

    private SnakeHead myHead;
    private Animator myAnimator;
    private SnakeMovement myMovement;
    
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
        //Jumpy stuff horrible
        if (airTime > 0)
        {
            airTime--;
        }
        
        if (airTime < 0)
        {
           // onAir = false;
            bool isJumping = IsJumping();
            if (isJumping)
            {
                airTime = jumpLength;
                myHead.Jump();
                myAnimator.SetTrigger("Jump");
                
            }
            else
            {
                myHead.Land();
                airTime = 0;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
