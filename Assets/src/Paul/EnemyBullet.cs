using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 10;
    public int delay = 10;

    private void Awake()
    {
        GameManager.Instance.despawnEntity(gameObject, delay);
    }
}
