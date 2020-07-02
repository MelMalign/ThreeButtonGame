﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().hasKey)
        {

            Vector3 newPos = player.transform.position;
            newPos.y += 1;

            gameObject.transform.position = newPos;
            
        }
    }
}
