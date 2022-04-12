using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataClass 
{

  public static getDataJson.UserResponses[] listResponses;
  // Object[] dataScore = new Object[];

  public static int lastIndex = 0;
  public static void setUserResponseLength(int length){
      listResponses = new getDataJson.UserResponses[length];
  }

  public static getDataJson.UserResponses getResponse(int i){
     if(i < DataClass.getLength()) return listResponses[i];
     return null;
  }

  public static void addResponse(string id, double weight, double score, int step , string step_name){
      listResponses[lastIndex] = new getDataJson.UserResponses(id, weight, score, step ,step_name);
      lastIndex++;
  }

  public static int getLength(){
      return listResponses.Length;
  }

  public static int getTotalScore(){
    double score = 0;
    for(int i = 0; i < listResponses.Length; i++){
        score += listResponses[i].score * listResponses[i].weight;
    }
    
    return Mathf.RoundToInt((float)score);
  }


  //     public static int getTotalScore()
  //   {
  //       double score = 0;
  //       bool flag = false;
  //       for (int i = 0; i < listResponses.Length; i++)
  //       {
  //           for (int j = 0; j < dataScore.Length; i++)
  //           {
  //               if (listResponses[i].step == dataScore[j].step){
  //                 flag = true;
  //               }
  //           }
  //       }

  //       score += listResponses[i].score * listResponses[i].weight;

  //       return Mathf.RoundToInt((float)score); ;
  //   }
}
