using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    void Awake () {
        #region singleton
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        //keep him alive between scenes
        DontDestroyOnLoad(gameObject);
        #endregion
	}
	
}
