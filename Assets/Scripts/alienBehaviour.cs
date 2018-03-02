using UnityEngine;
using System.Collections;

public class alienBehaviour : MonoBehaviour {

    public Animator doorAnim;
    public Animator bubbleAnim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setOrder(int order)
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    void closeDoor()
    {
        doorAnim.SetTrigger("CloseDoor");
    }

    void openDoor()
    {
        doorAnim.SetTrigger("OpenDoor");
    }

    void spawnBubble()
    {
        bubbleAnim.SetTrigger("Appear");
    }
}
