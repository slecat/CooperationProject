using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class testInputField : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private bool isSelect = false;
    private EventSystem system;

    public void OnDeselect(BaseEventData eventData)
    {
        isSelect = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelect = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && isSelect)
        {
            //下一个要切换到的
            Selectable next = null;
            //现在正处在能够处理事件的
            Selectable now = system.currentSelectedGameObject.GetComponent<Selectable>();
            //找到现在的下一个
            next = now.FindSelectableOnDown();
            if (next == null)
            {
                print("没有下一个了");
            }
            //让下一个能够处理事件
            system.SetSelectedGameObject(next.gameObject);
        }
    }
}
