using UnityEngine;
using Assets.LSL4Unity.Scripts.AbstractInlets;

/// <summary>
/// Class: Inlet
/// Implements: AFloatInlet
/// Author: Carlos Tirado   <Carlos.A.TiradoCortes@student.uts.edu.au>
/// Resources: https://github.com/xfleckx/LSL4Unity
///     
/// Description: - This class is in charge of processing the input of data from an external source. Because we mostly will be receiving data from an EEG
///              device, you can follow the template of this class to create your own receiver that adapts to your needs. Please refer to the README
///              if you need more information.
///              - You can modify the values of the number of channels, and of the device name in the Unity Editor.
///              - Please bear in mind, that the DeviceName must match the name of what is sending the data through LSL, otherwise this won't work.
/// 
/// 
///           __,.__
///          /  ||  \               
///   ::::::| .-'`-. |::::::
///   :::::/.'  ||  `,\:::::
///   ::::/ |`--'`--'| \::::
///   :::/   \`/++\'/   \::: 
/// </summary>
public class Inlet : AFloatInlet
{

    /// <summary>
    /// The number of channels of the device which we are receving data from.
    /// </summary>
    [Tooltip("The number of channels the device sending the data has")]
    public int NumberOfChannels = 32;
    public float GSR;

    /// <summary>
    /// The name of the device that is sending the data.
    /// </summary>
    [Tooltip("The device name sending the data")]
    private string DeviceName = "";

    /// <summary>
    /// Holds the EEG data received.
    /// </summary>
    private EEGDataHolder holder;
    
    
    /// <summary>
    /// This function will process the data received, have it as you wish!
    /// </summary>
    /// <param name="newSample"></param>
    /// <param name="timeStamp"></param>
    protected override void Process(float[] newSample, double timeStamp)
    {
        GSR = newSample[0];
        Debug.Log("The new sample received is " + newSample[0] + " at the timestamp " + timeStamp+ gameObject.name);
        if (newSample[0] != 0)
        {
            Global.HR = (int) (60/newSample[0]);
        }
    }

    /// <summary>
    /// What happens when the connection is established and we are receiving data.
    /// TODO: Add more if you need
    /// </summary>
    public void StreamInitialized()
    {
        Debug.Log("There is a stream that just has been initialized");
    }

    /// <summary>
    /// What happens when the connection is suddentlu terminated.
    /// TODO: Modify this according to your needs.
    /// </summary>
    public void StreamTerminated()
    {
        Debug.Log("The stream has just been terminated.");
    }
}
