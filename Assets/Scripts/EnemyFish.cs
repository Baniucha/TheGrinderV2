using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script responsible for enemy fish
public class EnemyFish : MonoBehaviour
{

    //variables
    private float movementDuration = 2.0f;
    private bool hasArrived = false;

    private void Update()
    {
        //depending on position
        //wait or move to different position from range randX and randY

        if (!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(14, 32);
            float randY = Random.Range(-14f, -13f);
            StartCoroutine(MoveToPoint(new Vector3(randX, randY, 0)));
        }
    }

    //COROUTINE RESPONSIBLE ON RANDOM POSITION MOVEMENT
    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(.1f);
        hasArrived = false;

    }

}
