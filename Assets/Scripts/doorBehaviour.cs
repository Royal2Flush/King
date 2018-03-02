using UnityEngine;
using System.Collections;

public class doorBehaviour : MonoBehaviour {

    public Animator alienAnim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void startAlien()
    {
        alienAnim.SetTrigger("Come");
    }
}
