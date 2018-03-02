using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    enum gs {start=0, waiting, prepareNext, coming, asking, leaving, dayEnd};
    gs gamestate;

    public Animator doorAnimator;
    public Animator alienAnimator;
    public Animator speechAnimator;
    public SpriteRenderer alien;

    // Use this for initialization
    void Start () {
        /*doorAnimator = GetComponent<Animator>();
        alienAnimator = GetComponent<Animator>();
        speechAnimator = GetComponent<Animator>();
        alien = GetComponent<SpriteRenderer>();*/

        gamestate = gs.start;
	}
	
	// Update is called once per frame
	void Update () {
	    /*switch (gamestate)
        {
            case gs.start:
                {
                    gamestate = gs.prepareNext;
                    break;
                }
            case gs.prepareNext:
                {
                    gamestate = gs.coming;
                    break;
                }
            case gs.coming:
                {
                    
                    gamestate = gs.waiting;
                    break;
                }
            case gs.asking:
                {
                    break;
                }
            case gs.leaving:
                {
                    break;
                }
        }*/
	}

    public void prepareNext()
    {
        doorAnimator.SetTrigger("OpenDoor");
    }
}
