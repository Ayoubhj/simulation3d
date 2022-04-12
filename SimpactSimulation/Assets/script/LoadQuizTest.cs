using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LoadQuizTest : MonoBehaviour
{

    public GameObject option_choise;
    [SerializeField] private TextAsset speech;
    [SerializeField] private getDataJson instance;
    public static int currentSpeech = 1;
    public ToggleGroup toggleGroup;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject;
        // getDataJson.SpeechJson delegueData = instance.JsonToArray(speech).speech [currentSpeech].delegue;
        foreach (var answer in instance.JsonToArray(speech).dialogs.dialog[currentSpeech].questions.question)
        {
            option_choise.GetComponentInChildren<Text>().text = answer.text;
            option_choise.transform.GetChild(2).GetComponent <Text>().text = answer.id;
            gameObject = Instantiate(option_choise, transform);
        }

        Destroy(option_choise);

    }

    public void submitQuiz(){
        Toggle option = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(option.name + " _ " + option.GetComponentInChildren<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
