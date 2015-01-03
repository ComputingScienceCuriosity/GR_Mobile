using UnityEngine;
using System.Collections;
using System;

public class GameCommand : Command
{
    public class GameCommandElements
    {
        // Score du jeu
        public int Score
        {
            get;
            set;
        }

        // Temps du niveau
        public float Time
        {
            get;
            set;
        }

        // Position du personnage
        public Vector3 Characterpos
        {
            get;
            set;
        }

        // Rotation du personnage
        public Quaternion CharacterRot
        {
            get;
            set;
        }

        // Transform du perso
        public Transform CharTransform
        {
            get;
            set;
        }
    }

    public GameCommandElements _gameCmdElements;

    private GameElements       _gameElements;

    /// <summary>
    /// Constructeur concret de la class Commande Concrete 
    /// </summary>
    /// <param name="gameElems"></param>
    /// <param name="time"></param>
    public GameCommand(GameElements gameElems, GameCommandElements gameCmdElements)
    {
        _gameElements       = gameElems;
        _gameCmdElements    = gameCmdElements; 
    }

    /// <summary>
    /// Execution de l'operation du receiver
    /// </summary>
    public override void Execute()
    {
        _gameElements.OperateAction(_gameCmdElements);
    }

    /// <summary>
    /// Annulation de l'execution reviens à t - 1 
    /// </summary>
    public override void UnExecute()
    {
        _gameElements.OperateAction(_gameCmdElements);
    }
}
