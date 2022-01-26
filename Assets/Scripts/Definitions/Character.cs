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

    public FloatReference Health;

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
