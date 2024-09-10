using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is Friendly");
                break;
            case "Finish":
                Debug.Log("Hurray!!, you finished");
                break;
            case "Fuel":
                Debug.Log("You have Fuel");
                break;
            default:
                Debug.Log("Oopps, You Blew Up!!");
                break;
        }
    }
}
