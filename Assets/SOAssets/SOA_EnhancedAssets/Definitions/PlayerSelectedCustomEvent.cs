using ScriptableObjectArchitecture;
using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Demo Game/Events/Custom Character Selected Event")]
public class PlayerSelectedCustomEvent : GameEventBase<PlayerSelectedPayload>{}

[Serializable]
public struct PlayerSelectedPayload
{
    public Character SelectedCharacter;
}