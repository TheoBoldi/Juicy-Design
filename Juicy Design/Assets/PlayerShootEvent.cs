using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootEvent : MonoBehaviour
{
    public void LaunchPlayerShootEvent()
    {
        GetComponentInParent<PlayerController>().Shoot();
    }
}
