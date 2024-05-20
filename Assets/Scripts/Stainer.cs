using UnityEngine;

public class Stainer
{
    private readonly Color[] _colors;

    public Stainer() =>
        _colors = InitColors();

    public Color GetRandomColor() =>
        _colors[Random.Range(0, _colors.Length - 1)];

    private Color[] InitColors() =>
        new Color[]
        { Color.black, Color.red, Color.cyan,
          Color.grey, Color.yellow, Color.magenta,
          Color.blue, Color.green, Color.gray };
}