using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabController : MonoBehaviour
{
    public static bool itemsTouched;
    private static bool rook;
    private static bool knight;
    private static bool bishop;
    private static bool pawn;
    private static bool projector;
    public GameObject particle;

    private void Update()
    {
        if (rook && knight)
            itemsTouched = true;
        if (rook && knight && pawn && bishop)
            projector = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "RookDark" && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log(other.gameObject.name);
            rook = true;
        }
        else if (other.gameObject.name == "KnightLight" && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log(other.gameObject.name);
            knight = true;
        }
        else if (other.gameObject.name == "BishopLight" && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log(other.gameObject.name);
            bishop = true;
        }
        else if (other.gameObject.name == "PawnDark" && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log(other.gameObject.name);
            pawn = true;
        }
        if (other.gameObject.name == "Projector" && projector && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            particle.SetActive(true);
    }
}
