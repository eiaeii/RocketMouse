using UnityEngine;
using System.Collections;

public class GameUIManager : MonoBehaviour {

    public Animator SettlementAnimator;
    public void OnRestartGame()
    {
        Application.LoadLevel("RocketMouse");
    }

    public void OnReturnTitle()
    {
        Application.LoadLevel("Title");
    }
}
