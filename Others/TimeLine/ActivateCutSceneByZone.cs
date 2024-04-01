using UnityEngine;
using UnityEngine.Playables;
//предварительно создаем коллайдер, ставим ему триггер и также нужно накинуть RigidBody в 
//статусе isKinematic 

public class ActivateCutSceneByZone : MonoBehaviour
{/*
    [SerializeField] private PlayableDirector playableDirector;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playableDirector.Play();
            GetComponent<Collider>().enabled = false;//указываем какой коллайдер надо получить у игрока
        }
    }*/
}
