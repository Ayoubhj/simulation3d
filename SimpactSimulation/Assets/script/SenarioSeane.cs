using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenarioSeane : MonoBehaviour
{

    // [SerializeField] private PlayableDirector director;
    // [SerializeField] private GameObject walkingCode;
    // [SerializeField] private PlayableDirector TalkingTimeLine;
    // [SerializeField] private PlayableDirector IdleTimeline;
    // [SerializeField] private GameObject panel;
    // [SerializeField] private Button NextButoon;
    // [SerializeField] private GameObject childPanel;
    // [SerializeField] private TextAsset speech;
    // [SerializeField] private getDataJson instance;
    // [SerializeField] private LoadQuiz quiz;
    // [SerializeField] private ToggleGroup toggleGroup;
    // [SerializeField] private GameObject subtitle;
    // [SerializeField] private GameObject PanelSubtitle;
    // [HideInInspector] [SerializeField] private getDataJson.answer answer_delegue;
    // [HideInInspector] [SerializeField] private getDataJson.answer answer_doctor;
    // [SerializeField] private AudioSource voiceSpeech;
    // [SerializeField] private AudioClip[] audioClipArray;

    // private float audioLenght;
    // private int currentSpeech = -1;
    // private bool isStopped = true;
    // private bool isFinish = false;
    // [HideInInspector] [SerializeField]  private getDataJson.UserResponses[]  answersList ;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     director = director.GetComponent<PlayableDirector>();
    //     TalkingTimeLine = TalkingTimeLine.GetComponent<PlayableDirector>();
    //     IdleTimeline = IdleTimeline.GetComponent<PlayableDirector>(); 
    //     answersList = new getDataJson.UserResponses[instance.JsonToArray(speech).speech.Length];
    //     Button btn = NextButoon.GetComponent<Button>();
    //     btn.onClick.AddListener(submitQuiz);
    //     voiceSpeech = voiceSpeech.GetComponent<AudioSource>();
    //     DataClass.setUserResponseLength(instance.JsonToArray(speech).speech.Length);
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     IdleTimeline.Play();
    //     if (walkingCode.active && isStopped && currentSpeech < (instance.JsonToArray(speech).speech.Length - 1 ))
    //     {
    //         currentSpeech++;
    //         isStopped = false;
    //         panel.SetActive(true);
    //         quiz.LoadQuizes(speech, instance, childPanel, currentSpeech);
    //         Debug.Log("panel is active ___Update___ " + currentSpeech);
    //     }
      
    // }


    //  public void submitQuiz()
    // {
    //     Toggle option = toggleGroup.ActiveToggles().FirstOrDefault();
    //     answer_delegue.id = option.transform.GetChild(2).GetComponent<Text>().text;
    //     answer_delegue.text = option.transform.GetChild(1).GetComponent<Text>().text;
    //     answer_delegue.voice = option.transform.GetChild(3).GetComponent<Text>().text;
    //     answer_delegue.score = Int32.Parse(option.transform.GetChild(4).GetComponent<Text>().text);
    //     answer_delegue.ref_choice = option.transform.GetChild(5).GetComponent<Text>().text;
    //     answersList[currentSpeech] = new getDataJson.UserResponses();
    //     answersList[currentSpeech].id = answer_delegue.id;
    //     answersList[currentSpeech].score = answer_delegue.score;
    //     DataClass.addResponse(answer_delegue.id, answer_delegue.score);
    //     foreach (var answer in instance.JsonToArray(speech).speech[currentSpeech].doctor)
    //     {
    //         if (answer.ref_choice.Equals(answer_delegue.id))
    //         {
    //             answer_doctor.id = answer.id;
    //             answer_doctor.text = answer.text;
    //             answer_doctor.voice = answer.voice;
    //             answer_doctor.score = answer.score;
    //             answer_doctor.ref_choice = answer.ref_choice;
    //         }
    //     }
    //     if (currentSpeech < (instance.JsonToArray(speech).speech.Length - 1 ))
    //     {
    //         isFinish = false;
    //     }else{
    //         isFinish = true;
    //     }
    //     PanelSubtitle.SetActive(true);
        
    //     StartCoroutine(Senario(0,answer_delegue,answer_doctor,TalkingTimeLine,voiceSpeech,subtitle,audioClipArray,isFinish));
        

    // }
    // IEnumerator TheSequence(float seconde, string textSpeech, GameObject textBox)
    // {
    //     yield return new WaitForSeconds(seconde);
    //     textBox.GetComponent<Text>().text = textSpeech;
    // }

    // IEnumerator Senario(float time, getDataJson.answer delegue , getDataJson.answer dcotor, PlayableDirector timeline_talking, AudioSource voice_speech, GameObject subtitle_object , AudioClip[] audioClips, bool is_finished)
    // {
    //     float audio_lenght = 0.0f;
    //     yield return new WaitForSeconds(time);

    //     panel.SetActive(false);
    //     foreach (AudioClip clip in audioClips)
    //     {
    //         if (clip.name + ".mp3" == delegue.voice)
    //         {
    //                 voice_speech.PlayOneShot(clip);
    //                 timeline_talking.time = 0;
    //                 timeline_talking.Pause();
    //                 StartCoroutine(TheSequence(0, delegue.text, subtitle_object));
    //                 audio_lenght = clip.length ;
                  
    //         }
    //     }
    //     yield return new WaitForSeconds(audio_lenght + 0.2f);
    //     if (!voice_speech.isPlaying)
    //     {
    //         foreach (AudioClip clip in audioClips)
    //         {
    //             if (clip.name + ".mp3" == dcotor.voice)
    //             {
                    
    //                 timeline_talking.Play();
    //                 voice_speech.PlayOneShot(clip);
              
    //                 StartCoroutine(TheSequence(0, dcotor.text, subtitle_object));
    //                 audio_lenght = clip.length;
                    
    //             }
    //         }
    //     }
    //     yield return new WaitForSeconds(audio_lenght + 0.2f);
    //     PanelSubtitle.SetActive(true);
        
    //     if(!is_finished){
    //         PanelSubtitle.SetActive(false);
    //         isStopped = true;
    //         panel.SetActive(true);
    //         Debug.Log("panel is active " + currentSpeech);
    //     }else{
    //         panel.SetActive(false);
    //         isStopped = false;
    //         timeline_talking.Pause();
    //         Debug.Log("panel is desibled " + currentSpeech);
    //         Debug.Log("Score total: " + DataClass.getTotalScore());
    //         SceneManager.LoadScene(2);
    //         /*for(int i = 0; i < DataClass.Length; i++){
    //             Debug.Log("id:" + answersList[i].id + "  score:" + answersList[i].score);
    //         }*/

    //     }
    // }
}
