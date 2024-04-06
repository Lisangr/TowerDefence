using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(241f/255f, 249f/255f, 99f/255f)]
[TrackBindingType(typeof(Light))]
[TrackClipType(typeof(LightControlClip))]

public class LightControlTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<LightControlMixer>.Create(graph, inputCount);
    }
}
