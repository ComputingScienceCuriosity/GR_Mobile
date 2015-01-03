using UnityEngine;
using System.Collections;

public class Limit : MonoBehaviour 
{
    private ThirdPersonController character;

    private bool isChoiceNonSelected;

    private GamePlay gameplay = null;

    void Start()
    {
        character = GameObject.FindObjectOfType<ThirdPersonController>() as ThirdPersonController;
    }

	void OnTriggerEnter(Collider other)
    {
        // On arrete le personnage est on affiche le menu de séléction : 
        // Envoie de message de pause vers le CharacterCtrlModel & pause du temps
        GlobalVariables.Instance.isPaused = true;
        gameplay = GameObject.FindObjectOfType<GamePlay>() as GamePlay;
        gameplay.characterCtrlController.PauseModel();

        // Désactivation de la coroutine de collection des commands
        gameplay.backwardInTimeController.DisableModelRoutine();
        // Affichage du menu de choix 
        gameplay.backwardInTimeController.ActivateViewContainer(true);

    }

    public void SetChoice(bool value)
    {
        isChoiceNonSelected = value;
    }

    void Update()
    {
        // Si le joueur à choisie non 
        if (isChoiceNonSelected)
        {
            gameplay.backwardInTimeController.ActivateViewContainer(false);
            isChoiceNonSelected = false;
            GlobalVariables.Instance.isPaused = false;
            GlobalVariables.Instance.LevelScore = GlobalVariables.Instance.Score;
            GlobalVariables.Instance.Lifes--;

            if (GlobalVariables.Instance.Lifes == 0)
                Application.LoadLevel("GameOver");
            else
                Application.LoadLevel(Application.loadedLevelName);  
        }
    }
}
