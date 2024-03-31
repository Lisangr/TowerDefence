using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
//полная версия тут https://www.youtube.com/watch?v=LSrcQJHDUT4&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=11&ab_channel=25games
//вторая часть тут https://www.youtube.com/watch?v=-bptgHPebDw&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=12&ab_channel=25games

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
