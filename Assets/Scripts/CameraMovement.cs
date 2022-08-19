using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //FixedUpdate is called once whenever the physics system is set to tick
    /*LateUpdate always comes last(So that a camera follows it, you need LateUpdate so that
    this script does not occur before the PlayerMovement script.
    */
    void LateUpdate()
    {
       if(transform.position!=target.position)
       {
           //If the camera is not at the position of the character, it will move towards it
           /*updates the position through linear interpolation(Lerp) where it finds the distance
           between the current position and the target and moves a certain percentage towards it
           //Lerp takes in the parameter the current position, position of target, and the amount to cover
           */
           Vector3 targetPosition=new Vector3(target.position.x,target.position.y,transform.position.z);
           targetPosition.x=Mathf.Clamp(targetPosition.x,minPosition.x,maxPosition.x);
           targetPosition.y=Mathf.Clamp(targetPosition.y,minPosition.y,maxPosition.y);
           transform.position=Vector3.Lerp(transform.position,targetPosition,smoothing);
       }
    }
}
