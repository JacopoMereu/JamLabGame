using System;
using System.Collections;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ToyGun : MonoBehaviour
{
    private AudioSource audioSource;
    private Interactable interactable;
    public GameObject muzzleFlash;

    public SteamVR_Action_Boolean shootAction;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        shootAction.AddOnStateDownListener(shootBullet, SteamVR_Input_Sources.Any);
        interactable = GetComponent<Interactable>();
    }

    private void shootBullet(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
    {
        if (interactable.attachedToHand && interactable.attachedToHand.handType == fromaction.activeDevice)
        {
            audioSource.Play();
            StartCoroutine(FlashGun());
            // shoot a raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // if the raycast hits something, check if it's a target
                if (hit.transform.CompareTag("Balloon"))
                {
                    // if it is, destroy it
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    private IEnumerator FlashGun()
    {
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        muzzleFlash.SetActive(false);
    }
}