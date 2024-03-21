
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
    public string doorOpenAnimName, doorCloseAnimName, doorIdleAnimName;

    //The Update() void is where stuff occurs every frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        //If the raycast hits something
        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            //If the object the raycast hits is tagged as door
            if (hit.collider.gameObject.tag == "door")
            {
                GameObject doorParent = hit.collider.transform.root.gameObject;

                Animator doorAnim = doorParent.GetComponent<Animator>();

                intText.SetActive(true);

                if (Input.GetKeyDown("e"))
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("idle");
                    }
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorIdleAnimName))
                    {
                        doorAnim.ResetTrigger("idle");
                        doorAnim.SetTrigger("open");
                    }
                }
            }
            else
            {
                intText.SetActive(false);
            }
        }
        else
        {
            intText.SetActive(false);
        }
    }
}