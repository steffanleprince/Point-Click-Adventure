using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.AI;

public class CameraAction : Actions
{
    CinemachineVirtualCamera mainCam;
    [SerializeField] CinemachineVirtualCamera switchCam;
    [SerializeField] private bool exiting;

    //[SerializeField] BoxCollider trigger;

    private void Start()
    {
        mainCam = GameObject.Find("PlayerCam").GetComponent<CinemachineVirtualCamera>();

    }

    public override void Act()
    {
        if (!exiting)
        {
            switchCam.Priority = 11;
            exiting= true;
        }
        else
            switchCam.Priority = 9;
            exiting= false;


    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " colliided with " + other.gameObject.name);
        //collided with

        if (!exiting)
        {
            switchCam.Priority = 11;
            exiting = true;
        }
        else
        {
            switchCam.Priority = 9;
            exiting = false;
        }

    }


}