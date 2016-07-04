using UnityEngine;
using System.Collections;


public class PlayerCtl : MonoBehaviour {
    public Animation _animation;
    public Anim anim;
    
	// Use this for initialization
	void Start () {
        _animation = GetComponentInChildren<Animation>();
        _animation.clip = anim.idle;
        _animation.Play();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
