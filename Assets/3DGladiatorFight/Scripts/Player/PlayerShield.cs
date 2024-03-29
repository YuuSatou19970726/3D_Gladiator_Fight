using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    private Health healthScript;

    void Awake()
    {
        healthScript = GetComponent<Health>();
    }

    public void ActivateShield(bool shieldActive)
    {
        healthScript.shieldActivated = shieldActive;
    }
}
