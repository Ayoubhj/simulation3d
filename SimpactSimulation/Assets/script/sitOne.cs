 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sitOne : MonoBehaviour
{

    public GameObject character;
    public GameObject chair;
    public GameObject camera1;
    public GameObject camera2;
    Animator anim;
    bool isWalkingTowards = false;
    bool sittingOn = false;

    // void OnMouseDown(){
    //     // if(!sittingOn){

    //     //     anim.SetTrigger("isWalking");
    //     //     isWalkingTowards = true; 
    //     // }
        
    // }

    // Start is called before the first frame update
    void Start()
    {
        if(!sittingOn){

            Debug.Log("walking start ");

            anim.SetTrigger("isWalking");
            isWalkingTowards = true; 
            Debug.Log("walking end ");
        }
        anim = character.GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(!sittingOn){

            anim.SetTrigger("isWalking");
            isWalkingTowards = true; 
        }
        if(isWalkingTowards){
            Vector3 targetDir;
            targetDir = new Vector3(chair.transform.position.x - character.transform.position.x , 0f, chair.transform.position.z - character.transform.position.z);
            Quaternion rot = Quaternion.LookRotation(targetDir);
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot , 0.05f);
            character.transform.Translate(Vector3.forward * Time.deltaTime);

            if(Vector3.Distance(character.transform.position, this.transform.position) < 0.1){
                camera1.SetActive(false);
                camera2.SetActive(true);
                anim.SetTrigger("isSitting");

                //turn character around to align forward vector
                //with object's vector
                character.transform.rotation = this.transform.rotation;

                isWalkingTowards = false;
                sittingOn = true; 
            }
            // Vector3 targetDir;
            // targetDir = new Vector3(transform.position.x - character.transform.position.x , 0f, transform.position.z - character.transform.position.z);
            // Quaternion rot = Quaternion.LookRotation(targetDir);
            // character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot , 0.05f);
            // character.transform.Translate(Vector3.forward * 0.01f);

            // if(Vector3.Distance(character.transform.position, this.transform.position) < 0.6){
            //     anim.SetTrigger("isSitting");

            //     //turn character around to align forward vector
            //     //with object's vector
            //     character.transform.rotation = this.transform.rotation;

            //     isWalkingTowards = false;
            //     sittingOn = true; 
            // }
        }
        
    }
}
