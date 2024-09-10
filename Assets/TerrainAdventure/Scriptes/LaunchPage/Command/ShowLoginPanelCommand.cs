using QFramework;
using QFramework.Example;
using UnityEngine;

public class ShowLoginPanelCommand : AbstractCommand
{
    protected override void OnExecute()
    {
        this.SendEvent<ShowLoginPanelEvent>();
    }
}