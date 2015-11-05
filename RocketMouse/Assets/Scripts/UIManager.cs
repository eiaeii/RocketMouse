using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Animator starButtonAnimator;
    public Animator setButtonAnimator;
    public Animator settingWnd;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("RocketMouse");
    }

    public void OnSeting()
    {
        starButtonAnimator.SetBool("isOut", true);
        setButtonAnimator.SetBool("isOut", true);

        settingWnd.enabled = true;
        settingWnd.SetBool("isOut", false);
    }

    public void OnCloseSetting()
    {
        starButtonAnimator.SetBool("isOut", false);
        setButtonAnimator.SetBool("isOut", false);

        settingWnd.SetBool("isOut", true);
    }

}
