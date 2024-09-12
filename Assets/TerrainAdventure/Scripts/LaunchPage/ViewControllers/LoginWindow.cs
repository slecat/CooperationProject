using UnityEngine;
using QFramework;
using SimpleHttpClient;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace LaunchPage
{
	public partial class LoginWindow : ViewController, IController
	{
		string url = "http://112.124.22.247:8888";
		void Start()
		{
			// Code Here
			BtnLogin.onClick.AddListener(OnBtnLoginOrRegister);
			BtnClose.onClick.AddListener(OnBtnClose);
			TogAgree.onValueChanged.AddListener((v) =>
			{
				if (v)
					TogAgree.transform.Find("Background").GetComponent<Image>().color = Color.white;
			});
		}
		public async void OnBtnLoginOrRegister()
		{
			if (!TogAgree.isOn)
			{
				TogAgree.GetComponent<RectTransform>().DOShakeAnchorPos(duration: 1, strength: 3, vibrato: 100);
				TogAgree.transform.Find("Background").GetComponent<Image>().color = Color.red;
				return;
			}
			string account = AccountInputField.text;
			string password = PasswordInputField.text;
			string data = $"account={account}&password={password}";
			var formData = new Dictionary<string, string>
			{
				{"account",account},
				{"password",password}
			};
			RequestResult requestResult = new RequestResult();
			requestResult = await HttpUitls.PostRequest(url + "/login", formData);
			if (requestResult.isSuccess)
			{
				gameObject.SetActive(false);
			}
			else
			{
				StartCoroutine(IEWarringWindowsShot());

			}
		}

		IEnumerator IEWarringWindowsShot()
		{
			WarringWindows.gameObject.SetActive(true);
			yield return new WaitForSeconds(3);
			WarringWindows.gameObject.SetActive(false);
		}
		public void OnBtnClose()
		{
			gameObject.SetActive(false);
		}

		public IArchitecture GetArchitecture()
		{
			return LaunchPage.Interface;
		}
	}
}