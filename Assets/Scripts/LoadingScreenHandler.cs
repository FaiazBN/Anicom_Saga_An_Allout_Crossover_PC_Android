using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenHandler : MonoBehaviour
{
    [SerializeField] GameObject loadingScreenTransition;

    [SerializeField] AudioClip characterAppear;
    [SerializeField] [Range(0,1f)] float characterAppearVolume = 1f;

    [SerializeField] AudioClip sharinganSFX;
    [SerializeField] [Range(0, 1f)] float sharinganVolume = 1f;






    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();            
    }

    void Update()
    {
    
    }
    public void SetLoadingScreenTransitionOn()
    {
        loadingScreenTransition.SetActive(true);

    }
    public void PlayCharacterAppearSFX()
    {
        audioSource.PlayOneShot(characterAppear, characterAppearVolume);
    }
    public void PlaySharinganSFX()
    {
        audioSource.PlayOneShot(sharinganSFX,sharinganVolume);
    }
}
