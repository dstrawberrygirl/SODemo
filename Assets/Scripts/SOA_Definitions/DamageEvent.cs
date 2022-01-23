using ScriptableObjectArchitecture;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo Game/Events/Damage Event")]
public class DamageEvent : GameEventBase<DamageEventPayload>{}

[Serializable]
public struct DamageEventPayload
{
    public Character AttackingCharacter;
    public Character TargetCharacter;
    public Attack AttackUsed;
}