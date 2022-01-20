using System.Collections.Generic;
using UnityEngine;

public enum Faction { Friendly, Enemy }

[CreateAssetMenu(menuName = "Demo Game/Character")]
public class Character : ScriptableObject
{
    public string CharacterName;
    public float InitialHealth = 100f;
    public List<Attack> Abilities;
    public Faction CharacterFaction;
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