using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "glass_panel_1_door" && grabController.itemsTouched)
        {
            animator.SetBool("character_nearby", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "glass_panel_1_door" && grabController.itemsTouched)
        {
            animator.SetBool("character_nearby", false);
        }
    }
}
