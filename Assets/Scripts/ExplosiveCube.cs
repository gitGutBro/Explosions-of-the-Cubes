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

        Exploding();

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

    private void Exploding()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, _exploder.Scanner.Radius);

        _exploder.Explode(_exploder.Scanner.GetCubesForExplode(colliders), transform.position, GetInverseProportionalityValue());
    }

    private float GetInverseProportionalityValue() =>
        Exploder.MaxCubeSize * (Exploder.MinForceMultiplier / (transform.localScale.x + transform.localScale.y / 2));

    private void Init()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();

        _stainer = new();
    }
}