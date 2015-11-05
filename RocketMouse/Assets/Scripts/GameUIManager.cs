using UnityEngine;
using System.Collections;

public class GameUIManager : MonoBehaviour {

    public Animator SettlementAnimator;
    public void OnRestartGame()
    {
        SettlementAnimator.SetBool("isOut", true);
        Application.LoadLevel("RocketMouse");
    }

    public void OnReturnTitle()
    {
        Application.LoadLevel("Title");
    }
}
