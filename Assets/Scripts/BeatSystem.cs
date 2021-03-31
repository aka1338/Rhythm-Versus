using System;
using System.Runtime.InteropServices;
using UnityEngine;

class BeatSystem : MonoBehaviour
{
    // I'm not sure if we need this. We may be able to eliminate this, and directly assign the instance variables held within BeatSyste
    [StructLayout(LayoutKind.Sequential)]
    class TimelineInfo
    {
        public int currentMusicBeat = 0;
        public FMOD.StringWrapper lastMarker = new FMOD.StringWrapper();

        // TODO fix structure departure 
        //public int timelinePosition = 0;

        public float time { get { return timelinePosition / 1000f; } }
        public static float bpm;
    }

    TimelineInfo timelineInfo;
    GCHandle timelineHandle;

    public delegate void BeatAction();
    public static event BeatAction onBeat;

    public static event BeatAction onOffBeat;

    public delegate void MarkerAction();
    public static event MarkerAction onMarker;


    FMOD.Studio.EVENT_CALLBACK beatCallback;

    /// <summary>
    ///  Returns the current beat in the song.  
    /// </summary>  
    public static int beat;

    /// <summary>
    ///  Returns a string of the most recent marker passed. 
    /// </summary>     
    public static string marker;


    /// <summary>
    ///  Returns the current playhead time in miliseconds. 
    /// </summary> 
    public static int timelinePosition;

    /// <summary>
    /// A float that returns the song's bpm.  
    /// </summary> 
    public static float bpm;

    /// <summary>
    ///  Returns the amount of seconds between each beat. 
    /// </summary>     
    public static float secPerBeat;

    /// <summary>
    ///  Returns the current song time in beats. 
    /// </summary> 
    public static float songPosInBeats;

    /// <summary>
    ///  Returns the current marker time in miliseconds. 
    /// </summary>    
    public static float markerTimeLinePosition;

    public static FMOD.Studio.EventInstance _instance;

    /// <summary>
    ///  Returns the current playhead time in seconds. 
    /// </summary>
    public static float time { get { return timelinePosition / 1000f; } }

    public void AssignBeatEvent(FMOD.Studio.EventInstance instance)
    {
        _instance = instance;
        timelineInfo = new TimelineInfo();
        timelineHandle = GCHandle.Alloc(timelineInfo, GCHandleType.Pinned);
        beatCallback = new FMOD.Studio.EVENT_CALLBACK(BeatEventCallback);
        instance.setUserData(GCHandle.ToIntPtr(timelineHandle));
        instance.setCallback(beatCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT | FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
    }

    public void StopAndClear(FMOD.Studio.EventInstance instance)
    {
        instance.setUserData(IntPtr.Zero);
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        instance.release();
        timelineHandle.Free();
    }

    private void Update()
    {

        _instance.getTimelinePosition(out timelinePosition);
        //timelinePosition = timelineInfo.timelinePosition;
        songPosInBeats = time / secPerBeat;
    }


    [AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
    static FMOD.RESULT BeatEventCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr)
    {
        FMOD.Studio.EventInstance instance = new FMOD.Studio.EventInstance(instancePtr);
        // Retrieve the user data
        IntPtr timelineInfoPtr;
        FMOD.RESULT result = instance.getUserData(out timelineInfoPtr);
        if (result != FMOD.RESULT.OK)
        {
            Debug.LogError("Timeline Callback error: " + result);
        }

        else if (timelineInfoPtr != IntPtr.Zero)
        {
            // Get the object to store beat and marker details
            GCHandle timelineHandle = GCHandle.FromIntPtr(timelineInfoPtr);
            TimelineInfo timelineInfo = (TimelineInfo)timelineHandle.Target;

            switch (type)
            {
                case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT:
                    {
                        var parameter = (FMOD.Studio.TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_BEAT_PROPERTIES));
                        timelineInfo.currentMusicBeat = parameter.beat;
                        beat = timelineInfo.currentMusicBeat;
                        bpm = parameter.tempo;
                        secPerBeat = 60f / bpm;


                        // TODO Event firing for GameManager
                        // For example, we can push out an event that fires off every beat. When a listener hears that the event is fired, it can play a premade animation.
                        if (onBeat != null)
                        {
                            onBeat();
                        }

                        if (beat % 2 != 0)
                        {
                            if (onOffBeat != null)
                            {
                                onOffBeat();
                            }
                        }
                    }
                    break;
                case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER:
                    {
                        var parameter = (FMOD.Studio.TIMELINE_MARKER_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_MARKER_PROPERTIES));
                        timelineInfo.lastMarker = parameter.name;
                        marker = timelineInfo.lastMarker;


                        markerTimeLinePosition = timelinePosition;
                        // TODO Event firing for GameManager
                        // For example, we can push out an event that fires with every marker. Each marker will have an ID that will also be passed, and all other classes will listen for specific IDs. 
                        if (onMarker != null)
                        {
                            onMarker();
                        }
                    }
                    break;

            }

        }
        return FMOD.RESULT.OK;
    }
}