using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenCharacterAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();      
    }
    public void SetCharacterGone()
    {
        animator.SetBool("hasFinishedLoading", true);
    }
    public void PlayApearSFX()
    {
        FindObjectOfType<LoadingScreenHandler>().PlayCharacterAppearSFX();
    }
}
