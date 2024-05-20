using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class ExplosiveCube : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Spliter _spliter;

    private Renderer _renderer;
    private Stainer _stainer;

    public Rigidbody Rigidbody { get; private set; }

    private void Awake() =>
        Init();

    private void OnMouseDown() =>
        ExplosivelySplitUp();

    public void ChangeColor() =>
        _renderer.material.color = _stainer.GetRandomColor();

    private void ExplosivelySplitUp()
    {
        ExplosiveCube[] cubesForSplit = _spliter.GetCubesForSplit(this);
        List<ExplosiveCube> splitedCubes = GetSplitedCubes(cubesForSplit);

        _exploder.Explode(splitedCubes);
        gameObject.SetActive(false);
    }

    private List<ExplosiveCube> GetSplitedCubes(ExplosiveCube[] cubes)
    {
        List<ExplosiveCube> splitedCubes = new();

        foreach (ExplosiveCube cube in cubes)
        {
            ExplosiveCube newCube = Instantiate(cube);
            newCube.ChangeColor();
            splitedCubes.Add(newCube);
        }

        return splitedCubes;
    }

    private void Init()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();

        _stainer = new();
    }
}