using RedRunner;
using RedRunner.Characters;
using RedRunner.Collectables;
using RedRunner.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class OpenWindowOnCollision : Coin
{
    [SerializeField]
    private string uiWindowName;
    public override void Collect()
    {
        //Debug.Log(this.gameObject.name);
        //GameManager.Singleton.m_Coin.Value++;
        //m_Animator.SetTrigger(COLLECT_TRIGGER);
        m_ParticleSystem.Play();
        m_SpriteRenderer.enabled = false;
		m_Collider2D.enabled = false;
		//Destroy(gameObject, m_ParticleSystem.main.duration);
		AudioManager.Singleton.PlayChestSound(transform.position);
        var uiManager = UIManager.Singleton;
        var InGameScreen = uiManager.UISCREENS.Find(el => el.ScreenInfo == UIScreenInfo.IN_GAME_SCREEN);
        if (InGameScreen != null)
        {
            uiManager.OpenScreen(InGameScreen);
            GameManager.Singleton.StartGame();
        }
        GameObject m_UIWindowObject = GameObject.Find(uiWindowName);
        if (m_UIWindowObject != null)
        {
            UIWindow m_UIWindow = m_UIWindowObject.GetComponent<UIWindow>();
            if (m_UIWindow != null)
            {
                UIManager.Singleton.CloseActiveWindow();
                UIManager.Singleton.OpenWindow(m_UIWindow);
            }
        }
    }
}
