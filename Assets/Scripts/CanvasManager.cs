using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    private int hp = 3;

    public CanvasHP canvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void PerderHP()
    {
        hp -= 1;
        canvas.DesactivarHP(hp);
    }
}
