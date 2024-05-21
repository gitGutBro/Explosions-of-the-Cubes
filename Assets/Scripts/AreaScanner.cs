using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AreaScanner
{
    [SerializeField] private FloorArea _area;

    public Vector3 Radius => _area.transform.localScale;

    public List<ExplosiveCube> GetCubesForExplode(Vector3 cubePosition)
    {
        List<ExplosiveCube> cubesForExplode = new();

        foreach (Collider collider in GetColliders(cubePosition))
            if(collider.gameObject.TryGetComponent(out ExplosiveCube cube))
                cubesForExplode.Add(cube);

        return cubesForExplode;
    }

    public Collider[] GetColliders(Vector3 cubePosition) =>
        Physics.OverlapBox(cubePosition, Radius);
    
}