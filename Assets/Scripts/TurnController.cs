using ScriptableObjectArchitecture;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Demo Game/Turn Controller")]
public class TurnController : ScriptableObject
{
    [SerializeField] private TurnState _startTurnState;
    [SerializeField] private TurnState _endTurnState;
    [SerializeField] private TurnState _playerTurnState;
    [SerializeField] private TurnState _enemyTurnState;
    public TurnStateEvent TurnStateChangedEvent = default;
    private List<TurnState> _turnOrder = new List<TurnState>();
    public List<TurnState> TurnOrder => _turnOrder;
    public TurnState CurrentTurnState => _turnOrder[_turnIdx] ? _turnOrder[_turnIdx] : _startTurnState;
    private int _turnIdx;
    public int TurnIdx => _turnIdx;
    [SerializeField] private int _turnsPerRound = 6;
    public int TurnsPerRound => _turnsPerRound;
    private int _roundCounter;
    public int RoundCounter => _roundCounter;
    // [SerializeField] private GameObjectVariable _playerRef;
    // [SerializeField] private GameObjectVariable _enemyRef;
    // public GameObjectVariable _targetRef;
    public void StartRound()
    {
        _turnIdx = 1;
        _roundCounter += 1;
        Debug.Log($"Starting round, first turn: {CurrentTurnState}");
        TurnStateChangedEvent.Raise(new TurnStateEventPayload() { CurrentTurn = CurrentTurnState });
    }
    public void EndTurn()
    {
        if (CurrentTurnState != _endTurnState)
        {
            _turnIdx++;
            
            if (CurrentTurnState == _endTurnState)
            {
                Debug.Log("End of round!");
                EndRound();
            } else 
            {
                TurnStateChangedEvent.Raise(new TurnStateEventPayload() { CurrentTurn = CurrentTurnState });
            }
        }
        else
        {
            Debug.Log($"at the end already {CurrentTurnState}");
        }
    }

    public void EndRound()
    {
        _turnIdx = 0;
        TurnStateChangedEvent.Raise(new TurnStateEventPayload() { CurrentTurn = CurrentTurnState });
    }

    public void InitializeTurns()
    {
        _turnOrder = new List<TurnState>();
        _turnIdx = 0;
        _roundCounter = 0;
        TurnState t = _startTurnState;
        _turnOrder.Add(t);

        for (int i = 0; i < _turnsPerRound; i++)
        {
            TurnState nextTurn = t.GetNextTurnState();
            _turnOrder.Add(nextTurn);
            t = nextTurn;
        }

        _turnOrder.Add(_endTurnState);
        // if (_turnOrderUpdateEvent) _turnOrderUpdateEvent.Raise();
        TurnStateChangedEvent.Raise(new TurnStateEventPayload() { CurrentTurn = CurrentTurnState });
    }
}
