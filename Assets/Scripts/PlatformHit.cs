using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHit : MonoBehaviour, IInteractive
{
    [SerializeField] private GameObject manager;

    public void GetHitByBullets()
    {
        string ColorTag = gameObject.GetComponent<MoveInteractiveScript>().ColorGroup;
        manager.GetComponent<PlatformManager>().MovePlatforms(ColorTag);
    }
}
