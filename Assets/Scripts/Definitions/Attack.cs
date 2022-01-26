using ScriptableObjectArchitecture;
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
        // Debug.Log($"<color=green>{name} is enabled!</color>");
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        // Debug.Log($"<color=cyan>{name} is validating!</color>");
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
        if (Damage < 5)
        {
            Debug.Log($"<color=orange>{name} this attack looks too weak!</color>");
        }
    }
#endif    


#region v2

    // public FloatVariable MinimumRecommendedDamage;
    // private void OnValidate()
    // {
    //     Debug.Log($"<color=cyan>{name} is validating!</color>");
    //     if (string.IsNullOrEmpty(DisplayName))
    //     {
    //         DisplayName = this.name;
    //     }
        
    //     if (Damage < MinimumRecommendedDamage.Value)
    //     {
    //         Debug.Log($"<color=orange>{name} this attack looks too weak!</color>");
    //     }
    // }
    #endregion
}