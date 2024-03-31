using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

//если есть необходимость запустить несколько разных таймлайнов с помощью кнопки на пьедестале,
//то вешаем коллайдер с isТrigered и вешаем на него скрипт. Предвариетельно вешаем на кнопку
//скрипт с назначением клавиш, красная кнопка для кнопки 1 белая для кнопки 2
//обрабатываем событие которое выбрано
//
// https://www.youtube.com/watch?v=cmExSYI2yd0&list=PLmXKnJbgQ2cqGG4WwuE43L-kwmb3C0-1x&index=9&ab_channel=Unity
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
