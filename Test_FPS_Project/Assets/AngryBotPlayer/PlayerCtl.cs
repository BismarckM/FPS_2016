using UnityEngine;
using System.Collections;

[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip runFoward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
}

public class PlayerCtl : MonoBehaviour {
    private Transform tr;
    private float moveSpeed = 5.0f;
    private float rotSpeed = 1.2f;
    private Vector3 moveDir;
    public Animation _animation;
    public Anim anim;

    private float beforePosition;

    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();
        _animation = GetComponentInChildren<Animation>();
        _animation.clip = anim.idle;
        _animation.Play();
	}
	
	// Update is called once per frame
	void Update () {
        //Touch touch = Input.GetTouch(0);
        //if (touch.phase == TouchPhase.Began)
        //{
        //    beforePosition = touch.position.x;
        //}
        //else
        //{
        //    tr.Rotate(Time.deltaTime * 3.0f * new Vector3(0, beforePosition - touch.position.x, 0));
        //    beforePosition = touch.position.x;
        //}

        float accelX = Input.acceleration.x;
        float accelY = -Input.acceleration.y;

        // character movement for left and right
        if(accelX < -0.8f) {
            accelX = 0.0f;
        }
        else if(accelX < -0.15f)
        {
           
        }
        else if(accelX < 0.15f)
        {
            accelX = 0.0f;
        }
        else if(accelX < 0.8f)
        {

        }
        else
        {
            accelX = 0.0f;
        }

        // character movement for forward and backward
        if (accelY < 0.0f)
        {
            accelY = 0.0f;
        }
        else if (accelY < 0.65f)
        {
           
        }
        else if (accelY < 0.85f)
        {
            accelY = 0.0f;
        }
        else if (accelY < 1.0f)
        {
            accelY = -accelY + 0.5f;
        }
        else
        {
            accelY = 0.0f;
        }

        moveDir = (new Vector3(accelX, 0, accelY)).normalized;
        tr.Translate(moveDir * Time.deltaTime * moveSpeed, Space.Self);

        // for animation
        if (moveDir.x > 0.0f && moveDir.z >= 0.0f && moveDir.x > moveDir.z)
        {
            _animation.CrossFade(anim.runRight.name, 0.1f);
        }
        else if (moveDir.x >= 0.0f && moveDir.z > 0.0f && moveDir.x <= moveDir.z)
        {
            _animation.CrossFade(anim.runFoward.name, 0.1f);
        }
        else if (moveDir.x > 0.0f && moveDir.z <= 0.0f && moveDir.x > -moveDir.z)
        {
            _animation.CrossFade(anim.runRight.name, 0.1f);
        }
        else if (moveDir.x >= 0.0f && moveDir.z < 0.0f && moveDir.x <= -moveDir.z)
        {
            _animation.CrossFade(anim.runBackward.name, 0.1f);
        }
        else if (moveDir.x < 0.0f && moveDir.z >= 0.0f && -moveDir.x > moveDir.z)
        {
            _animation.CrossFade(anim.runLeft.name, 0.1f);
        }
        else if (moveDir.x <= 0.0f && moveDir.z > 0.0f && -moveDir.x <= moveDir.z)
        {
            _animation.CrossFade(anim.runFoward.name, 0.1f);
        }
        else if (moveDir.x < 0.0f && moveDir.z <= 0.0f && -moveDir.x > -moveDir.z)
        {
            _animation.CrossFade(anim.runLeft.name, 0.1f);
        }
        else if (moveDir.x <= 0.0f && moveDir.z < 0.0f && -moveDir.x <= -moveDir.z)
        {
            _animation.CrossFade(anim.runBackward.name, 0.1f);
        }
        else if (moveDir.x == 0.0f && moveDir.z == 0.0f)
        {
            _animation.CrossFade(anim.idle.name, 0.1f);
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.1f);
        }
    }
}
