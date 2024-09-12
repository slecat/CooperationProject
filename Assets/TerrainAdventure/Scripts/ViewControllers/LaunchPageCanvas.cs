using UnityEngine;
using QFramework;
using System.Collections;
using DG.Tweening;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace LaunchPage
{
	public partial class LaunchPageCanvas : ViewController, IController
	{
		// public GameObject WelcomePanel, DisclaimerPanel, InterludePanel, IntroducePanel, LoginPanel;
		void Start()
		{
			StartCoroutine(IELaunch());
			// Code Here
			DisclaimerPanel.alpha = 0;
			InterludePanel.alpha = 0;
			IntroducePanel.alpha = 0;
			this.RegisterEvent<ShowLoginPanelEvent>((e) =>
			{
				StartCoroutine(IEShowLogin());
			}).UnRegisterWhenGameObjectDestroyed(this);
		}
		IEnumerator IELaunch()
		{
			WelcomePanel.gameObject.SetActive(true);
			yield return new WaitForSeconds(3);
			WelcomePanel.DOFade(0, 1);
			yield return new WaitForSeconds(1);
			WelcomePanel.gameObject.SetActive(false);


			DisclaimerPanel.gameObject.SetActive(true);
			DisclaimerPanel.DOFade(1, 1);
			yield return new WaitForSeconds(1);
			DisclaimerPanel.DOFade(0, 1);
			yield return new WaitForSeconds(1);
			DisclaimerPanel.gameObject.SetActive(false);

			InterludePanel.DOFade(1, 1);
			InterludePanel.gameObject.SetActive(true);
			yield return new WaitForSeconds(1);
			InterludePanel.DOFade(0, 1);
			yield return new WaitForSeconds(1);
			InterludePanel.gameObject.SetActive(false);

			IntroducePanel.gameObject.SetActive(true);
			IntroducePanel.DOFade(1, 1);
			yield return new WaitForSeconds(1);

		}

		IEnumerator IEShowLogin()
		{
			yield return new WaitForSeconds(5);
			LoginPanel.gameObject.SetActive(true);
		}
		public IArchitecture GetArchitecture()
		{
			return LaunchPage.Interface;
		}
	}


}
