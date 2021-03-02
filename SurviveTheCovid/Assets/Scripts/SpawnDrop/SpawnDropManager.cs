using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDropManager : MonoBehaviour
{
    public AirDropSpawn airDropSpawn;

    private void Start()
    {
	    airDropSpawn = GetComponent<AirDropSpawn>();
    }
}
