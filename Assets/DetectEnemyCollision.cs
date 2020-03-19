using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectEnemyCollision : MonoBehaviour
{
    public GameObject detector;
    private void Start()
    {
        detector.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            detector.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detector.SetActive(false);

        }
    }
}
