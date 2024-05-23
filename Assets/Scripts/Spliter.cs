using System;
using UnityEngine;

[Serializable]
public struct Spliter
{
    private const int MinSplitCount = 2;
    private const int MaxSplitCount = 6;

    [SerializeField][Range(1.5f, 3f)] private float _scaleDivider;

    private readonly int SplitCount => UnityEngine.Random.Range(MinSplitCount, MaxSplitCount + 1);

    public readonly ExplosiveCube[] GetCubesForSplit(ExplosiveCube template)
    {
        DivideScale(template);

        ExplosiveCube[] cubesForSplit = new ExplosiveCube[SplitCount];

        for (int i = 0; i < cubesForSplit.Length; i++)
            cubesForSplit[i] = template;

        return cubesForSplit;
    }

    private readonly void DivideScale(ExplosiveCube cube) =>
        cube.transform.localScale /= _scaleDivider;
}