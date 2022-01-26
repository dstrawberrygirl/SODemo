using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;

public enum Faction { Friendly, Enemy }

[CreateAssetMenu(menuName = "Demo Game/Character")]
public class Character : ScriptableObject
{
    public string CharacterName;
    public List<Attack> Abilities;
    public GameObject Prefab;

    public FloatVariable Health;
    [SerializeField] private FloatVariable _startingHealth = default(FloatVariable);

    public void InitializeHealth()
    {
        Health.Value = _startingHealth.Value;
    }
    public void InitializeHealth(float newBaseHealth)
    {
        Health.Value = newBaseHealth;
    }
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(CharacterName))
        {
            CharacterName = this.name;
        }
    }
#endif

}
