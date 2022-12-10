using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStar : MonoBehaviour
{
    private DJMusic _dJMusic;


    private void Start()
    {
        _dJMusic = FindObjectOfType<DJMusic>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _dJMusic.PlayStarSound();
            Destroy(gameObject);
        }
    }
}
