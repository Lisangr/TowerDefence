using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class TimeLineSelectedScript : MonoBehaviour
{
    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timeLines;

    private void Play()
    {
        foreach (PlayableDirector playableDirectors in playableDirectors) 
        {
            playableDirectors.Play();
        }
    }

    void PlayFromTimeLine(int index) 
    {
        TimelineAsset selectedAsset;

        if (timeLines.Count <= index)
        {
            selectedAsset = timeLines[timeLines.Count - 1];
        } else
        {
            selectedAsset = timeLines[index];
        }

        playableDirectors[0].Play(selectedAsset);
    }
}
