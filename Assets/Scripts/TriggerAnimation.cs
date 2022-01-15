using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] GameObject saitamaCoolAnimation;
    [SerializeField] AnimationClip clip;

    int firstTime = 1;

    public void TriggerSaitamaAnimation()
    {
        if (FindObjectsOfType<TriggerAnimation>().Length <= 1)
        {
            if (firstTime == 1)
            {
                GameObject saitamaAnimation = Instantiate(saitamaCoolAnimation, saitamaCoolAnimation.transform.position, Quaternion.identity);
                Time.timeScale = 0f;
                StartCoroutine(WaitForAnimationToEnd());
                Destroy(saitamaAnimation, clip.length);
                firstTime++;
            }
        }

    }
    IEnumerator WaitForAnimationToEnd()
    {
        yield return new WaitForSeconds(clip.length);
        Debug.Log("Bye");
    }



}
