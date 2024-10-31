using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;


    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    internal void UpdateHeartUI(int currentHealth)
    {
        throw new NotImplementedException();
    }
}
