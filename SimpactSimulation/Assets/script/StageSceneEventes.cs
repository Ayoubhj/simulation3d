using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSceneEventes : MonoBehaviour
{
    [SerializeField] private GameObject panle;
    public void Close()
    {
        panle.SetActive(false);
    }
}
