using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    GameObject platform;

    public void Build(GameObject p)
    {
        platform = p;
        platform.GetComponent<BoxCollider>().enabled = false;
    }

    public void DestroyTurret()
    {
        platform.GetComponent<BoxCollider>().enabled = true;
        Destroy(this.gameObject);
    }
}
