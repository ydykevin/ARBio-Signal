using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameObject HPanel;
    public GameObject SPanel;
    private float scale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void small()
    {
        scale = HPanel.transform.localScale.x;
        HPanel.transform.localScale = new Vector3(scale/1.2f, scale / 1.2f, scale / 1.2f);
        Global.sizeModifier /= 1.2f;
        scale = SPanel.transform.localScale.x;
        SPanel.transform.localScale = new Vector3(scale / 1.2f, scale / 1.2f, scale / 1.2f);
    }

    public void big()
    {
        scale = HPanel.transform.localScale.x;
        HPanel.transform.localScale = new Vector3(scale * 1.2f, scale * 1.2f, scale * 1.2f);
        Global.sizeModifier *= 1.2f;
        scale = SPanel.transform.localScale.x;
        SPanel.transform.localScale = new Vector3(scale * 1.2f, scale * 1.2f, scale * 1.2f);
    }

    public void left()
    {
        //HPanel.transform.Rotate(new Vector3(0, -45, 0));
        SPanel.transform.Rotate(new Vector3(0, -45, 0));
    }

    public void right()
    {
        //HPanel.transform.Rotate(new Vector3(0, 45, 0));
        SPanel.transform.Rotate(new Vector3(0, 45, 0));
    }
}
