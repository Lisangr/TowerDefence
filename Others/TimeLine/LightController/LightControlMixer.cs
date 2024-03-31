using UnityEngine;
using UnityEngine.Playables;
//полная версия тут https://www.youtube.com/watch?v=LSrcQJHDUT4&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=11&ab_channel=25games
//вторая часть тут https://www.youtube.com/watch?v=-bptgHPebDw&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=12&ab_channel=25games

public class LightControlMixer : PlayableBehaviour
{
    private Light light;

    private bool firstFrameHappened;
    private Color defaultColor;
    private float defaultIntensity;
    private float defaultRange;
    private float defaultBounceIntensity;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        light = playerData as Light;

        if (light == null)
            return;

        if (!firstFrameHappened)
        {
            defaultColor = light.color;
            defaultBounceIntensity = light.bounceIntensity;
            defaultRange = light.range;
            defaultIntensity = light.intensity;

            firstFrameHappened = true;
        }

        int inputCount = playable.GetInputCount();

        Color blendedColor = Color.clear;
        float blendedIntensity = 0f;
        float blendedBounceIntensity = 0f;
        float blendedRange = 0f;    
        float totalWeight = 0f;

        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<LightControlBehavior> inputPlayable = 
                (ScriptPlayable<LightControlBehavior>)playable.GetInput(i);
            LightControlBehavior behaviour = inputPlayable.GetBehaviour();

            blendedColor += behaviour.color * inputWeight;
            blendedIntensity += behaviour.intensity * inputWeight;
            blendedBounceIntensity += behaviour.bounceIntensity * inputWeight;
            blendedRange += behaviour.range * inputWeight;

            totalWeight += inputWeight;
        }

        float remainingWeight = 1 - totalWeight;

        light.color = blendedColor;
        light.intensity = blendedIntensity;
        light.range = blendedRange;
        light.bounceIntensity = blendedBounceIntensity;
    }
    public override void OnPlayableDestroy(Playable playable)//или все таки
//public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        firstFrameHappened = false;

        if (light == null)
            return;

        light.color = defaultColor;
        light.intensity = defaultIntensity;
        light.bounceIntensity = defaultBounceIntensity;
        light.range = defaultRange;

        //base.OnBehaviourPause(playable, info);
    }
}
