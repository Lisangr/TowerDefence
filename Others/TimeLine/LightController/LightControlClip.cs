using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class LightControlClip : PlayableAsset, ITimelineClipAsset
{
    public ClipCaps clipCaps
    { get { return ClipCaps.Blending; } }

    [SerializeField] private LightControlBehavior _template = new LightControlBehavior();
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        return ScriptPlayable<LightControlBehavior>.Create(graph, _template);
    }
}
