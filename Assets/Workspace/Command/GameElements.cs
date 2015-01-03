using UnityEngine;
using System.Collections;

/// <summary>
/// Receiver: class contenant les éléments du jeu, le retour en arriere sera appliqué sur ses objets 
/// </summary>
public class GameElements  
{

    public void OperateAction(GameCommand.GameCommandElements gameCmdElements)
    {
        GlobalVariables.Instance.LevelScore =  gameCmdElements.Score;
        GlobalVariables.Instance.currentTime = gameCmdElements.Time;
        GameObject.FindObjectOfType<CharacterController>().transform.position = gameCmdElements.Characterpos;
        GameObject.FindObjectOfType<CharacterController>().transform.rotation = gameCmdElements.CharacterRot;
    }


}
