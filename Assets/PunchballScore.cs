using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PunchballScore : MonoBehaviour
{
    public TextMeshPro scoreText;
    private string scoreString;

    private bool isPunchballBusy;
    
    void OnCollisionEnter(Collision col)
    {
        if (!isPunchballBusy)
        {
            //Check the greater between the velocities of the three axes
            scoreString = Mathf.FloorToInt(
                    Mathf.Max(
                        Mathf.Abs(col.relativeVelocity.x * 100),
                        Mathf.Abs(col.relativeVelocity.y * 100),
                        Mathf.Abs(col.relativeVelocity.z * 100)))
                .ToString();
            isPunchballBusy = true;
            StartCoroutine(ShowScore());
        }
    }
    

    IEnumerator ShowScore()
    {
        scoreText.text = "Score: " + scoreString;
        yield return new WaitForSeconds(3);
        scoreText.text = "Score: 0";
        isPunchballBusy = false;
    }
}