using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;

public class VRcontrl : MonoBehaviour
{/*
    public SteamVR_Action_Boolean m_GrabAction = null;
    private SteamVR_Behaviour_Skeleton m_Pose = null;
    private FixedJoint m_Joint = null;

    private Interactable m_CurrentInteractable = null;
    public List<Interactable> m_contactInteractables = new List<Interactable>();

    private Vector3 velocity= new Vector3(0.0f, 0.0f, 0.0f);

    private void Awake(){
        m_Pose = GetComponent<SteamVR_Behaviour_Skeleton>();
        m_Joint = GetComponent<FixedJoint>();
    }
    private void Update(){
        //Down
        if(m_GrabAction.GetStateDown(m_Pose.inputSource)){
            print(m_Pose.inputSource + "Trigger Down");
            Pickup();
        }
        //Up

        if(m_GrabAction.GetStateUp(m_Pose.inputSource)){
            print(m_Pose.inputSource + "Trigger Up");
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other){
        if (!other.gameObject.CompareTag("Interactable"))   return;
        m_contactInteractables.Add(other.gameObject.GetComponent<Interactable>());
        print("TriggerEnter");
    }
    
    private void OnTriggerExit(Collider other){
        if (!other.gameObject.CompareTag("Interactable"))   return;
        m_contactInteractables.Remove(other.gameObject.GetComponent<Interactable>());

    }

    public void Pickup(){
        m_CurrentInteractable = GetNearesInteractable();

        if (!m_CurrentInteractable){
            print("if");
            return;
        }
        if (m_CurrentInteractable.m_ActiveHand){
            print("if.m_");
            m_CurrentInteractable.m_ActiveHand.Drop();
        }
        m_CurrentInteractable.transform.position = transform.position;

        print("pickup");
        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        m_Joint.connectedBody = targetBody;

        m_CurrentInteractable.m_ActiveHand = this;

    }

    public void Drop(){
        if (!m_CurrentInteractable){
            return;
        }

        Rigidbody targetBody = m_CurrentInteractable.GetComponent<Rigidbody>();
        targetBody.velocity = velocity;
        targetBody.angularVelocity = velocity;

        m_Joint.connectedBody = null;

        m_CurrentInteractable.m_ActiveHand = null;
        m_CurrentInteractable = null;

    }

    private Interactable GetNearesInteractable(){
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;

        foreach(Interactable interactable in m_contactInteractables){
            distance = (interactable.transform.position - transform.position).sqrMagnitude;
            if(distance <minDistance){
                minDistance = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }*/
}
