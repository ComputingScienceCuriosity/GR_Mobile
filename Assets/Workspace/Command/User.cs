using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Command Invoker : classe permettant d'invoquer une commande 
/// </summary>
public class User 
{ 
    public  GameElements  gameElements  = new GameElements();

    /// <summary>
    /// List contenant l'ensemble des commands
    /// </summary>
    private List<Command> commands      = new List<Command>();
    
    /// <summary>
    /// Indice cotenant le nombre de command stockés dans liste 
    /// </summary>
    private int _currentIndex = 0;

    // Propriété Set/Get
    public int CurrentIndex { get { return _currentIndex; } set { _currentIndex = value; } }

    /// <summary>
    /// Indice de déplacement dans le temps par rapport à Undo avant le prochaine prochain apply 
    /// </summary>
    private int _currentUndoIndex = 0;

    /// <summary>
    /// Dernier indice ou l'utilisateur à fait un apply après avoir éffectué un ensemble d'opérations Undo
    /// </summary>
    private int _lastUndoIndex = 0;

    private bool _isUndoFired = false;
    /// <summary>
    /// Permet d'ajouter un nouveau command est de l'executer
    /// </summary>
    /// <param name="time"></param>
    public void Apply(GameCommand.GameCommandElements gameCmdElements)
    {
        Command cmd = new GameCommand(gameElements, gameCmdElements);
        cmd.Execute();

        // Ajoute les commands a la liste Undo
        commands.Add(cmd);
        _currentIndex ++;

        // (Limitation du command) On garde le dernier index du undo là ou la deniere action s'est arrété avant de commencer un nouveau command 
        // dans le bute d'éviter que l'utilisateur puisse revenir a t0 à chaque fois dans n'importe quel moment 
        if(_isUndoFired)
            _lastUndoIndex    = _currentUndoIndex;
        _isUndoFired = false;
        _currentUndoIndex     = _currentIndex;
   }

    /// <summary>
    /// Déplacement dans l'axe positive du temps
    /// <param name="cmdLevels"> Nombre de Redo à effectuer </param>
    public void Redo(int cmdLevels)
    {
        for (int _p = 0; _p < cmdLevels; _p++)
        {
            if (_currentUndoIndex < commands.Count - 1)
            {
                Command cmd = commands[++_currentUndoIndex];
                cmd.Execute();
            }
        }
    }

    /// <summary>
    /// Déplacement dans l'axe négative du temps : retour en arrière
    /// </summary>
    /// <param name="cmdLevels"> Nombre de Undo à effectuer </param>
    public void Undo(int cmdLevels)
    {

        for (int _p = 0; _p < cmdLevels; _p++)
        {
            if (_currentUndoIndex > _lastUndoIndex)
            {
                Command cmd = commands[--_currentUndoIndex] as Command;
                cmd.UnExecute();
                _isUndoFired = true;
            }else
                _isUndoFired = false;
        }
    }

    /// <summary>
    /// Permet de vérifier si les opérations Undo sont possibles 
    /// </summary>
    /// <returns></returns>
    public bool isUndoPossible()
    {
        return (_currentUndoIndex > 0);
    }

    /// <summary>
    /// Permet de vérifier si les opérations Redo sont possibles 
    /// </summary>
    /// <returns></returns>
    public bool isRedoPossible()
    {
        return (_currentUndoIndex < commands.Count - 1);
    }
}
