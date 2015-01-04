using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Class permettant d'attacher les scripts des différents composantes MVC selon l'état   
/// </summary>
public class MVCInitialiser :  MonoBehaviour
{

    // instance du stateContext
    private StateContext stateContext;

    // objet pour l'utilisation/stoquage des états
    private GameObject stateObject;

    // permet d'éffecture l'init une seule fois dans le Update
    private bool         currentIsInitialized = false;

    // nom du niveau courant
    private string       currentLoadedLevel="";

    // dernier niveau chargé pour changer la valeur de <currentIsInitialized>
    private string       lastLoadedLevel  =""; 

    /// <summary>
    /// Initialise les GameObjects liées au compostant MVC
    /// </summary>
    public virtual void IntializeGO()
    {
        stateContext = GetComponent<StateContext>() as StateContext;
        stateObject  = new GameObject("CurrentState");
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(stateObject);
    }

    /// <summary>
    /// Permet d'attacher les scripts au différents GameObjects
    /// </summary>
    public virtual void AttachIntializedGO()
    {
        if (   !Application.loadedLevelName.Equals("Loading")
            && !Application.loadedLevelName.Equals("GameOver")
            && !Application.loadedLevelName.Equals("End"))
        { 
            switch (currentLoadedLevel)
            {
                case "MainMenu":
                  
                   stateObject.AddComponent<MainMenu>();
                   stateContext.LoadStateContext(stateObject.GetComponent<MainMenu>());

                   currentIsInitialized = true;
                   lastLoadedLevel = currentLoadedLevel;
                    break;

                default: // Level[1:5]

                   stateContext.Request();

                    // Permet d'éviter d'avoir plusieurs instances répétés à la fois
                   if (stateObject.GetComponent<MainMenu>() != null)
                        Destroy(stateObject.GetComponent<MainMenu>());

                   if (stateObject.GetComponent<GamePlay>() != null)
                        Destroy(stateObject.GetComponent<GamePlay>());

                   stateObject.AddComponent<GamePlay>();
                   stateContext.LoadStateContext(stateObject.GetComponent<GamePlay>());

                   currentIsInitialized = true;
                   lastLoadedLevel = currentLoadedLevel;
                    break;
            }  
        }
        else
        {
            // Si l'instance existe dans les autres scenes on la détruit 
            if (stateObject.GetComponent<GamePlay>() != null)
                Destroy(stateObject.GetComponent<GamePlay>());
        }
    }

    /// <summary>
    /// Init et Attachement
    /// </summary>
    public void Awake()
    {
        this.IntializeGO();
        this.AttachIntializedGO();
    }

    /// <summary>
    /// Pour chaque niveau on boucle est on vérifie si l'attachement à été bien fait
    /// </summary>
    public void Update()
    {
        if (!currentLoadedLevel.Equals(Application.loadedLevelName))
        {
            currentLoadedLevel = Application.loadedLevelName;
        }

        // Si le niveau à été chargé/rechargé on init la valeur de lastLoadedLevel afin d'éffectuer un attachement
        if (Application.isLoadingLevel)
        {
            StartCoroutine(waitForReload());
        }

        // Si le niveau courant à changé 
        if (!currentLoadedLevel.Equals(lastLoadedLevel))
        {
            currentIsInitialized = false;
            lastLoadedLevel = currentLoadedLevel;
        }

        // Attachement de la composante compatible au niveau courant
        if (!currentIsInitialized)
        {
            AttachIntializedGO();
        }
    }

    /// <summary>
    /// Attend le rechargement du niveau courant et rénitialise la valeur de lastLoadedLevel
    /// </summary>
    /// <returns></returns>
    private IEnumerator waitForReload()
    {
        yield return new WaitForEndOfFrame();
        lastLoadedLevel = "";
    }
}
