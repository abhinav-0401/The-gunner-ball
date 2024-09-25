using System.Collections;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    //The idea is to attach a spring joint to the camera gameobject and give some force to it so that it can come back and forth to create the effect

    // Here the Main camera is made the child of an empty game object(camera_follower) and camera follow script is attached on that. 
    // The camera_follower game object has given a rigidbody2d and that rigidbody is given to the attached rigidbody field in the spring joint in the MainCamera. 
    // Now the magnitude field is given a value of 50 and the linear drag of the camera rigidbody is increased to 15 so that the shaking can stop after a moment.   
    SpringJoint2D shakeJoint;
    private void Start()
    {
        shakeJoint = gameObject.GetComponent<SpringJoint2D>();//taking the spring joint on the camera object
    }
    public IEnumerator Shake(float magnitude)
    {
        float x = Random.Range(-0.1f, 0.1f) * magnitude;
        float y = Random.Range(-0.1f, 0.1f) * magnitude;

        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y), ForceMode2D.Impulse);

        shakeJoint.distance = 0;//this is done so that the camera object can return to its original position
        yield return 0;

    }
}
