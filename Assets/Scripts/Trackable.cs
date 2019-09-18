using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Trackable : MonoBehaviour, ITrackableEventHandler
{
    public GameObject hrm;
    public GameObject left;
    public GameObject right;
    //public GameObject HR;
    //public GameObject SCR;
    private TrackableBehaviour mTrackableBehaviour;

    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {

            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    protected virtual void OnTrackingFound()
    {
        if (mTrackableBehaviour.TrackableName.Equals("Heart"))
        {
            //HR.AddComponent<Inlet>();
            hrm.GetComponent<SWP_HeartRateMonitor>().enabled = true;
        }
        else if(mTrackableBehaviour.TrackableName.Equals("Sweat"))
        {
            //SCR.AddComponent<Inlet2>();
            left.SetActive(true);
            right.SetActive(true);
        }
    }


    protected virtual void OnTrackingLost()
    {
        if (mTrackableBehaviour.TrackableName.Equals("Heart"))
        {
            hrm.GetComponent<SWP_HeartRateMonitor>().enabled = false;
        }
        else if (mTrackableBehaviour.TrackableName.Equals("Sweat"))
        {
            left.SetActive(false);
            right.SetActive(false);
        }
    }

}
