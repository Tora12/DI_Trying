using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    public GameObject doll;

    public void SpawnDoll()
    {
        Instantiate(doll, transform);
    }
}
