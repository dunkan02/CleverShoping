using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadProductProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.SpawnedBadProduct += OnValueChanged;
    }

    private void OnDisable()
    {
        _spawner.SpawnedBadProduct -= OnValueChanged;
    }
}