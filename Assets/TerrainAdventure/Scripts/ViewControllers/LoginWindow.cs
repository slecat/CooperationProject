using UnityEngine;
using QFramework;
using SimpleHttpClient;

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
			BtnLoginOrRegister.onClick.AddListener(() =>
			{
				LoginOrRegister();
			});
		}
		public void LoginOrRegister()
		{
			string account = AccountInputField.text;
			string password = PasswordInputField.text;
			string data = $"account={account}&password={password}";
			string result = this.GetUtility<HttpUitls>().Post(url + "/login", data);
			Debug.Log(result);
		}

		public IArchitecture GetArchitecture()
		{
			return LaunchPage.Interface;
		}
	}
}
