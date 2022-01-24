using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo Game/Attack")]
[Serializable]
public class Attack : ScriptableObject
{
    public string DisplayName;
    public Sprite DisplayIcon;
    public float DamageToEnemy;
    public float DamageToSelf;


    public GameObject AttackFX;
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
    }
#endif
}