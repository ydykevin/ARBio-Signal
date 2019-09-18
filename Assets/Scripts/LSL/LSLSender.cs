using UnityEngine;
using LSL;

/// <summary>
/// Class: LSLSender
/// Implements: MonoBehaviour
/// Author: Carlos Tirado   <Carlos.A.TiradoCortes@student.uts.edu.au>
/// Resources: https://github.com/xfleckx/LSL4Unity
///     
/// Description: This is a class that encapsulates all the funcions needed to send a message through LSL.
///              Again, if you need something different, feel free to modify this class as you need it.
/// 
/// 
///           __,.__
///          /  ||  \               
///   ::::::| .-'`-. |::::::
///   :::::/.'  ||  `,\:::::
///   ::::/ |`--'`--'| \::::
///   :::/   \`/++\'/   \::: 
/// </summary>
public class LSLSender : MonoBehaviour
{

    // Not sure what this is for haha
    private const string unique_source_id = "D3F83BB699EB49AB94A9FA44B88882AB";

    /// <summary>
    /// Feel free to add more types of samples if you need them, remember to add 
    /// them to the array at the end.
    /// </summary>
    public enum TypesOfSamples
    {
        FLOAT_TYPE, INTEGER_TYE, STRING_TYPE
    }

    #region editableValues
    // These are the elements you can choose of what you will stream

    /// <summary>
    /// This is the name of your stream. When you have a software/app/game/etc that
    /// is receiving data from a stream, the way you know "who is who" is by setting
    /// a name to the stream.
    /// </summary>
    [Tooltip("The name of the stream you are sending")]
    public string lslStreamName = "Unity_<Paradigma_Name_here>";

    /// <summary>
    /// This is the type of data you are transmitting. The base types, which are ment
    /// to be compatible with the EEGLab plugin for MATLAB, are described on: https://github.com/sccn/xdf/wiki/Meta-Data
    /// You can create your own names, however, if you are not processing the data on 
    /// MATLAB's EEGLab.
    /// </summary>
    [Tooltip("The type of data you are transmitting.")]
    public string lslStreamType = "LSL_Marker_Strings";

    /// <summary>
    /// Setup the number of channels you are about to send? If you are about to send the
    /// 64 channes of EEG data, then set it to 64. Remember, the number of data should be
    /// a number of data points you want to send SIMULTANEOUSLY.
    /// </summary>
    [Tooltip("The number of channels this data outlet will send.")]
    public int lslChannelCount = 1;

    /// <summary>
    /// The type of data you are transmitting. If you want to transmit more
    /// than 2 types of data at the same time, then you need to create a new
    /// LSL Sender for that data type.
    /// </summary>
    [Tooltip("The type of data you will broadcast.")]
    public TypesOfSamples lslSampleType = TypesOfSamples.FLOAT_TYPE;
    #endregion

    // Managers to access the LSL .dll
    private liblsl.StreamInfo lslStreamInfo;
    private liblsl.StreamOutlet lslOutlet;


    //Assuming that markers are never send in regular intervalls
    private double nominal_srate = liblsl.IRREGULAR_RATE;

    private const liblsl.channel_format_t lslChannelFormat = liblsl.channel_format_t.cf_string;

    /// <summary>
    /// The different types of data you can send
    /// </summary>
    private string[] stringSample;
    private float[] floatSample;
    private int[] integerSample;

    void Awake()
    {
        // Setup the types of data we are sending.
        switch (lslSampleType)
        {
            case TypesOfSamples.FLOAT_TYPE:
                floatSample = new float[lslChannelCount];
                break;
            case TypesOfSamples.INTEGER_TYE:
                integerSample = new int[lslChannelCount];
                break;
            case TypesOfSamples.STRING_TYPE:
                stringSample = new string[lslChannelCount];
                break;
        }

        // Setup the information of the stream
        lslStreamInfo = new liblsl.StreamInfo(
                                        lslStreamName,
                                        lslStreamType,
                                        lslChannelCount,
                                        nominal_srate,
                                        lslChannelFormat,
                                        unique_source_id);

        // This will be used to send data.
        lslOutlet = new liblsl.StreamOutlet(lslStreamInfo);
    }

    /// <summary>
    /// Sends float data
    /// </summary>
    /// <param name="value"></param>
    public void SendData(float[] value)
    {
        if (value.Length == lslChannelCount)
        {
            floatSample = value;
            lslOutlet.push_sample(floatSample);
        }
        else
        {
            Debug.LogError("You are trying to assign an incorrect sample size.");
        }

    }

    /// <summary>
    /// Sends int data
    /// </summary>
    /// <param name="value"></param>
    public void SendData(int[] value)
    {
        if (value.Length == lslChannelCount)
        {
            integerSample = value;
            lslOutlet.push_sample(integerSample);
        }
        else
        {
            Debug.LogError("You are trying to assign an incorrect sample size.");
        }
    }

    /// <summary>
    /// Sends string data
    /// </summary>
    /// <param name="value"></param>
    public void SendData(string[] value)
    {
        if (value.Length == lslChannelCount)
        {
            stringSample = value;
            lslOutlet.push_sample(stringSample);
        }
        else
        {
            Debug.LogError("You are trying to assign an incorrect sample size.");
        }
    }



}
