using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUiManager : MonoBehaviour
{
    public HealthBase HealthSource;
    public UnityEngine.UI.Text HealthDestination;

    public void Start()
    {
        HealthSource.OnHealthChanged += HealthUpdated;
    }

    public void HealthUpdated(float currentHealth)
    {
        HealthDestination.text = currentHealth.ToString();
    }
}
