using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerManager : MonoBehaviour
{
    public Text sc;
    private Move move;
    private float percentage;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Global.pointerDefault;
        InvokeRepeating("demoPointer", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (move != null)
        {
            float dist = Vector3.Distance(transform.localPosition, move.end);

            if (dist > 0.01f)
            {
                float timeFraction = (Time.time - move.startTime) / move.duration;
                transform.localPosition = Vector3.Lerp(move.start, move.end, timeFraction);
            }
            else
            {
                transform.localPosition = move.end;
                move = null;
            }
        }
        percentage = (transform.localPosition.x - Global.pointerMin.x) / (Global.pointerMax.x - Global.pointerMin.x);
        sc.text = percentage.ToString("0.00");
    }

    public void addMove(Vector3 end, float duration)
    {
        if (move==null)
        {
            move = new Move(transform.localPosition, end,Time.time,duration);
        }
        else
        {
            Debug.Log("interrupt");
            move.start = transform.localPosition;
            move.end = end;
            move.startTime = Time.time;
            move.duration = duration;
        }
    }

    void demoPointer()
    {
        float endX = Random.Range(Global.pointerMin.x, Global.pointerMax.x);
        percentage = Mathf.Abs((endX - transform.localPosition.x)) / (Global.pointerMax.x - Global.pointerMin.x) ;
        move = new Move(transform.localPosition, new Vector3(endX, transform.localPosition.y, transform.localPosition.z), Time.time,percentage*2);
        //Debug.Log("moving to "+endX+" "+ transform.localPosition.y+" "+ transform.localPosition.z);
        //Debug.Log("duration " + percentage * 2);
    }
}

public class Move
{
    public Vector3 start;
    public Vector3 end;
    public float startTime;
    public float duration;

    public Move(Vector3 start, Vector3 end, float startTime, float duration)
    {
        this.start = start;
        this.end = end;
        this.startTime = startTime;
        this.duration = duration;
    }
}