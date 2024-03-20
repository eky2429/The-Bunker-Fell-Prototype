﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{    
    //Distance from which the player can interact with the door
    public float interactionDistance;

    //The text that appears to let you know you can interact with the door
    public GameObject intText;

    //The names of the door open and door close animations
    public string doorOpenAnimName, doorCloseAnimName;

    //The Update() void is where stuff occurs every frame
    void Update()
    {
       //A ray is created which will shoot forward from the player's camera
        Ray ray = new Ray(transform.position, transform.forward);

        //RaycastHit variable, which is used to get info back from whatever the raycast hits
        RaycastHit hit;

        //If the raycast hits something
        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            //If the object the raycast hits is tagged as door
            if (hit.collider.gameObject.tag == "door")
            {
                //A GameObject variable is created for the door's main parent object
                GameObject doorParent = hit.collider.transform.root.gameObject;

                //An Animator variable is created for the doorParent's Animator component
                Animator doorAnim = doorParent.GetComponent<Animator>();

                //The interaction text is set active
                intText.SetActive(true);

                //If the E key is pressed
                if (Input.GetKeyDown("e"))
                {
                    //If the door's Animator's state is set to the open animation
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        //The door's open animation trigger is reset
                        doorAnim.ResetTrigger("open");

                        //The door's close animation trigger is set (it plays)
                        doorAnim.SetTrigger("close");
                    }
                    //If the door's Animator's state is set to the close animation
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        //The door's close animation trigger is reset
                        doorAnim.ResetTrigger("close");

                        //The door's open animation trigger is set (it plays)
                        doorAnim.SetTrigger("open");
                    }
                }
            }
            //else, if not looking at the door
            else
            {
                //The interaction text is disabled
                intText.SetActive(false);
            }
        }
        //else, if not looking at anything
        else
        {
            //The interaction text is disabled
            intText.SetActive(false);
        }
    }
}