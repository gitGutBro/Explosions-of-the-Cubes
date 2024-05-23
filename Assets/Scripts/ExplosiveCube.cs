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

    private void ChangeColor() =>
        _renderer.material.color = Random.ColorHSV();

    private void ExplosivelySplitUp()
    {
        ExplosiveCube[] cubesForSplit = _spliter.GetCubesForSplit(this);

        SplitUp(cubesForSplit);
        Exploding();

        gameObject.SetActive(false);
    }

    private void SplitUp(ExplosiveCube[] cubes)
    {
        foreach (ExplosiveCube cube in cubes)
        {
            ExplosiveCube newCube = Instantiate(cube);
            newCube.ChangeColor();
        }
    }

    private void Exploding() =>
        _exploder.Explode
        (transform.position, 
        Math.GetInverseProportionalityValue(Exploder.MaxCubeSize, Exploder.MinForceMultiplier, transform.localScale.x));

    private void Init()
    {
        _renderer = GetComponent<Renderer>();
        Rigidbody = GetComponent<Rigidbody>();

        _stainer = new();
    }
}