using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DrumStickScript : XRGrabInteractable
{
    public AudioClip drumSound;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);

        if (interactor.selectTarget != null && interactor.selectTarget.name == "HighTom")
        {
            if (drumSound != null)
            {
                AudioSource audioSource = interactor.selectTarget.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.clip = drumSound;
                    audioSource.Play();
                }
            }
        }
    }   
}


"""
if (collision.relativeVelocity.magniture > 1.0f)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && drumSound != null)
            {
                audioSource.clip = drumSound;
                audioSource.Play();
            }
        }
    }

"""