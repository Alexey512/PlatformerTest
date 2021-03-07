using System;
using Assets.Scripts.Common.UI.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scrips.Game.UI
{
    public class MainMenuController: WindowController
    {
	    [SerializeField]
	    private Button _playButton;
	    
	    [SerializeField]
	    private Button _myButton;

	    private Action _playCallback;

	    public void SetCallback(Action playCallback)
	    {
		    _playCallback = playCallback;
	    }

	    protected override void OnInit()
	    {
		    _playButton.onClick.AddListener(() =>
		    {
			    _playCallback?.Invoke();
		    });
	    }

	    protected override void OnClose()
	    {
		    _playCallback = null;
	    }
    }
}
