using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo Game/Turn State")]
public class TurnState : ScriptableObject
{
    public string DisplayName;

    [Tooltip("Valid next states for turn order")]
    public List<TurnState> ValidNextTurnStates = new List<TurnState>();

    private void OnEnable()
    {
        if (string.IsNullOrEmpty(DisplayName))
        {
            DisplayName = this.name;
        }
    }
    public TurnState GetNextTurnState()
    {
        return ValidNextTurnStates[0];
    }
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