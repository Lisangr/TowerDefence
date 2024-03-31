using TMPro;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine;
//оригинал вот тут https://www.youtube.com/watch?v=12bfRIvqLW4

[TrackBindingType(typeof(TextMeshProUGUI))]
[TrackClipType(typeof(SubtitleClip))]

public class SubtitleTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SubtitleTrackMixer>.Create(graph, inputCount);
    }
}
