using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] AudioSource _audioLose;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Target" || collision.tag == "Player" )
        {
            _audioLose.Play();
            Destroy(GameObject.FindWithTag("Player"));

            UI.instance.OpenEndScreen();//end game

        }
    }
}
