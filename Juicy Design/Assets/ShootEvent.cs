using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEvent : MonoBehaviour
{
    public void LaunchShootEvent()
    {
        GetComponentInParent<EnemyController>().Shoot();
    }
}
