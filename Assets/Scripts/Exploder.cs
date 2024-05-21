using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Exploder
{
    public const float MinForceMultiplier = 1f;
    public const float MaxCubeSize = 10f;

    [Header("Explode Properties")]
    [SerializeField][Range(1f, 300f)] private float _radius;
    [SerializeField][Range(1f, 80f)] private float _force;

    [field: SerializeField] public AreaScanner Scanner { get; private set; }

    public void Explode(Vector3 explodePoint, float forceMultiplier)
    {
        List<ExplosiveCube> cubeForExplode = Scanner.GetCubesForExplode(explodePoint);

        foreach (ExplosiveCube cube in cubeForExplode)
            cube.Rigidbody.AddExplosionForce(_force * forceMultiplier, explodePoint, _radius);
    }
}