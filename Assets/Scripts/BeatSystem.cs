using System;
using System.Runtime.InteropServices;
using UnityEngine;

class BeatSystem : MonoBehaviour
{
    // I'm not sure if we need this. We may be able to eliminate this, and directly assign the instance variables held within BeatSystem. 
    [StructLayout(LayoutKind.Sequential)]
    class TimelineInfo
    {
        public int currentMusicBeat = 0;
        public FMOD.StringWrapper lastMarker = new FMOD.StringWrapper();
        public int timelinePosition = 0;
        public float time { get { return timelinePosition / 1000f; } }
    }

    TimelineInfo timelineInfo;
    GCHandle timelineHandle;

    FMOD.Studio.EVENT_CALLBACK beatCallback;

    // beat keeps track of what beat the song is on. 
    public static int beat;

    // marker is a string that returns most recent marker passed. 
    public static string marker;

    // A float that returns the song's position in seconds. 
    public static int timelinePosition;

    public static FMOD.Studio.EventInstance _instance;

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

                        // TODO Event firing for GameManager
                        // For example, we can push out an event that fires off every beat. When a listener hears that the event is fired, it can play a premade animation.
                    }
                    break;
                case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER:
                    {
                        var parameter = (FMOD.Studio.TIMELINE_MARKER_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_MARKER_PROPERTIES));
                        timelineInfo.lastMarker = parameter.name;
                        marker = timelineInfo.lastMarker;

                        // TODO Event firing for GameManager
                        // For example, we can push out an event that fires with every marker. Each marker will have an ID that will also be passed, and all other classes will listen for specific IDs. 
                    }
                    break;            
            }

        }
        return FMOD.RESULT.OK;
    }
}