using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDataJson : MonoBehaviour
{


    public SpeechJson JsonToArray(TextAsset speech){
        SpeechJson speechJson = JsonUtility.FromJson<SpeechJson>(speech.text);
        return speechJson;
    }

    public int testDebug(){
        return 1;
    }

    [System.Serializable]
    public class Step
    {
        public string id;
        public string text;
    }
    [System.Serializable]
    public class Steps
    {
        public Step[] step;
    }

    [System.Serializable]
    public class Answer
    {
        public string id;
        public string gotodialog;
        public string text;
        public string voice;
    }
    
    [System.Serializable]
    public class Question
    {
        public string id;
        public string weight;
        public string answer;
        public string text;
        public string voice;
    }

    [System.Serializable]
    public class Questions
    {
        public Question[] question;
    }

    [System.Serializable]
    public class Answers
    {
        public Answer[] answer;
    }

    [System.Serializable]
    public class Dialog
    {
        public string id;
        public string score;
        public string who;
        public string step;
        public Questions questions;
        public Answers answers;

    }

    [System.Serializable]
    public class Dialogs
    {
        public Dialog[] dialog;

    }

    [System.Serializable]
    public class SpeechJson
    {
        public Steps steps;
        public Dialogs dialogs;
    }

    public class UserResponses
    {
        public string id;
        public double weight;
        public double score;
        public int step;
        public string step_name;
        
        public UserResponses()   {}     
        public UserResponses(string id, double weight, double score, int step, string step_name){
            this.id = id;
            this.weight = weight;
            this.score = score;
            this.step = step;
            this.step_name = step_name;
            
        }
    }

}
