using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartRateManager : MonoBehaviour
{

    public Text hr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<SWP_HeartRateMonitor>())
        {
            //hr.text = this.GetComponent<SWP_HeartRateMonitor>().BeatsPerMinute + "";
            hr.text = Global.HR + "";
            this.GetComponent<SWP_HeartRateMonitor>().BeatsPerMinute = Global.HR;
        }
    }

    public void changeSize()
    {
        Debug.Log("size");
    }
}
