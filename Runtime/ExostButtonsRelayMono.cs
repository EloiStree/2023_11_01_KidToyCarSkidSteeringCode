using UnityEngine;
using UnityEngine.Events;

public class ExostButtonsRelayMono : MonoBehaviour
{

    public bool m_leftUpButtonOn;
    public bool m_rightUpButtonOn;
    public bool m_leftDownButtonOn;
    public bool m_rightDownButtonOn;


    public UnityEvent<bool> m_onLeftUpButtonOn;
    public UnityEvent<bool> m_onRightUpButtonOn;
    public UnityEvent<bool> m_onLeftDownButtonOn;
    public UnityEvent<bool> m_onRightDownButtonOn;

    public bool m_useUpdate = true;

    public void Update()
    {
        if (m_useUpdate)
        {
            PushState();
        }
    }

    [ContextMenu("Refresh Push")]
    public void PushState()
    {
        SetLeftUpButtonDown(m_leftUpButtonOn);
        SetLeftDownButtonDown(m_leftDownButtonOn);
        SetRightDownButtonDown(m_rightDownButtonOn);
        SetRightUpButtonDown(m_rightUpButtonOn);
       
    }
   

    public void SetLeftUpButtonDown(bool isOn)
    {
        m_leftUpButtonOn = isOn;
        m_onLeftUpButtonOn.Invoke(m_leftUpButtonOn);
    }
    public void SetLeftDownButtonDown(bool isOn)
    {
        m_leftDownButtonOn = isOn;
        m_onLeftDownButtonOn.Invoke(m_leftDownButtonOn);
    }
    public void SetRightUpButtonDown(bool isOn)
    {
        m_rightUpButtonOn = isOn;
        m_onRightUpButtonOn.Invoke(m_rightUpButtonOn);
    }
    public void SetRightDownButtonDown(bool isOn)
    {
        m_rightDownButtonOn = isOn;
        m_onRightDownButtonOn.Invoke(m_rightDownButtonOn);
    }

}
