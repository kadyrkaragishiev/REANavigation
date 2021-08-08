using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	public class UIDebug : MonoBehaviour
	{
		private static UIDebug instance;
		public Text t;
		public static UIDebug getInstance()
		{
			if (instance == null)
			{
				Debug.Log("Create Obj: UIDebug");
				instance = new GameObject("UIDebug", typeof(UIDebug), typeof(CanvasScaler)).GetComponent<UIDebug>();
				instance.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
				instance.GetComponent<CanvasScaler>().uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
			}
			return instance;
		}


		List<string> lines = new List<string>();
		private void Awake()
		{
			instance = this;
		}

		public void printText(string line)
		{
			if (lines.Count > 14)
			{
				lines.RemoveAt(0);
			}
			lines.Add(line);
			string s = "";
			foreach (var item in lines)
			{
				s += item + "\n";
			}
			t.text = s;
		}


		public static void Log(object line)
		{
#if true
		getInstance().printText("[" + Time.time.ToString("0.0") + "] " + line.ToString());
#else
		Debug.Log("UIDebug is disable. " + "[" + Time.time.ToString("0.0") + "] " + line.ToString());
#endif
		}
}
	public static class Caller
	{
		public static void Log(object line)
		{
			UIDebug.Log(line);
		}
	}

