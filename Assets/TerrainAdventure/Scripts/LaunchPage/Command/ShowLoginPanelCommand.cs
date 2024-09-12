using QFramework;
using UnityEngine;

namespace LaunchPage
{
    public class ShowLoginPanelCommand : AbstractCommand
    {
        protected override void OnExecute()
        {
            this.SendEvent<ShowLoginPanelEvent>();
        }
    }
}
