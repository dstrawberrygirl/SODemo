using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Character CharacterTemplate;
    public Faction CharacterFaction;
    private float _currentHealth;
    public float CurrentHealth => _currentHealth;
    public float CurrentHealthNormalized => _currentHealth / 100;

    private void Start()
    {
        _currentHealth = CharacterTemplate.InitialHealth;
    }

    public void HandleDamageTaken(float incomingDamage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - incomingDamage, 0, 100f);
    }
}
