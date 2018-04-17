using UnityEngine;

public class UIController : MonoBehaviour {

    public void PlayButtonClick()
    {
        Loading.Load(LoadingScene.Game);
    }
}
