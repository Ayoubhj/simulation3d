using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSelected : MonoBehaviour
{
    [HideInInspector] public static string doorName;

    void Start()
    {
        doorName = this.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
