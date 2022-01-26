using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo Game/Attack")]
public class Attack : ScriptableObject
{
    public string DisplayName;
    public Sprite DisplayIcon;
    public float Damage;
    public GameObject AttackFX;
    public FloatVariable MinimumRecommendedDamage;
    
    private void OnEnable()
    {
        // Debug.Log($"<color=green>{name} is enabled!</color>");
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
    }

    private void OnValidate()
    {
        // Debug.Log($"<color=cyan>{name} is validating!</color>");
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
        
        if (Damage < MinimumRecommendedDamage.Value)
        {
            Debug.Log($"<color=orange>{name} this attack looks too weak!</color>");
        }
    }
}