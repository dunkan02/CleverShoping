using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodProductProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.SpawnedGoodProduct += OnValueChanged;
    }

    private void OnDisable()
    {
        _spawner.SpawnedGoodProduct -= OnValueChanged;
    }
}