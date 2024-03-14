using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public GameObject lightOB;
    public bool lightsAreOn;
    private float timer;
    public float timeToAutoOn = 10f;

    void Start()
    {
        lightsAreOn = true;
        lightOB.SetActive(true);
        timer = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown("z")) {
            InteractSwitch();
            timer = 0f;
        }

        if (!lightsAreOn) {
            timer += Time.deltaTime;
            if (timer >= timeToAutoOn) {
                InteractSwitch();
                timer = 0f;
            }
        }
    }

    public void InteractSwitch() {
        lightsAreOn = !lightsAreOn;
        lightOB.SetActive(lightsAreOn);
    }
}
