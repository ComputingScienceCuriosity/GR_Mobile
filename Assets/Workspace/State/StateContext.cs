using UnityEngine;
using System.Collections;

public class StateContext : MonoBehaviour
{
    private State _state = null;
    
    /// <summary>
    /// GET/SET State
    /// </summary>
    public State State
    {
        get { return _state; }
        set { _state = value; }
    }

    /// <summary>
    /// Constructeur
    /// </summary>
    /// <param name="state"></param>
    public void LoadStateContext(State state)
    {
        _state = state;
        _state.OnEnter();
    }

    /// <summary>
    /// Change le state courant
    /// </summary>
    public void Request()
    {
        _state.OnExit();
        _state.Handle(this);
    }

    /// <summary>
    /// Mis à jour en boucle du state
    /// </summary>
    public void Update()
    {
        // TODO : A REVOIR quand le niveau est rechargé State deviens = NULL

        if (_state != null)
        {
            _state.OnUpdate();
        }
    }
}
