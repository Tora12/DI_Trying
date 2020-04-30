using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private GameObject drop = null;

    public int spawnDropDelay;

    public virtual void spawnDrop(Vector3 position, Quaternion rotation)
    {
        GameManager.Instance.spawnEntity(drop, position, rotation, spawnDropDelay);
    }
}