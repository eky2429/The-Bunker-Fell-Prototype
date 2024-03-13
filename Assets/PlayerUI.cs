using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text text;
    private int totalTasks = 4;

    // Start is called before the first frame update
    void Start()
    {
        text.SetText("Tasks: 0/" + totalTasks.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
