using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class ShowResult : MonoBehaviour
{
    [SerializeField] private GameObject table;
    private GameObject line;

    [HideInInspector] private static double  score_questions = 0 ;
    [HideInInspector] private static double  total_score = 0 ;
    [HideInInspector] private static int  step_dialog = 0 ;
    [HideInInspector] private double static_score = 0 ;

    // Start is called before the first frame update
    void Start()
    {
        
        line = table.transform.GetChild(1).gameObject;
        for(int i = 0; i < DataClass.getLength(); i++){
            getDataJson.UserResponses userResponse = DataClass.getResponse(i);
            static_score += userResponse.score;
            if(userResponse.step == step_dialog){
                score_questions += userResponse.score * userResponse.weight;
                if(i == DataClass.getLength() -1  ){
                    GameObject newLine = Instantiate(line, table.transform);
                    insertResult(newLine , userResponse);
                }
            }else{

                GameObject newLine = Instantiate(line, table.transform);
                insertResult(newLine , userResponse);
                score_questions += userResponse.score * userResponse.weight;
                
            }
            
        }

        Destroy(line);
        transform.GetChild(1).GetComponent<Text>().text = "Your Score: " + DataClass.getTotalScore() +"/"+static_score;
 
       // Debug.Log("Score from scen 2 => " + DataClass.getTotalScore());
       Debug.Log("Score totla => " + total_score);

    }


    public void insertResult(GameObject newLine,getDataJson.UserResponses userResponse){
        newLine.transform.GetChild(0).GetComponent<Text>().text = ""+(step_dialog +1) ;
        newLine.transform.GetChild(1).GetComponent<Text>().text = "Step "+userResponse.step_name;
        newLine.transform.GetChild(2).GetComponent<Text>().text = ""+ Mathf.RoundToInt((float)score_questions);
        total_score += score_questions;
        step_dialog ++;
        score_questions = 0.0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
