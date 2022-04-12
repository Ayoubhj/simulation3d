using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class LoadQuiz : MonoBehaviour
{
    private GameObject gameobject;
    private GameObject[] ArrayOfGameObjects;

    
    public void LoadQuizes(TextAsset speech, getDataJson instance, GameObject childPanel, int currentSpeech)
    {

        getDataJson.Question[] questionData = instance.JsonToArray(speech).dialogs.dialog[currentSpeech].questions.question;
        int lengthData = instance.JsonToArray(speech).dialogs.dialog[currentSpeech].questions.question.Length;

        Debug.Log("befor :" + lengthData);
        for (int i = 0; i < lengthData; i++) {
            if(lengthData > 1){

                int randomIndex = Random.Range (0, lengthData -1) ;
                getDataJson.Question temp = questionData [ randomIndex ] ;
                questionData [ randomIndex ] = questionData [ 0 ] ;
                questionData [ 0 ] = temp ;
            }
         
      }

        Debug.Log("after :" + questionData);




        transform.GetChild(0).gameObject.SetActive(true);
        ArrayOfGameObjects =  GameObject.FindGameObjectsWithTag("Toggle(Clone)");
        for(var i = 0; i < ArrayOfGameObjects.Length; i++)
        {
            Destroy(ArrayOfGameObjects[i]);
        }
        foreach (var answer in questionData)
        {
            int step =  Int32.Parse(instance.JsonToArray(speech).dialogs.dialog[currentSpeech].step);
            gameobject = Instantiate(childPanel, transform);
            gameobject.tag = "Toggle(Clone)";
            gameobject.transform.GetComponentInChildren<Text>().text = answer.text;
            gameobject.transform.GetChild(2).GetComponent<Text>().text = answer.id;
            gameobject.transform.GetChild(3).GetComponent<Text>().text = answer.voice;
            gameobject.transform.GetChild(4).GetComponent<Text>().text = answer.weight;
            gameobject.transform.GetChild(5).GetComponent<Text>().text = answer.answer;
            gameobject.transform.GetChild(6).GetComponent<Text>().text = instance.JsonToArray(speech).dialogs.dialog[currentSpeech].score;
            gameobject.transform.GetChild(7).GetComponent<Text>().text = instance.JsonToArray(speech).dialogs.dialog[currentSpeech].step;
            gameobject.transform.GetChild(8).GetComponent<Text>().text = instance.JsonToArray(speech).steps.step[step].text;
        }



        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    
  
}
