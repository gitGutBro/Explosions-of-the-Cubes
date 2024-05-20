using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Exploder
{
    [Header("Explode Properties")]
    [SerializeField][Range(1f, 300f)] private float _radius;
    [SerializeField][Range(1f, 300f)] private float _force;
    
    public void Explode(List<ExplosiveCube> cubes)
    {
        foreach (ExplosiveCube cube in cubes)
            cube.Rigidbody.AddExplosionForce(_force, cube.transform.position, _radius);
    }
}