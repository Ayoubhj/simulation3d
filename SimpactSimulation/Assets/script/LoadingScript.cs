using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScript : MonoBehaviour
{

    [SerializeField] private Animator transition;
    [SerializeField] private GameObject instance;

    // Start is called before the first frame update

    private float time = 2;
    // Update is called once per frame
    public void LoadGame(int sceneIndex)
    {
        instance.SetActive(true);
        StartCoroutine(LoadScene(sceneIndex));
    }

    IEnumerator LoadScene(int sceneIndex)

    {

       
        transition.SetTrigger("start");

        yield  return new WaitForSeconds(time);

        SceneManager.LoadSceneAsync(sceneIndex);
        
    

    }
} 
