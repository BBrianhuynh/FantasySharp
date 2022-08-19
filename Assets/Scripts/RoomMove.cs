using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//uses Unity's UI system
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    //Instances that handles the UI on when to show up, update the title card, and when not to show up
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    // Start is called before the first frame update
    void Start()
    {
        cam=Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition+=cameraChange;
            cam.maxPosition+=cameraChange;
            other.transform.position+=playerChange;
            if(needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    //A method that determines how long the UI should stay up for
    private IEnumerator placeNameCo()
    {
        //text.SetActive(boolean) is essentially where you can decide if you want the actual component in Unity is on or off
        //It is like checking the box in the inspector section but you do it through code where it can be automated
        text.SetActive(true);
        placeText.text=placeName;
        //yield return WaitForSeconds(#) is where before a code below it runs, you must wait for a specificied # of seconds where as # 
        //can be any number the developer chooses before the line of code below it can run
        yield return new WaitForSeconds(4);
        text.SetActive(false);
    }
}
