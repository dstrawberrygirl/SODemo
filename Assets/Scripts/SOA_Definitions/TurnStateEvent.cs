using System;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(menuName = "Demo Game/Events/Turn State Event")]
public class TurnStateEvent : GameEventBase<TurnStateEventPayload>
{
}

[Serializable]
public struct TurnStateEventPayload
{
    public TurnState CurrentTurn;
}