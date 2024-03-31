using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
//полная версия тут https://www.youtube.com/watch?v=LSrcQJHDUT4&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=11&ab_channel=25games
//вторая часть тут https://www.youtube.com/watch?v=-bptgHPebDw&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=12&ab_channel=25games

[Serializable]
public class LightControlClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps
    { get { return ClipCaps.Blending; } }//Blending для пересечения клипов, None для простых

    [SerializeField] private LightControlBehavior _template = new LightControlBehavior();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<LightControlBehavior>.Create(graph, _template);
    }
}
