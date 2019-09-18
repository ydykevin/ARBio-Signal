using UnityEngine;
/// <summary>
/// Class: EEGData
/// Implements: N/A
/// Authors: Carlos Tirado   <Carlos.A.TiradoCortes@student.uts.edu.au> and you!
///     
/// Description: - This class is represents the data being sent/receved by EEG.
///              - It is ment to be just a shell, you can add/modify/remove any component as you
///              wish, you just need to let us know 'cause there is more people using this code ;D
///              - If you are brave enough, perhaps find a way to do a mapping between the index in
///              the data array, and the specific name of the electrode in the cap. :D
///             
/// 
///           __,.__
///          /  ||  \               
///   ::::::| .-'`-. |::::::
///   :::::/.'  ||  `,\:::::
///   ::::/ |`--'`--'| \::::
///   :::/   \`/++\'/   \::: 
/// </summary>
public class EEGData
{
    /// <summary>
    /// The data being sent/received by the headset.
    /// </summary>
    private float[] data;

    /// <summary>
    /// Access the data array, only can access it, can't modify it.
    /// </summary>
    public float[] DataArray
    {
        get { return data; }
    }

    /// <summary>
    /// The number of channels this headset has.
    /// Just access the number, can't modify it.
    /// </summary>
    public int ChannelCount
    {
        get { return data.Length; }
    }

    /// <summary>
    /// The time stamp of a specific data set.
    /// </summary>
    private double timeStamp;

    /// <summary>
    /// Access to the time stamp, can't modify it.
    /// </summary>
    public double TimeStamp
    {
        get { return timeStamp; }
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="data"> The data being sent</param>
    /// <param name="timestamp">The specific timestamp of that dataset</param>
    public EEGData (float [] data, double timestamp)
    {
        this.data = data;
        this.timeStamp = timestamp;
    }

    /// <summary>
    /// Get the value at a specific channel.
    /// Kudos if you are the brave guy who maps the index of the array, to a specific electrode.
    /// </summary>
    /// <param name="channelNumber">The index of the data you are looking for.</param>
    /// <returns></returns>
    public float GetDataAtChannel (int channelNumber)
    {
        int channelIndex = channelNumber - 1;

        if(channelIndex > ChannelCount)
        {
            Debug.LogError("Trying to access a channel that is not party of this device.");
            return -1;
        } else
        {
            return data[channelIndex];
        }
    }

}
