using System;
using UnityEngine;
using UnityEngine.Playables;
//полная версия тут https://www.youtube.com/watch?v=LSrcQJHDUT4&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=11&ab_channel=25games
//вторая часть тут https://www.youtube.com/watch?v=-bptgHPebDw&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=12&ab_channel=25games

[Serializable]
public class LightControlBehavior : PlayableBehaviour
{
    public Color color = Color.white;
    public float intensity = 1f;
    public float bounceIntensity = 1f;
    public float range = 10f;

    private Light light;

    private bool _firstFrameHappened;
    private Color _defaultColor;
    private float _defaultIntensity;
    private float _defaultRange;
    private float _defaultBounceIntensity;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        light = playerData as Light;
        if (light == null) 
        {
            return;
        }
        
        if (!_firstFrameHappened) 
        { 
            _defaultColor = light.color;
            _defaultBounceIntensity = light.bounceIntensity;
            _defaultRange = light.range;
            _defaultIntensity = light.intensity;

            _firstFrameHappened = true;
        }
        light.color = color;
        light.intensity = intensity;
        light.bounceIntensity = bounceIntensity;
        light.range = range;
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        _firstFrameHappened = false;

        if (light == null)
            return;

        light.color = _defaultColor;
        light.intensity = _defaultIntensity;
        light.bounceIntensity = _defaultBounceIntensity;
        light.range = _defaultRange;

        //base.OnBehaviourPause(playable, info);
    }
}
