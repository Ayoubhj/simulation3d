using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class caracterMovement : MonoBehaviour
{
    // Start is called before the first frame update

     [SerializeField] private NavMeshAgent playerNavMesh;
     [SerializeField] private AudioSource playerVoiceWalk;
     [SerializeField] private Camera playerCamera;
     [SerializeField] private Animator playerAnimator;
     [HideInInspector]  public bool firstClick = true;
     [HideInInspector] public bool iswalking;
     [SerializeField] private GameObject panle;
     float extraRotationSpeed;
    void Start()
    {
        panle.SetActive(false);
    }


    
        // Update is called once per frame
        void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return ;
        }
        if (Input.GetMouseButton(0))
        {
          
           
            Ray myray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myRaycastHit;

            if(Physics.Raycast(myray,out myRaycastHit))
            {
                playerNavMesh.speed = 2f;
                playerNavMesh.acceleration = 8f;
                playerNavMesh.SetDestination(myRaycastHit.point);
                playerVoiceWalk.Play();
                playerNavMesh.updateRotation = true;
                Vector3 newpoint = new Vector3(myRaycastHit.point.x, transform.position.y, myRaycastHit.point.z);
                transform.LookAt(newpoint);
                

            }
        }

        if(playerNavMesh.remainingDistance <= playerNavMesh.stoppingDistance + 0.1)
        {
            iswalking = false;
            playerNavMesh.updateRotation = false;
            playerVoiceWalk.Pause();
        }
        else
        {
            iswalking = true;
           
        }
       
        playerAnimator.SetBool("iswalking", iswalking);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.CompareTag("Door"))
        {
           
            panle.SetActive(true);
            
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            panle.SetActive(false);
        }
    }
}
