using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Soldier _trackableSoldier;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _trackableSoldier.Health;
        _slider.value=_trackableSoldier.Health;
    }
    
    private void OnEnable()
    {
        _trackableSoldier.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _trackableSoldier.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _slider.value = health;
    }
}
