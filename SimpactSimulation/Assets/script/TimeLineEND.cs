using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using System.Globalization;


public class TimeLineEND : MonoBehaviour
{
    [SerializeField] private PlayableDirector director;
    [SerializeField] private PlayableDirector DoctorTalkingTimeLine;
    [SerializeField] private PlayableDirector ClientTalkingTimeLine;
    [SerializeField] private PlayableDirector IdleTimeline;
    [SerializeField] private PlayableDirector CameraDoctor;
    [SerializeField] private PlayableDirector CameraClient;
    [SerializeField] private GameObject panel;
    [SerializeField] private Button NextButoon;
    [SerializeField] private GameObject childPanel;
    [SerializeField] private TextAsset speech;
    [SerializeField] private getDataJson instance;
    [SerializeField] private LoadQuiz quiz;
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] private GameObject subtitle;
    [SerializeField] private GameObject PanelSubtitle;
    [HideInInspector] [SerializeField] private getDataJson.Question answer_delegue;
    [HideInInspector] [SerializeField] private getDataJson.Answer answer_doctor;
    [SerializeField] private AudioSource voiceDoctore;
    [SerializeField] private AudioSource voiceDelegue;
    [SerializeField] private AudioClip[] audioClipArray;

    private float audioLenght;
    private double timerTimeline = 0;
    private int currentSpeech = -1;
    private bool isStopped = true;
    private bool isFinish = false;
    private bool docotorTalk = false;
    private int lengthDataJson = 0;
    [HideInInspector] [SerializeField]  private getDataJson.UserResponses[]  answersList ;
    // Start is called before the first frame update
    void Start()
    {
        lengthDataJson = instance.JsonToArray(speech).dialogs.dialog.Length;
        director = director.GetComponent<PlayableDirector>();
        DoctorTalkingTimeLine = DoctorTalkingTimeLine.GetComponent<PlayableDirector>();
        ClientTalkingTimeLine = ClientTalkingTimeLine.GetComponent<PlayableDirector>();
        IdleTimeline = IdleTimeline.GetComponent<PlayableDirector>(); 
        answersList = new getDataJson.UserResponses[lengthDataJson];
        Button btn = NextButoon.GetComponent<Button>();
        btn.onClick.AddListener(submitQuiz);
        voiceDelegue = voiceDelegue.GetComponent<AudioSource>();
        voiceDoctore = voiceDoctore.GetComponent<AudioSource>();
        DataClass.setUserResponseLength(lengthDataJson);
        

        
    }



    // Update is called once per frame
    void Update()
    {
       
        IdleTimeline.Play();
        if (director.state == PlayState.Paused && isStopped && currentSpeech < (lengthDataJson - 1 ) && ( timerTimeline + Time.deltaTime) >= director.duration) 
        {
            currentSpeech++;
            isStopped = false;
            panel.SetActive(true);
            quiz.LoadQuizes(speech, instance, childPanel, currentSpeech);
            Debug.Log("panel is active ___Update___ " + currentSpeech);
        }
        if(director.time > 0){
            timerTimeline = director.time;
        }


        if (PauseManuMangment.GameisPaused == true)
        {
            Time.timeScale = 0f;
            voiceDoctore.Pause();
            voiceDelegue.Pause();
            DoctorTalkingTimeLine.Pause();
            ClientTalkingTimeLine.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            voiceDoctore.UnPause();
            voiceDelegue.UnPause();
            DoctorTalkingTimeLine.Resume();
            ClientTalkingTimeLine.Resume();
        }

    }

   

     public void submitQuiz()
    {
        
        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ".";

        string score = "";
        string step = "";
        string step_name = "";

        Toggle option = toggleGroup.ActiveToggles().FirstOrDefault();
        answer_delegue.id = option.transform.GetChild(2).GetComponent<Text>().text;
        answer_delegue.text = option.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Text>().text;
        answer_delegue.voice = option.transform.GetChild(3).GetComponent<Text>().text;
        answer_delegue.weight = option.transform.GetChild(4).GetComponent<Text>().text ;
        answer_delegue.answer = option.transform.GetChild(5).GetComponent<Text>().text ;
        score = option.transform.GetChild(6).GetComponent<Text>().text ;
        step = option.transform.GetChild(7).GetComponent<Text>().text ;
        step_name = option.transform.GetChild(8).GetComponent<Text>().text ;

        answersList[currentSpeech] = new getDataJson.UserResponses();
        answersList[currentSpeech].id = answer_delegue.id;
        answersList[currentSpeech].weight = Convert.ToDouble(answer_delegue.weight, provider);
        answersList[currentSpeech].score = Convert.ToDouble(score);
        answersList[currentSpeech].step = Int32.Parse(step);
        answersList[currentSpeech].step_name = step_name;

        DataClass.addResponse(answer_delegue.id, Convert.ToDouble(answer_delegue.weight, provider) , Convert.ToDouble(score) ,Int32.Parse(step) ,step_name );
        foreach (var answer in instance.JsonToArray(speech).dialogs.dialog[currentSpeech].answers.answer)
        {
            if (answer.id.Equals(answer_delegue.answer))
            {
                answer_doctor.id = answer.id;
                answer_doctor.gotodialog = answer.gotodialog;
                answer_doctor.text = answer.text;
                answer_doctor.voice = answer.voice;
            }
        }

        if (currentSpeech < (lengthDataJson - 1 ))
        {
            isFinish = false;
        }else{
            isFinish = true;
        }
        PanelSubtitle.SetActive(true);
        
        StartCoroutine(Senario(0,answer_delegue,answer_doctor, DoctorTalkingTimeLine, ClientTalkingTimeLine , voiceDoctore,voiceDelegue, subtitle,audioClipArray,isFinish));
        

    }
    IEnumerator TheSequence(float seconde, string textSpeech, GameObject textBox)
    {
        yield return new WaitForSeconds(seconde);
        textBox.GetComponent<Text>().text = textSpeech;
    }

    IEnumerator Senario(float time, getDataJson.Question delegue , getDataJson.Answer dcotor, PlayableDirector timeline_talking_doctor, PlayableDirector timeline_talking_client ,AudioSource voice_doctor, AudioSource voice_delegue, GameObject subtitle_object , AudioClip[] audioClips, bool is_finished)
    {
                Debug.Log("Senario doctor text:" +answer_doctor.text);
    
            float audio_lenght = 0.0f;
            yield return new WaitForSeconds(time);

            panel.SetActive(false);
            foreach (AudioClip clip in audioClips)
            {
                if (clip.name + ".mp3" == delegue.voice)
                {
                    CameraClient.Play();
                    timeline_talking_client.Play();
                    voice_delegue.PlayOneShot(clip);
                    StartCoroutine(TheSequence(0, delegue.text, subtitle_object));
                    audio_lenght = clip.length;

                }
            }
            yield return new WaitForSeconds(audio_lenght + 0.2f);
            timeline_talking_client.time = timeline_talking_doctor.playableAsset.duration; // set the time to the last frame
            timeline_talking_client.Evaluate(); // evaluates the timeline
            timeline_talking_client.Stop(); 
        if (!voice_delegue.isPlaying)
            {
                foreach (AudioClip clip in audioClips)
                {
                    if (clip.name + ".mp3" == dcotor.voice)
                    {
                        CameraDoctor.Play();
                        timeline_talking_doctor.Play();
                        voice_doctor.PlayOneShot(clip);
                        StartCoroutine(TheSequence(0, dcotor.text, subtitle_object));
                        audio_lenght = clip.length;

                    }
                }
            }
            yield return new WaitForSeconds(audio_lenght + 0.2f);
            timeline_talking_doctor.time = timeline_talking_doctor.playableAsset.duration; // set the time to the last frame
            timeline_talking_doctor.Evaluate(); // evaluates the timeline
            timeline_talking_doctor.Stop();
            
            PanelSubtitle.SetActive(true);

            if (!is_finished)
            {
                PanelSubtitle.SetActive(false);
                isStopped = true;
                panel.SetActive(true);
                Debug.Log("panel is active " + currentSpeech);
            }
            else
            {
                panel.SetActive(false);
                isStopped = false;
                timeline_talking_doctor.Pause();
                timeline_talking_doctor.time = 0;
                Debug.Log("panel is desibled " + currentSpeech);
                Debug.Log("Score total: " + DataClass.getTotalScore());
                SceneManager.LoadScene(2);
                /*for(int i = 0; i < DataClass.Length; i++){
                    Debug.Log("id:" + answersList[i].id + "  score:" + answersList[i].score);
                }*/

            }
        
    }



    
    // IEnumerator waitTime(float waittime) 
    // {

    //     yield return new WaitForSeconds(waittime + 0.1f);
    //     if (!voiceSpeech.isPlaying)
    //     {
    //         foreach (AudioClip clip in audioClipArray)
    //         {
    //             if (clip.name + ".mp3" == answer_doctor.voice)
    //             {
    //                 TalkingTimeLine.Play();
    //                 voiceSpeech.PlayOneShot(clip);
    //                 StartCoroutine(TheSequence(0, answer_doctor.text, subtitle));
    //                 audioLenght = clip.length;
    //             }
    //         }
    //     }
    //     yield return new WaitForSeconds(audioLenght + 0.1f);
    //     isStopped = true;
    //     panel.SetActive(true);
    // } 
}