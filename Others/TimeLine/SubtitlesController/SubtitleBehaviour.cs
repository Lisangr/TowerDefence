using TMPro;
using UnityEngine;
using UnityEngine.Playables;
//оригинал вот тут https://www.youtube.com/watch?v=12bfRIvqLW4
public class SubtitleBehaviour : PlayableBehaviour
{
    public string subtitleText;
    
    /*
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = subtitleText;
        text.color = new Color(1, 1, 1, info.weight);
    }*/
}
