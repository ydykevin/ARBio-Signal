using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class: EEGDataHolder
/// Implements: N/A
/// Author: Carlos Tirado   <Carlos.A.TiradoCortes@student.uts.edu.au>
///     
/// Description: - This class just holds an array of many EEGData sets, I though of this class as a way
///                 to hold all the EEGDatas of a device in one place. If you find a better way to do this,
///                 please, feel free to improve this.
/// 
/// 
///           __,.__
///          /  ||  \               
///   ::::::| .-'`-. |::::::
///   :::::/.'  ||  `,\:::::
///   ::::/ |`--'`--'| \::::
///   :::/   \`/++\'/   \::: 
/// </summary>
public class EEGDataHolder
{

    /// <summary>
    /// The number of channels of this specific device.
    /// </summary>
    private readonly int nChannels;

    /// <summary>
    /// Access the number of channes this specific headset has,
    /// BUT you can't change the number of channes after this 
    /// object has been created.
    /// </summary>
    public int NumberOfChannels
    {
        get { return nChannels; }
    }

    /// <summary>
    /// The name which this device is identified as, in case you need
    /// to differentiate different data holders
    /// </summary>
    private string deviceName;

    /// <summary>
    /// Access the value of the device name.
    /// </summary>
    public string DeviceName
    {
        get { return deviceName; }
        set { deviceName = value; }
    }

    /// <summary>
    /// This is the array holding all the data sets.
    /// </summary>
    private List<EEGData> dataSet;

    /// <summary>
    /// Access the data set.
    /// </summary>
    public List<EEGData> DataSet
    {
        get { return dataSet; }
    }

    /// <summary>
    /// Constructor, just assigns values.
    /// </summary>
    /// <param name="nChannels">The number of channes of the device, just as a reference.</param>
    /// <param name="deviceName">The name of the device, if you want to give it any.</param>
    public EEGDataHolder(int nChannels, string deviceName = "")
    {
        this.nChannels = nChannels;
        this.deviceName = deviceName;


        dataSet = new List<EEGData>();
    }

    /// <summary>
    /// Adds a data point to the list.
    /// </summary>
    /// <param name="data">An array with all the data.</param>
    /// <param name="timestamp">The timestamp of when that particular data set was created.</param>
    public void AddDataPoint(float[] data, double timestamp)
    {
        if (data.Length != nChannels)
        {
            Debug.LogError("You are trying to add data from an incorrect channel count.");
        }
        else
        {
            EEGData currentData = new EEGData(data, timestamp);
            dataSet.Add(currentData);
        }
    }

    /// <summary>
    /// Print the data set? haha
    /// </summary>
    public void DisplayDataSet()
    {
        // TODO: I don't know if this work xdxdxdxdxd
        string dataString = "[ ";
        dataString += dataSet.ToString() + " ] ";
        Debug.Log(dataString);

    }



}
