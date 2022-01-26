using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo Game/Attack")]
public class Attack : ScriptableObject
{
    public string DisplayName;
    public Sprite DisplayIcon;
    public float Damage;
    public GameObject AttackFX;

    private void OnEnable()
    {
        Debug.Log($"{name} is checking the name of the new SO asset");
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        Debug.Log($"{name} is validating!");
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
    }
#endif
}