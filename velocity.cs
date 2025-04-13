using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using CefSharp;
using CefSharp.Wpf;
using ExecutorUI;
using Microsoft.Win32;
using SimpleHttpServer;
using Velocity.Properties;

namespace Velocity;

public class MainWindow : Window, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003C_003CInitializeClientMenu_003Eb__33_1_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private void MoveNext()
		{
			MainWindow mainWindow = _003C_003E4__this;
			try
			{
				mainWindow.checkForClients();
				mainWindow.removeOldClients();
				mainWindow.updateClients();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003C_003CWindow_Loaded_003Eb__26_0_003Ed : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private TaskAwaiter<int> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MainWindow mainWindow = _003C_003E4__this;
			try
			{
				TaskAwaiter<int> awaiter;
				if (num != 0)
				{
					awaiter = TCP.getOpenPort().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<int>, _003C_003CWindow_Loaded_003Eb__26_0_003Ed>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<int>);
					num = (_003C_003E1__state = -1);
				}
				int result = awaiter.GetResult();
				mainWindow.openPortNumber = result;
				if (mainWindow.openPortNumber == -1)
				{
					MessageBox.Show("Failed to open communication bridge, try again");
					Application.Current.Shutdown();
				}
				else
				{
					_WebSocketServer.StartServer("http://localhost:3634/");
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncTaskMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action _003C_003E9__25_1;

		internal void _003CStartChildProcess_003Eb__25_1()
		{
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003CCloseButton_Click_003Ed__46 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MainWindow mainWindow = _003C_003E4__this;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					mainWindow.AnimateOpacity((UIElement)(object)mainWindow, 1.0, 0.0, 200);
					mainWindow.AnimateScaleTransform((FrameworkElement)(object)mainWindow, 1.0, 0.8, 1.0, 0.8, 200);
					awaiter = global::System.Threading.Tasks.Task.Delay(200).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CCloseButton_Click_003Ed__46>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				Cef.Shutdown();
				Application.Current.Shutdown();
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003CExecuteButton1_Click_003Ed__65 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private TaskAwaiter<JavascriptResponse> _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MainWindow mainWindow = _003C_003E4__this;
			try
			{
				TaskAwaiter<JavascriptResponse> awaiter;
				if (num != 0)
				{
					awaiter = WebBrowserExtensions.EvaluateScriptAsync((IChromiumWebBrowserBase)(object)mainWindow.cefBrowser, $"aceInterop.getContent('{mainWindow.activeTabId}')", (TimeSpan?)null, false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<JavascriptResponse>, _003CExecuteButton1_Click_003Ed__65>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<JavascriptResponse>);
					num = (_003C_003E1__state = -1);
				}
				JavascriptResponse result = awaiter.GetResult();
				if (result.Success && result.Result != null)
				{
					string plainText = ((object)result.Result.ToString()).ToString();
					try
					{
						NamedPipes.LuaPipe(Base64Encode(plainText));
					}
					catch
					{
					}
				}
				else
				{
					MessageBox.Show("Error while executing.", "Error", (MessageBoxButton)0, (MessageBoxImage)16);
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003CMinimizeButton_Click_003Ed__47 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MainWindow mainWindow = _003C_003E4__this;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					mainWindow.AnimateOpacity((UIElement)(object)mainWindow, 1.0, 0.0, 200);
					awaiter = global::System.Threading.Tasks.Task.Delay(200).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CMinimizeButton_Click_003Ed__47>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				((Window)mainWindow).WindowState = (WindowState)1;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003CSaveFileButton1_Click_003Ed__62 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private SaveFileDialog _003Cdialog_003E5__2;

		private TaskAwaiter<JavascriptResponse> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private void MoveNext()
		{
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MainWindow mainWindow = _003C_003E4__this;
			try
			{
				TaskAwaiter<JavascriptResponse> awaiter;
				if (num == 0)
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<JavascriptResponse>);
					num = (_003C_003E1__state = -1);
					goto IL_00f1;
				}
				TaskAwaiter awaiter2;
				if (num == 1)
				{
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0186;
				}
				_003Cdialog_003E5__2 = new SaveFileDialog
				{
					Filter = "Lua files (*.lua)|*.lua|All files (*.*)|*.*",
					DefaultExt = ".lua"
				};
				if (((CommonDialog)_003Cdialog_003E5__2).ShowDialog().GetValueOrDefault())
				{
					awaiter = WebBrowserExtensions.EvaluateScriptAsync((IChromiumWebBrowserBase)(object)mainWindow.cefBrowser, $"aceInterop.getContent('{mainWindow.activeTabId}')", (TimeSpan?)null, false).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<JavascriptResponse>, _003CSaveFileButton1_Click_003Ed__62>(ref awaiter, ref this);
						return;
					}
					goto IL_00f1;
				}
				goto end_IL_000e;
				IL_0186:
				((TaskAwaiter)(ref awaiter2)).GetResult();
				goto end_IL_000e;
				IL_00f1:
				JavascriptResponse result = awaiter.GetResult();
				if (result.Success && result.Result != null)
				{
					string text = result.Result.ToString();
					awaiter2 = File.WriteAllTextAsync(((FileDialog)_003Cdialog_003E5__2).FileName, text, default(CancellationToken)).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter2)).IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSaveFileButton1_Click_003Ed__62>(ref awaiter2, ref this);
						return;
					}
					goto IL_0186;
				}
				MessageBox.Show("Error while saving.", "Error", (MessageBoxButton)0, (MessageBoxImage)16);
				end_IL_000e:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				_003Cdialog_003E5__2 = null;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			_003Cdialog_003E5__2 = null;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003CSettingsButton_Click_003Ed__50 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private void MoveNext()
		{
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			int num = _003C_003E1__state;
			MainWindow CS_0024_003C_003E8__locals0 = _003C_003E4__this;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = global::System.Threading.Tasks.Task.Delay(100).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CSettingsButton_Click_003Ed__50>(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				if (!CS_0024_003C_003E8__locals0.isSettingsVisible)
				{
					((UIElement)CS_0024_003C_003E8__locals0.PageStatus).Visibility = (Visibility)0;
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.PageStatus, 0.0, 1.0, 200);
					((UIElement)CS_0024_003C_003E8__locals0.SettingsBorder).Visibility = (Visibility)0;
					CS_0024_003C_003E8__locals0.AnimateTranslateTransform((FrameworkElement)(object)CS_0024_003C_003E8__locals0.SettingsBorder, 200.0, 0.0, 300, "Y");
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.SettingsBorder, 0.0, 1.0, 300);
					CS_0024_003C_003E8__locals0.isSettingsVisible = true;
				}
				else
				{
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.PageStatus, 1.0, 0.0, 200);
					((UIElement)CS_0024_003C_003E8__locals0.PageStatus).Visibility = (Visibility)2;
					CS_0024_003C_003E8__locals0.AnimateTranslateTransform((FrameworkElement)(object)CS_0024_003C_003E8__locals0.SettingsBorder, 0.0, 200.0, 300, "Y");
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.SettingsBorder, 1.0, 0.0, 300, (Action)([CompilerGenerated] () =>
					{
						((UIElement)CS_0024_003C_003E8__locals0.SettingsBorder).Visibility = (Visibility)2;
					}));
					CS_0024_003C_003E8__locals0.isSettingsVisible = false;
				}
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	private struct _003CWindow_Loaded_003Ed__26 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public MainWindow _003C_003E4__this;

		private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

		private TaskAwaiter<string> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private void MoveNext()
		{
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_039f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_042f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0384: Unknown result type (might be due to invalid IL or missing references)
			//IL_0386: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Unknown result type (might be due to invalid IL or missing references)
			//IL_040c: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			int num = _003C_003E1__state;
			MainWindow CS_0024_003C_003E8__locals0 = _003C_003E4__this;
			try
			{
				TaskAwaiter<HttpResponseMessage> awaiter3;
				TaskAwaiter<string> awaiter2;
				TaskAwaiter awaiter;
				HttpResponseMessage result;
				SonarClientInformationModel sonarClientInformationModel;
				switch (num)
				{
				default:
					awaiter3 = CS_0024_003C_003E8__locals0.h_client.GetAsync("https://raw.githubusercontent.com/KryptonSoftworks/SonarInfo/refs/heads/main/information.json").GetAwaiter();
					if (!awaiter3.IsCompleted)
					{
						num = (_003C_003E1__state = 0);
						_003C_003Eu__1 = awaiter3;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, _003CWindow_Loaded_003Ed__26>(ref awaiter3, ref this);
						return;
					}
					goto IL_008a;
				case 0:
					awaiter3 = _003C_003Eu__1;
					_003C_003Eu__1 = default(TaskAwaiter<HttpResponseMessage>);
					num = (_003C_003E1__state = -1);
					goto IL_008a;
				case 1:
					awaiter2 = _003C_003Eu__2;
					_003C_003Eu__2 = default(TaskAwaiter<string>);
					num = (_003C_003E1__state = -1);
					goto IL_00f3;
				case 2:
					awaiter = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_0286;
				case 3:
					awaiter = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_030c;
				case 4:
					awaiter = _003C_003Eu__3;
					_003C_003Eu__3 = default(TaskAwaiter);
					num = (_003C_003E1__state = -1);
					goto IL_03bb;
				case 5:
					{
						awaiter = _003C_003Eu__3;
						_003C_003Eu__3 = default(TaskAwaiter);
						num = (_003C_003E1__state = -1);
						break;
					}
					IL_0286:
					((TaskAwaiter)(ref awaiter)).GetResult();
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.SplashLogo, 0.0, 1.0, 400);
					awaiter = global::System.Threading.Tasks.Task.Delay(800).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 3);
						_003C_003Eu__3 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWindow_Loaded_003Ed__26>(ref awaiter, ref this);
						return;
					}
					goto IL_030c;
					IL_008a:
					result = awaiter3.GetResult();
					result.EnsureSuccessStatusCode();
					awaiter2 = result.Content.ReadAsStringAsync().GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_003C_003E1__state = 1);
						_003C_003Eu__2 = awaiter2;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter<string>, _003CWindow_Loaded_003Ed__26>(ref awaiter2, ref this);
						return;
					}
					goto IL_00f3;
					IL_03bb:
					((TaskAwaiter)(ref awaiter)).GetResult();
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.SplashBackgroundOrSomethingIDontFuckingKnow, 1.0, 0.0, 300);
					awaiter = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 5);
						_003C_003Eu__3 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWindow_Loaded_003Ed__26>(ref awaiter, ref this);
						return;
					}
					break;
					IL_00f3:
					sonarClientInformationModel = JsonSerializer.Deserialize<SonarClientInformationModel>(awaiter2.GetResult(), (JsonSerializerOptions)null);
					if (sonarClientInformationModel.offline)
					{
						MessageBox.Show("Velocity is currently down, please check back later!");
						Application.Current.Shutdown();
					}
					else if (sonarClientInformationModel.version != CS_0024_003C_003E8__locals0.exp_version)
					{
						MessageBox.Show("This version of Velocity is out of date, please download the newest from our github!");
						Application.Current.Shutdown();
					}
					else
					{
						if (!(sonarClientInformationModel.rbx_client_version != CS_0024_003C_003E8__locals0.rbx_version))
						{
							((DispatcherObject)CS_0024_003C_003E8__locals0).Dispatcher.BeginInvoke((global::System.Delegate)(object)(Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003CWindow_Loaded_003Eb__26_0_003Ed))] [CompilerGenerated] () =>
							{
								//IL_0002: Unknown result type (might be due to invalid IL or missing references)
								//IL_0007: Unknown result type (might be due to invalid IL or missing references)
								_003C_003CWindow_Loaded_003Eb__26_0_003Ed _003C_003CWindow_Loaded_003Eb__26_0_003Ed = default(_003C_003CWindow_Loaded_003Eb__26_0_003Ed);
								_003C_003CWindow_Loaded_003Eb__26_0_003Ed._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
								_003C_003CWindow_Loaded_003Eb__26_0_003Ed._003C_003E4__this = CS_0024_003C_003E8__locals0;
								_003C_003CWindow_Loaded_003Eb__26_0_003Ed._003C_003E1__state = -1;
								((AsyncTaskMethodBuilder)(ref _003C_003CWindow_Loaded_003Eb__26_0_003Ed._003C_003Et__builder)).Start<_003C_003CWindow_Loaded_003Eb__26_0_003Ed>(ref _003C_003CWindow_Loaded_003Eb__26_0_003Ed);
								return ((AsyncTaskMethodBuilder)(ref _003C_003CWindow_Loaded_003Eb__26_0_003Ed._003C_003Et__builder)).Task;
							}), global::System.Array.Empty<object>());
							ChangeBlurRadius((UIElement)(object)CS_0024_003C_003E8__locals0.UIContainer, 15.0);
							((UIElement)CS_0024_003C_003E8__locals0.SplashBackgroundOrSomethingIDontFuckingKnow).Visibility = (Visibility)0;
							((UIElement)CS_0024_003C_003E8__locals0.SplashLogo).Visibility = (Visibility)0;
							((UIElement)CS_0024_003C_003E8__locals0.SplashLogo).Opacity = 0.0;
							CS_0024_003C_003E8__locals0.AnimateScaleTransform((FrameworkElement)(object)CS_0024_003C_003E8__locals0, 0.5, 1.0, 0.5, 1.0, 1000);
							CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0, 0.0, 1.0, 500);
							awaiter = global::System.Threading.Tasks.Task.Delay(600).GetAwaiter();
							if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
							{
								num = (_003C_003E1__state = 2);
								_003C_003Eu__3 = awaiter;
								((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWindow_Loaded_003Ed__26>(ref awaiter, ref this);
								return;
							}
							goto IL_0286;
						}
						MessageBox.Show("This version of Velocity is out of date, please download the newest from our github!");
						Application.Current.Shutdown();
					}
					goto end_IL_000e;
					IL_030c:
					((TaskAwaiter)(ref awaiter)).GetResult();
					CS_0024_003C_003E8__locals0.AddNewTab();
					CS_0024_003C_003E8__locals0.AnimateOpacity((UIElement)(object)CS_0024_003C_003E8__locals0.SplashLogo, 1.0, 0.0, 400);
					CS_0024_003C_003E8__locals0.AnimateBlur((UIElement)(object)CS_0024_003C_003E8__locals0.UIContainer, 15.0, 0.0, 1000);
					awaiter = global::System.Threading.Tasks.Task.Delay(300).GetAwaiter();
					if (!((TaskAwaiter)(ref awaiter)).IsCompleted)
					{
						num = (_003C_003E1__state = 4);
						_003C_003Eu__3 = awaiter;
						((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).AwaitUnsafeOnCompleted<TaskAwaiter, _003CWindow_Loaded_003Ed__26>(ref awaiter, ref this);
						return;
					}
					goto IL_03bb;
				}
				((TaskAwaiter)(ref awaiter)).GetResult();
				((UIElement)CS_0024_003C_003E8__locals0.SplashBackgroundOrSomethingIDontFuckingKnow).Visibility = (Visibility)2;
				((UIElement)CS_0024_003C_003E8__locals0.SplashLogo).Visibility = (Visibility)2;
				end_IL_000e:;
			}
			catch (global::System.Exception exception)
			{
				_003C_003E1__state = -2;
				((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetException(exception);
				return;
			}
			_003C_003E1__state = -2;
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetResult();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			((AsyncVoidMethodBuilder)(ref _003C_003Et__builder)).SetStateMachine(stateMachine);
		}
	}

	private List<int> selected_clients = new List<int>();

	private List<int> injected_pids = new List<int>();

	private HttpClient h_client = new HttpClient();

	private string rbx_version = "version-c2c9efad42eb44e5";

	private string exp_version = "0.3.4";

	private bool STalwaysontop;

	private bool STautoinject;

	private bool STautoexecute;

	private bool egg;

	private readonly Dictionary<int, Button> tabButtons = new Dictionary<int, Button>();

	private readonly Dictionary<int, int> tabSessions = new Dictionary<int, int>();

	private int tabCounter = 1;

	private int activeTabId;

	private bool isSettingsVisible;

	private bool ismaximized;

	private double _restorewidth = 800.0;

	private double _restoreheight = 600.0;

	private double _restoreleft;

	private double _restoretop;

	private static Timer _timer;

	private int openPortNumber;

	private Process childProcess;

	private Process decompilerPorccess;

	internal Border MainBorder;

	internal Grid UIContainer;

	internal Button CloseButton;

	internal Button MaximizeButton;

	internal Button MinimizeButton;

	internal Button BugreportButton;

	internal Button SettingsButton;

	internal Image Logo;

	internal Label PageStatus;

	internal Border ToolBar;

	internal Button SaveFileButton1;

	internal Button OpenFileButton1;

	internal Button ClearButton1;

	internal Button ExecuteButton1;

	internal Button MenuButton1;

	internal Button ClientsButton1;

	internal Button InjectButton1;

	internal ChromiumWebBrowser cefBrowser;

	internal ScrollViewer TabScroll;

	internal StackPanel TabContainer;

	internal Button AddTabButton;

	internal Border SettingsBorder;

	internal Button AlwaysOnTopCheckbox;

	internal Image AOTcheck;

	internal Button AutoInjectCheckbox;

	internal Image AINJcheck;

	internal Button AutoExeCheckbox;

	internal Image AEXcheck;

	internal Button EggCheckbox;

	internal Image EGGcheck;

	internal Button OpenMainFolderButton;

	internal Button ResetSettingsButton;

	internal Button DebugInfoButton;

	internal Border SplashBackgroundOrSomethingIDontFuckingKnow;

	internal Image SplashLogo;

	internal Border ClientsList;

	internal StackPanel ClientListContainer;

	internal Label ClientsText;

	internal Label ClientsMenuLabel1;

	internal Label ClientsMenuLabel2;

	internal Border ClientsListCloseHitbox;

	private bool _contentLoaded;

	public MainWindow()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		InitializeComponent();
		if (!Directory.Exists("Scripts"))
		{
			Directory.CreateDirectory("Scripts");
		}
		if (!Directory.Exists("Workspace"))
		{
			Directory.CreateDirectory("Workspace");
		}
		InitializeCef();
		LoadSettings();
		SetupRandomLogo();
		InitializeClientMenu();
		StartChildProcess();
		((Window)this).Closed += new EventHandler(MainWindow_Closed);
		new Thread(new ThreadStart(Bombaclart.Fatass)).Start();
	}

	private void MainWindow_Closed(object sender, EventArgs e)
	{
		if (childProcess != null && !childProcess.HasExited)
		{
			try
			{
				childProcess.Kill();
			}
			catch
			{
			}
		}
		if (decompilerPorccess != null && !decompilerPorccess.HasExited)
		{
			try
			{
				decompilerPorccess.Kill();
			}
			catch
			{
			}
		}
	}

	private void StartChildProcess()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		try
		{
			decompilerPorccess = new Process();
			decompilerPorccess.StartInfo.FileName = "Bin\\Decompiler.exe";
			decompilerPorccess.StartInfo.UseShellExecute = false;
			decompilerPorccess.EnableRaisingEvents = true;
			decompilerPorccess.StartInfo.RedirectStandardError = true;
			decompilerPorccess.StartInfo.RedirectStandardInput = true;
			decompilerPorccess.StartInfo.RedirectStandardOutput = true;
			decompilerPorccess.StartInfo.CreateNoWindow = true;
			decompilerPorccess.Exited += (EventHandler)([CompilerGenerated] (object? s, EventArgs args) =>
			{
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_001f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Expected O, but got Unknown
				Dispatcher dispatcher = ((DispatcherObject)this).Dispatcher;
				object obj = _003C_003Ec._003C_003E9__25_1;
				if (obj == null)
				{
					Action val = delegate
					{
					};
					_003C_003Ec._003C_003E9__25_1 = val;
					obj = (object)val;
				}
				dispatcher.Invoke((Action)obj);
			});
			decompilerPorccess.Start();
		}
		catch (global::System.Exception)
		{
		}
	}

	[AsyncStateMachine(typeof(_003CWindow_Loaded_003Ed__26))]
	private void Window_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_003CWindow_Loaded_003Ed__26 _003CWindow_Loaded_003Ed__ = default(_003CWindow_Loaded_003Ed__26);
		_003CWindow_Loaded_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CWindow_Loaded_003Ed__._003C_003E4__this = this;
		_003CWindow_Loaded_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CWindow_Loaded_003Ed__._003C_003Et__builder)).Start<_003CWindow_Loaded_003Ed__26>(ref _003CWindow_Loaded_003Ed__);
	}

	private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)((MouseEventArgs)e).LeftButton == 1)
		{
			((Window)this).DragMove();
		}
	}

	private void Window_StateChanged(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		if ((int)((Window)this).WindowState == 0)
		{
			AnimateOpacity((UIElement)(object)this, 0.0, 1.0, 200);
		}
	}

	private void SaveSettings()
	{
		Settings.Default.STalwaysontop = STalwaysontop;
		Settings.Default.STautoinject = STautoinject;
		Settings.Default.STautoexecute = STautoexecute;
		Settings.Default.egg = egg;
		((SettingsBase)Settings.Default).Save();
	}

	private void LoadSettings()
	{
		STalwaysontop = Settings.Default.STalwaysontop;
		STautoinject = Settings.Default.STautoinject;
		STautoexecute = Settings.Default.STautoexecute;
		egg = Settings.Default.egg;
		((Control)AlwaysOnTopCheckbox).Background = (Brush)(object)GetBrush(STalwaysontop);
		((Control)AutoInjectCheckbox).Background = (Brush)(object)GetBrush(STautoinject);
		((Control)AutoExeCheckbox).Background = (Brush)(object)GetBrush(STautoexecute);
		((Control)EggCheckbox).Background = (Brush)(object)GetBrush(egg);
		((Window)this).Topmost = STalwaysontop;
		((UIElement)AOTcheck).Visibility = (Visibility)((!STalwaysontop) ? 2 : 0);
		((UIElement)AINJcheck).Visibility = (Visibility)((!STautoinject) ? 2 : 0);
		((UIElement)AEXcheck).Visibility = (Visibility)((!STautoexecute) ? 2 : 0);
		((UIElement)EGGcheck).Visibility = (Visibility)((!egg) ? 2 : 0);
	}

	private void InitializeCef()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		((Dictionary<string, string>)(object)((CefSettingsBase)new CefSettings()).CefCommandLineArgs).Add("disable-gpu-compositing", "1");
		string address = Path.Combine(AppContext.BaseDirectory, "assets", "ace-editor", "ace.html");
		cefBrowser.Address = address;
		((UIElement)this).LayoutUpdated += (EventHandler)([CompilerGenerated] (object? sender, EventArgs e) =>
		{
			if (cefBrowser.IsBrowserInitialized)
			{
				WebBrowserExtensions.ExecuteScriptAsync((IChromiumWebBrowserBase)(object)cefBrowser, "window.dispatchEvent(new Event('resize'));");
			}
		});
	}

	private void SetupRandomLogo()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (new Random().Next(1, 1000) == 420)
		{
			Logo.Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,,/Assets/Images/burger.png"));
		}
	}

	private void InitializeClientMenu()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		_timer = new Timer(100.0);
		_timer.Elapsed += (ElapsedEventHandler)([CompilerGenerated] (object source, ElapsedEventArgs e) =>
		{
			if (Process.GetProcessesByName("RobloxPlayerBeta").Length != 0)
			{
				string plainText = "setworkspacefolder: " + Directory.GetCurrentDirectory() + "\\Workspace";
				try
				{
					NamedPipes.LuaPipe(Base64Encode(plainText));
				}
				catch
				{
				}
			}
			((DispatcherObject)this).Dispatcher.BeginInvoke((global::System.Delegate)(object)(Func<global::System.Threading.Tasks.Task>)([AsyncStateMachine(typeof(_003C_003CInitializeClientMenu_003Eb__33_1_003Ed))] [CompilerGenerated] () =>
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				_003C_003CInitializeClientMenu_003Eb__33_1_003Ed _003C_003CInitializeClientMenu_003Eb__33_1_003Ed = default(_003C_003CInitializeClientMenu_003Eb__33_1_003Ed);
				_003C_003CInitializeClientMenu_003Eb__33_1_003Ed._003C_003Et__builder = AsyncTaskMethodBuilder.Create();
				_003C_003CInitializeClientMenu_003Eb__33_1_003Ed._003C_003E4__this = this;
				_003C_003CInitializeClientMenu_003Eb__33_1_003Ed._003C_003E1__state = -1;
				((AsyncTaskMethodBuilder)(ref _003C_003CInitializeClientMenu_003Eb__33_1_003Ed._003C_003Et__builder)).Start<_003C_003CInitializeClientMenu_003Eb__33_1_003Ed>(ref _003C_003CInitializeClientMenu_003Eb__33_1_003Ed);
				return ((AsyncTaskMethodBuilder)(ref _003C_003CInitializeClientMenu_003Eb__33_1_003Ed._003C_003Et__builder)).Task;
			}), global::System.Array.Empty<object>());
		});
		_timer.AutoReset = true;
		_timer.Enabled = true;
		_timer.Start();
	}

	private void AnimateBlur(UIElement element, double fromRadius, double toRadius, int duration)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0063: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		if (element != null)
		{
			Effect effect = element.Effect;
			BlurEffect val = (BlurEffect)(object)((effect is BlurEffect) ? effect : null);
			if (val == null)
			{
				val = (BlurEffect)(object)(element.Effect = (Effect)new BlurEffect
				{
					Radius = fromRadius
				});
			}
			DoubleAnimation val3 = new DoubleAnimation
			{
				From = fromRadius,
				To = toRadius,
				Duration = Duration.op_Implicit(TimeSpan.FromMilliseconds((double)duration)),
				EasingFunction = (IEasingFunction)new QuadraticEase()
			};
			((Animatable)val).BeginAnimation(BlurEffect.RadiusProperty, (AnimationTimeline)(object)val3);
		}
	}

	private void AnimateTranslateTransform(FrameworkElement element, double from, double to, int duration, string axis)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005f: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		Transform renderTransform = ((UIElement)element).RenderTransform;
		TranslateTransform val = (TranslateTransform)(object)((renderTransform is TranslateTransform) ? renderTransform : null);
		if (val == null)
		{
			val = (TranslateTransform)(object)(((UIElement)element).RenderTransform = (Transform)new TranslateTransform());
		}
		DoubleAnimation val3 = new DoubleAnimation
		{
			From = from,
			To = to,
			Duration = Duration.op_Implicit(TimeSpan.FromMilliseconds((double)duration)),
			EasingFunction = (IEasingFunction)new CubicEase
			{
				EasingMode = (EasingMode)2
			}
		};
		if (axis == "X")
		{
			((Animatable)val).BeginAnimation(TranslateTransform.XProperty, (AnimationTimeline)(object)val3);
		}
		else if (axis == "Y")
		{
			((Animatable)val).BeginAnimation(TranslateTransform.YProperty, (AnimationTimeline)(object)val3);
		}
	}

	private void AnimateScaleTransform(FrameworkElement element, double fromX, double toX, double fromY, double toY, int duration, bool animateX = true, bool animateY = true)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0095: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f6: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_014d: Expected O, but got Unknown
		((UIElement)element).RenderTransformOrigin = new Point(0.5, 0.5);
		Transform renderTransform = ((UIElement)element).RenderTransform;
		ScaleTransform val = (ScaleTransform)(object)((renderTransform is ScaleTransform) ? renderTransform : null);
		if (val == null)
		{
			val = (ScaleTransform)(object)(((UIElement)element).RenderTransform = (Transform)new ScaleTransform());
		}
		if (animateX && animateY)
		{
			double num = toX / fromX;
			double num2 = toY / fromY;
			double num3 = Math.Min(num, num2);
			DoubleAnimation val3 = new DoubleAnimation
			{
				From = fromX,
				To = fromX * num3,
				Duration = Duration.op_Implicit(TimeSpan.FromMilliseconds((double)duration)),
				EasingFunction = (IEasingFunction)new QuadraticEase
				{
					EasingMode = (EasingMode)1
				}
			};
			((Animatable)val).BeginAnimation(ScaleTransform.ScaleXProperty, (AnimationTimeline)(object)val3);
			((Animatable)val).BeginAnimation(ScaleTransform.ScaleYProperty, (AnimationTimeline)(object)val3);
			return;
		}
		if (animateX)
		{
			DoubleAnimation val4 = new DoubleAnimation
			{
				From = fromX,
				To = toX,
				Duration = Duration.op_Implicit(TimeSpan.FromMilliseconds((double)duration)),
				EasingFunction = (IEasingFunction)new QuadraticEase
				{
					EasingMode = (EasingMode)1
				}
			};
			((Animatable)val).BeginAnimation(ScaleTransform.ScaleXProperty, (AnimationTimeline)(object)val4);
		}
		if (animateY)
		{
			DoubleAnimation val5 = new DoubleAnimation
			{
				From = fromY,
				To = toY,
				Duration = Duration.op_Implicit(TimeSpan.FromMilliseconds((double)duration)),
				EasingFunction = (IEasingFunction)new CubicEase
				{
					EasingMode = (EasingMode)2
				}
			};
			((Animatable)val).BeginAnimation(ScaleTransform.ScaleYProperty, (AnimationTimeline)(object)val5);
		}
	}

	public void AnimateOpacity(UIElement element, double from, double to, int duration, Action? completed = null)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0051: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		Action completed2 = completed;
		DoubleAnimation val = new DoubleAnimation
		{
			From = from,
			To = to,
			Duration = Duration.op_Implicit(TimeSpan.FromMilliseconds((double)duration)),
			EasingFunction = (IEasingFunction)new CubicEase
			{
				EasingMode = (EasingMode)2
			}
		};
		((Timeline)val).Completed += (EventHandler)delegate
		{
			Action obj = completed2;
			if (obj != null)
			{
				obj.Invoke();
			}
		};
		element.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline)(object)val);
	}

	public static void ChangeBlurRadius(UIElement element, double radius)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (element != null)
		{
			Effect effect = element.Effect;
			BlurEffect val = (BlurEffect)(object)((effect is BlurEffect) ? effect : null);
			if (val != null)
			{
				val.Radius = radius;
				return;
			}
			element.Effect = (Effect)new BlurEffect
			{
				Radius = radius
			};
		}
	}

	public void AddTabButton_Click(object sender, RoutedEventArgs e)
	{
		CreateNewTab(tabCounter);
		tabCounter++;
	}

	private void AddNewTab()
	{
		CreateNewTab(tabCounter++);
	}

	private void CreateNewTab(int tabId)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0159: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d5: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		Button val = new Button
		{
			Template = (ControlTemplate)((FrameworkElement)this).FindResource((object)"TabButton"),
			Height = 30.0,
			VerticalAlignment = (VerticalAlignment)0,
			Margin = new Thickness(10.0, 0.0, 0.0, 0.0)
		};
		((Control)val).Background = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1B1B1B"));
		((Control)val).BorderBrush = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00707070"));
		StackPanel val2 = new StackPanel
		{
			Orientation = (Orientation)0,
			Margin = new Thickness(5.0, 0.0, 5.0, 0.0)
		};
		Label val3 = new Label
		{
			Content = $"Script {tabId}",
			Foreground = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEBEBEB")),
			FontSize = 12.0,
			FontFamily = (FontFamily)((FrameworkElement)this).FindResource((object)"Satoshi")
		};
		((Panel)val2).Children.Add((UIElement)(object)val3);
		Button val4 = new Button
		{
			Template = (ControlTemplate)((FrameworkElement)this).FindResource((object)"RoundButton"),
			Width = 18.0,
			Height = 18.0,
			Background = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00DDDDDD")),
			BorderBrush = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00707070"))
		};
		Image val5 = new Image
		{
			Source = (ImageSource)new BitmapImage(new Uri("pack://application:,,,/assets/close.png")),
			Height = 15.0,
			Width = 15.0
		};
		RenderOptions.SetBitmapScalingMode((DependencyObject)(object)val5, (BitmapScalingMode)2);
		((ContentControl)val4).Content = val5;
		((ButtonBase)val4).Click += (RoutedEventHandler)delegate
		{
			RemoveTab(tabId);
		};
		((Panel)val2).Children.Add((UIElement)(object)val4);
		((ContentControl)val).Content = val2;
		((Panel)TabContainer).Children.Insert(((Panel)TabContainer).Children.Count - 1, (UIElement)(object)val);
		WebBrowserExtensions.ExecuteScriptAsync((IChromiumWebBrowserBase)(object)cefBrowser, $"window.aceInterop.createSession({tabId})");
		tabButtons[tabId] = val;
		tabSessions[tabId] = tabId;
		((ButtonBase)val).Click += (RoutedEventHandler)delegate
		{
			SwitchToTab(tabId);
		};
		SwitchToTab(tabId);
	}

	private void SwitchToTab(int tabId)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		if (!tabSessions.ContainsKey(tabId))
		{
			return;
		}
		Enumerator<int, Button> enumerator = tabButtons.Values.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				((Control)enumerator.Current).Background = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF1B1B1B"));
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
		((Control)tabButtons[tabId]).Background = (Brush)new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF3B3B3B"));
		WebBrowserExtensions.ExecuteScriptAsync((IChromiumWebBrowserBase)(object)cefBrowser, $"window.aceInterop.switchSession({tabId});");
		activeTabId = tabId;
	}

	private void RemoveTab(int tabId)
	{
		Button val = default(Button);
		if (tabButtons.TryGetValue(tabId, ref val))
		{
			((Panel)TabContainer).Children.Remove((UIElement)(object)val);
			tabButtons.Remove(tabId);
		}
		WebBrowserExtensions.ExecuteScriptAsync((IChromiumWebBrowserBase)(object)cefBrowser, $"window.aceInterop.removeSession({tabId})");
		tabSessions.Remove(tabId);
		if (activeTabId == tabId)
		{
			if (tabButtons.Count > 0)
			{
				int tabId2 = Enumerable.Min((global::System.Collections.Generic.IEnumerable<int>)tabButtons.Keys);
				SwitchToTab(tabId2);
			}
			else
			{
				AddNewTab();
			}
		}
	}

	private void Button_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		if (((int)e.Key == 18 || (int)e.Key == 6) && ((UIElement)(Button)sender).IsKeyboardFocused)
		{
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private SolidColorBrush GetBrush(bool state)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		return new SolidColorBrush(state ? Color.FromRgb((byte)100, (byte)100, (byte)100) : Color.FromRgb((byte)27, (byte)27, (byte)27));
	}

	[AsyncStateMachine(typeof(_003CCloseButton_Click_003Ed__46))]
	private void CloseButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_003CCloseButton_Click_003Ed__46 _003CCloseButton_Click_003Ed__ = default(_003CCloseButton_Click_003Ed__46);
		_003CCloseButton_Click_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CCloseButton_Click_003Ed__._003C_003E4__this = this;
		_003CCloseButton_Click_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CCloseButton_Click_003Ed__._003C_003Et__builder)).Start<_003CCloseButton_Click_003Ed__46>(ref _003CCloseButton_Click_003Ed__);
	}

	[AsyncStateMachine(typeof(_003CMinimizeButton_Click_003Ed__47))]
	private void MinimizeButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_003CMinimizeButton_Click_003Ed__47 _003CMinimizeButton_Click_003Ed__ = default(_003CMinimizeButton_Click_003Ed__47);
		_003CMinimizeButton_Click_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CMinimizeButton_Click_003Ed__._003C_003E4__this = this;
		_003CMinimizeButton_Click_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CMinimizeButton_Click_003Ed__._003C_003Et__builder)).Start<_003CMinimizeButton_Click_003Ed__47>(ref _003CMinimizeButton_Click_003Ed__);
	}

	private void MaximizeButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		if (ismaximized)
		{
			((FrameworkElement)this).Width = _restorewidth;
			((FrameworkElement)this).Height = _restoreheight;
			((Window)this).Left = _restoreleft;
			((Window)this).Top = _restoretop;
			ismaximized = false;
			return;
		}
		_restorewidth = ((FrameworkElement)this).Width;
		_restoreheight = ((FrameworkElement)this).Height;
		_restoreleft = ((Window)this).Left;
		_restoretop = ((Window)this).Top;
		Rect workArea = SystemParameters.WorkArea;
		((Window)this).Top = ((Rect)(ref workArea)).Top;
		workArea = SystemParameters.WorkArea;
		((Window)this).Left = ((Rect)(ref workArea)).Left;
		workArea = SystemParameters.WorkArea;
		((FrameworkElement)this).Width = ((Rect)(ref workArea)).Width;
		workArea = SystemParameters.WorkArea;
		((FrameworkElement)this).Height = ((Rect)(ref workArea)).Height;
		ismaximized = true;
	}

	private void BugreportButton_ShowDevtools(object sender, RoutedEventArgs e)
	{
		WebBrowserExtensions.ShowDevTools((IChromiumWebBrowserBase)(object)cefBrowser, (IWindowInfo)null, 0, 0);
	}

	[AsyncStateMachine(typeof(_003CSettingsButton_Click_003Ed__50))]
	private void SettingsButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_003CSettingsButton_Click_003Ed__50 _003CSettingsButton_Click_003Ed__ = default(_003CSettingsButton_Click_003Ed__50);
		_003CSettingsButton_Click_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CSettingsButton_Click_003Ed__._003C_003E4__this = this;
		_003CSettingsButton_Click_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CSettingsButton_Click_003Ed__._003C_003Et__builder)).Start<_003CSettingsButton_Click_003Ed__50>(ref _003CSettingsButton_Click_003Ed__);
	}

	private void ClientsButton1_Click(object sender, RoutedEventArgs e)
	{
		AnimateBlur((UIElement)(object)UIContainer, 0.0, 10.0, 200);
		((UIElement)ClientsList).Visibility = (Visibility)0;
		((UIElement)ClientsListCloseHitbox).Visibility = (Visibility)0;
		AnimateTranslateTransform((FrameworkElement)(object)ClientsList, 100.0, 0.0, 200, "X");
		AnimateOpacity((UIElement)(object)ClientsList, 0.0, 1.0, 200);
	}

	private void ClientsListHitbox_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		AnimateBlur((UIElement)(object)UIContainer, 10.0, 0.0, 200);
		AnimateTranslateTransform((FrameworkElement)(object)ClientsList, 0.0, 100.0, 200, "X");
		AnimateOpacity((UIElement)(object)ClientsList, 1.0, 0.0, 200, (Action)([CompilerGenerated] () =>
		{
			((UIElement)ClientsList).Visibility = (Visibility)2;
			((UIElement)ClientsListCloseHitbox).Visibility = (Visibility)2;
		}));
	}

	private void ClearButton1_Click(object sender, RoutedEventArgs e)
	{
		if (tabSessions.ContainsKey(activeTabId))
		{
			WebBrowserExtensions.ExecuteScriptAsync((IChromiumWebBrowserBase)(object)cefBrowser, $"window.aceInterop.clearSession({activeTabId});");
		}
	}

	private void OpenFileButton1_Click(object sender, RoutedEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		OpenFileDialog val = new OpenFileDialog();
		if (((CommonDialog)val).ShowDialog().GetValueOrDefault())
		{
			string text = File.ReadAllText(((FileDialog)val).FileName);
			if (tabSessions.ContainsKey(activeTabId))
			{
				string text2 = $"aceInterop.loadContent('{activeTabId}', {JsonSerializer.Serialize<string>(text, (JsonSerializerOptions)null)});";
				WebBrowserExtensions.ExecuteScriptAsync((IChromiumWebBrowserBase)(object)cefBrowser, text2);
			}
		}
	}

	private void AlwaysOnTopCheckbox_Click(object sender, RoutedEventArgs e)
	{
		STalwaysontop = !STalwaysontop;
		((Window)this).Topmost = STalwaysontop;
		((Control)AlwaysOnTopCheckbox).Background = (Brush)(object)GetBrush(STalwaysontop);
		((UIElement)AOTcheck).Visibility = (Visibility)((!STalwaysontop) ? 2 : 0);
		SaveSettings();
	}

	private void AutoInjectCheckbox_Click(object sender, RoutedEventArgs e)
	{
		STautoinject = !STautoinject;
		((Control)AutoInjectCheckbox).Background = (Brush)(object)GetBrush(STautoinject);
		((UIElement)AINJcheck).Visibility = (Visibility)((!STautoinject) ? 2 : 0);
		SaveSettings();
	}

	private void AutoExecuteCheckbox_Click(object sender, RoutedEventArgs e)
	{
		STautoexecute = !STautoexecute;
		((Control)AutoExeCheckbox).Background = (Brush)(object)GetBrush(STautoexecute);
		((UIElement)AEXcheck).Visibility = (Visibility)((!STautoexecute) ? 2 : 0);
		SaveSettings();
	}

	private void EggCheckbox_Click(object sender, RoutedEventArgs e)
	{
		egg = !egg;
		((Control)EggCheckbox).Background = (Brush)(object)GetBrush(egg);
		((UIElement)EGGcheck).Visibility = (Visibility)((!egg) ? 2 : 0);
		SaveSettings();
	}

	private void ResetSettingsButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		STalwaysontop = false;
		STautoinject = false;
		STautoexecute = false;
		egg = false;
		((Window)this).Topmost = false;
		SaveSettings();
		((Control)AlwaysOnTopCheckbox).Background = (Brush)new SolidColorBrush(Color.FromRgb((byte)27, (byte)27, (byte)27));
		((Control)AutoInjectCheckbox).Background = (Brush)new SolidColorBrush(Color.FromRgb((byte)27, (byte)27, (byte)27));
		((Control)AutoExeCheckbox).Background = (Brush)new SolidColorBrush(Color.FromRgb((byte)27, (byte)27, (byte)27));
		((Control)EggCheckbox).Background = (Brush)new SolidColorBrush(Color.FromRgb((byte)27, (byte)27, (byte)27));
		((UIElement)AOTcheck).Visibility = (Visibility)2;
		((UIElement)AINJcheck).Visibility = (Visibility)2;
		((UIElement)AEXcheck).Visibility = (Visibility)2;
		((UIElement)EGGcheck).Visibility = (Visibility)2;
	}

	private void DebugInfoButton_Click(object sender, RoutedEventArgs e)
	{
	}

	private void OpenMainFolderButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		OpenFileDialog val = new OpenFileDialog();
		string baseDirectory = AppContext.BaseDirectory;
		if (Directory.Exists(baseDirectory))
		{
			((CommonItemDialog)val).InitialDirectory = baseDirectory;
		}
		else
		{
			((CommonItemDialog)val).InitialDirectory = "C:\\";
		}
		((CommonDialog)val).ShowDialog();
	}

	[AsyncStateMachine(typeof(_003CSaveFileButton1_Click_003Ed__62))]
	private void SaveFileButton1_Click(object sender, RoutedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_003CSaveFileButton1_Click_003Ed__62 _003CSaveFileButton1_Click_003Ed__ = default(_003CSaveFileButton1_Click_003Ed__62);
		_003CSaveFileButton1_Click_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CSaveFileButton1_Click_003Ed__._003C_003E4__this = this;
		_003CSaveFileButton1_Click_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CSaveFileButton1_Click_003Ed__._003C_003Et__builder)).Start<_003CSaveFileButton1_Click_003Ed__62>(ref _003CSaveFileButton1_Click_003Ed__);
	}

	public static string Base64Encode(string plainText)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
	}

	private static string EncodeToBase64_UTF8(string input)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
	}

	[AsyncStateMachine(typeof(_003CExecuteButton1_Click_003Ed__65))]
	private void ExecuteButton1_Click(object sender, RoutedEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		_003CExecuteButton1_Click_003Ed__65 _003CExecuteButton1_Click_003Ed__ = default(_003CExecuteButton1_Click_003Ed__65);
		_003CExecuteButton1_Click_003Ed__._003C_003Et__builder = AsyncVoidMethodBuilder.Create();
		_003CExecuteButton1_Click_003Ed__._003C_003E4__this = this;
		_003CExecuteButton1_Click_003Ed__._003C_003E1__state = -1;
		((AsyncVoidMethodBuilder)(ref _003CExecuteButton1_Click_003Ed__._003C_003Et__builder)).Start<_003CExecuteButton1_Click_003Ed__65>(ref _003CExecuteButton1_Click_003Ed__);
	}

	private void BugreportButton_Click(object sender, RoutedEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if ((int)MessageBox.Show("Report bugs on our Discord server. Visit link?", "Visit", (MessageBoxButton)4, (MessageBoxImage)64) == 6)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "https://discord.gg/getvelocity",
				UseShellExecute = true
			});
		}
	}

	private UIElement CreateClientItem(string name, string status)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_012c: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		string name2 = name;
		Border val = new Border
		{
			Height = 50.0,
			Background = (Brush)((TypeConverter)new BrushConverter()).ConvertFromString("#FF252525"),
			CornerRadius = new CornerRadius(10.0),
			Margin = new Thickness(0.0, 0.0, 0.0, 10.0)
		};
		Grid val2 = new Grid();
		Button button = new Button
		{
			HorizontalAlignment = (HorizontalAlignment)2,
			Height = 20.0,
			VerticalAlignment = (VerticalAlignment)1,
			Width = 20.0,
			Background = (Brush)((TypeConverter)new BrushConverter()).ConvertFromString("#FF1B1B1B"),
			Foreground = (Brush)(object)Brushes.Transparent,
			Margin = new Thickness(0.0, 0.0, 10.0, 0.0),
			Template = (ControlTemplate)((FrameworkElement)this).FindResource((object)"RoundButton")
		};
		Label val3 = new Label
		{
			Content = name2,
			FontFamily = new FontFamily("Satoshi"),
			HorizontalAlignment = (HorizontalAlignment)0,
			VerticalAlignment = (VerticalAlignment)0,
			Foreground = (Brush)((TypeConverter)new BrushConverter()).ConvertFromString("#FF8C8C8C"),
			FontSize = 14.0,
			Margin = new Thickness(5.0, 5.0, 0.0, 0.0)
		};
		Label val4 = new Label
		{
			Name = "status",
			Content = status,
			FontFamily = new FontFamily("Satoshi"),
			HorizontalAlignment = (HorizontalAlignment)0,
			VerticalAlignment = (VerticalAlignment)2,
			Foreground = (Brush)((TypeConverter)new BrushConverter()).ConvertFromString("#FF8C8C8C"),
			FontSize = 11.0,
			Margin = new Thickness(5.0, 0.0, 0.0, 5.0)
		};
		((ButtonBase)button).Click += (RoutedEventHandler)delegate
		{
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			if (selected_clients.Contains(int.Parse(name2)))
			{
				((Control)button).Background = (Brush)((TypeConverter)new BrushConverter()).ConvertFromString("#FF1B1B1B");
				selected_clients.Remove(int.Parse(name2));
			}
			else
			{
				((Control)button).Background = (Brush)((TypeConverter)new BrushConverter()).ConvertFromString("#FF3C3C3C");
				selected_clients.Add(int.Parse(name2));
			}
		};
		((Panel)val2).Children.Add((UIElement)(object)button);
		((Panel)val2).Children.Add((UIElement)(object)val3);
		((Panel)val2).Children.Add((UIElement)(object)val4);
		((FrameworkElement)val).Name = "rbx_client_" + name2;
		((Decorator)val).Child = (UIElement)(object)val2;
		return (UIElement)val;
	}

	private bool IsPidRunning(int pid)
	{
		try
		{
			Process.GetProcessById(pid);
			return true;
		}
		catch (ArgumentException)
		{
			return false;
		}
	}

	private bool doesClientAlreadyExist(string pid)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		foreach (Border child in ((Panel)ClientListContainer).Children)
		{
			if (((FrameworkElement)child).Name == "rbx_client_" + pid)
			{
				return true;
			}
		}
		return false;
	}

	private void updateClients()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		foreach (Border child in ((Panel)ClientListContainer).Children)
		{
			Grid val2 = (Grid)((Decorator)child).Child;
			int num = int.Parse(((object)((FrameworkElement)child).Name.Split("rbx_client_", (StringSplitOptions)0)[1]).ToString());
			foreach (object child2 in ((Panel)val2).Children)
			{
				if (((MemberInfo)child2.GetType()).Name == "Label")
				{
					Label val3 = (Label)child2;
					if (((FrameworkElement)val3).Name == "status")
					{
						((ContentControl)val3).Content = (injected_pids.Contains(num) ? "Active" : "Inactive");
					}
				}
			}
		}
	}

	private void checkForClients()
	{
		Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
		foreach (Process val in processesByName)
		{
			if (!doesClientAlreadyExist(val.Id.ToString()))
			{
				((Panel)ClientListContainer).Children.Add(CreateClientItem(val.Id.ToString(), "Inactive"));
			}
		}
	}

	private void removeOldClients()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		foreach (Border child in ((Panel)ClientListContainer).Children)
		{
			Border val = child;
			string[] array = ((FrameworkElement)val).Name.Split("rbx_client_", (StringSplitOptions)0);
			try
			{
				int num = int.Parse(((object)array[1]).ToString());
				if (!IsPidRunning(num))
				{
					((Panel)ClientListContainer).Children.Remove((UIElement)(object)val);
					if (selected_clients.Contains(num))
					{
						selected_clients.Remove(num);
					}
					if (injected_pids.Contains(num))
					{
						injected_pids.Remove(num);
					}
				}
			}
			catch (ArgumentException)
			{
			}
		}
	}

	private void TabScroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (e.ExtentWidthChange != 0.0)
		{
			int num = (((int)TabScroll.ComputedHorizontalScrollBarVisibility == 0) ? 58 : 40);
			UIContainer.RowDefinitions[1].Height = new GridLength((double)num);
		}
	}

	private void InjectButton1_Click(object sender, RoutedEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		Process[] processesByName = Process.GetProcessesByName("RobloxPlayerBeta");
		if (processesByName.Length == 0)
		{
			MessageBox.Show("Launch Roblox First");
			return;
		}
		if (selected_clients.Count <= 0)
		{
			MessageBox.Show("You must select 1 or more clients to inject!");
			return;
		}
		Process[] array = processesByName;
		foreach (Process val in array)
		{
			try
			{
				File.WriteAllText(Path.GetDirectoryName(val.MainModule.FileName) + "\\Port.txt", openPortNumber.ToString());
			}
			catch
			{
			}
		}
		Enumerator<int> enumerator = selected_clients.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				int current = enumerator.Current;
				try
				{
					Process.Start(new ProcessStartInfo("Bin\\erto3e4rortoergn.exe")
					{
						CreateNoWindow = false,
						UseShellExecute = false,
						RedirectStandardError = false,
						RedirectStandardOutput = false
					});
					injected_pids.Add(current);
				}
				catch (global::System.Exception)
				{
				}
			}
		}
		finally
		{
			((global::System.IDisposable)enumerator).Dispose();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.3.0")]
	public void InitializeComponent()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri val = new Uri("/Velocity;component/mainwindow.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.3.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Expected O, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Expected O, but got Unknown
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Expected O, but got Unknown
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected O, but got Unknown
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Expected O, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Expected O, but got Unknown
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Expected O, but got Unknown
		//IL_05f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Expected O, but got Unknown
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_0612: Expected O, but got Unknown
		//IL_061f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0629: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Expected O, but got Unknown
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected O, but got Unknown
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Expected O, but got Unknown
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_0671: Expected O, but got Unknown
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Expected O, but got Unknown
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected O, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0701: Expected O, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Expected O, but got Unknown
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Expected O, but got Unknown
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Expected O, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected O, but got Unknown
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			((FrameworkElement)(MainWindow)target).Loaded += new RoutedEventHandler(Window_Loaded);
			((Window)(MainWindow)target).StateChanged += new EventHandler(Window_StateChanged);
			break;
		case 2:
			MainBorder = (Border)target;
			break;
		case 3:
			UIContainer = (Grid)target;
			break;
		case 4:
			CloseButton = (Button)target;
			((ButtonBase)CloseButton).Click += new RoutedEventHandler(CloseButton_Click);
			((UIElement)CloseButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 5:
			MaximizeButton = (Button)target;
			((ButtonBase)MaximizeButton).Click += new RoutedEventHandler(MaximizeButton_Click);
			((UIElement)MaximizeButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 6:
			MinimizeButton = (Button)target;
			((ButtonBase)MinimizeButton).Click += new RoutedEventHandler(MinimizeButton_Click);
			((UIElement)MinimizeButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 7:
			BugreportButton = (Button)target;
			((UIElement)BugreportButton).MouseRightButtonDown += new MouseButtonEventHandler(BugreportButton_ShowDevtools);
			((UIElement)BugreportButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)BugreportButton).Click += new RoutedEventHandler(BugreportButton_Click);
			break;
		case 8:
			SettingsButton = (Button)target;
			((ButtonBase)SettingsButton).Click += new RoutedEventHandler(SettingsButton_Click);
			((UIElement)SettingsButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 9:
			((UIElement)(Border)target).MouseDown += new MouseButtonEventHandler(TitleBar_MouseDown);
			break;
		case 10:
			Logo = (Image)target;
			break;
		case 11:
			PageStatus = (Label)target;
			break;
		case 12:
			ToolBar = (Border)target;
			break;
		case 13:
			SaveFileButton1 = (Button)target;
			((UIElement)SaveFileButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)SaveFileButton1).Click += new RoutedEventHandler(SaveFileButton1_Click);
			break;
		case 14:
			OpenFileButton1 = (Button)target;
			((UIElement)OpenFileButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)OpenFileButton1).Click += new RoutedEventHandler(OpenFileButton1_Click);
			break;
		case 15:
			ClearButton1 = (Button)target;
			((UIElement)ClearButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)ClearButton1).Click += new RoutedEventHandler(ClearButton1_Click);
			break;
		case 16:
			ExecuteButton1 = (Button)target;
			((UIElement)ExecuteButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)ExecuteButton1).Click += new RoutedEventHandler(ExecuteButton1_Click);
			break;
		case 17:
			MenuButton1 = (Button)target;
			((UIElement)MenuButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 18:
			ClientsButton1 = (Button)target;
			((UIElement)ClientsButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)ClientsButton1).Click += new RoutedEventHandler(ClientsButton1_Click);
			break;
		case 19:
			InjectButton1 = (Button)target;
			((UIElement)InjectButton1).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)InjectButton1).Click += new RoutedEventHandler(InjectButton1_Click);
			break;
		case 20:
			cefBrowser = (ChromiumWebBrowser)target;
			break;
		case 21:
			TabScroll = (ScrollViewer)target;
			TabScroll.ScrollChanged += new ScrollChangedEventHandler(TabScroll_ScrollChanged);
			break;
		case 22:
			TabContainer = (StackPanel)target;
			break;
		case 23:
			AddTabButton = (Button)target;
			((UIElement)AddTabButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)AddTabButton).Click += new RoutedEventHandler(AddTabButton_Click);
			break;
		case 24:
			SettingsBorder = (Border)target;
			break;
		case 25:
			AlwaysOnTopCheckbox = (Button)target;
			((UIElement)AlwaysOnTopCheckbox).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)AlwaysOnTopCheckbox).Click += new RoutedEventHandler(AlwaysOnTopCheckbox_Click);
			break;
		case 26:
			AOTcheck = (Image)target;
			break;
		case 27:
			AutoInjectCheckbox = (Button)target;
			((UIElement)AutoInjectCheckbox).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)AutoInjectCheckbox).Click += new RoutedEventHandler(AutoInjectCheckbox_Click);
			break;
		case 28:
			AINJcheck = (Image)target;
			break;
		case 29:
			AutoExeCheckbox = (Button)target;
			((UIElement)AutoExeCheckbox).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)AutoExeCheckbox).Click += new RoutedEventHandler(AutoExecuteCheckbox_Click);
			break;
		case 30:
			AEXcheck = (Image)target;
			break;
		case 31:
			EggCheckbox = (Button)target;
			((UIElement)EggCheckbox).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)EggCheckbox).Click += new RoutedEventHandler(EggCheckbox_Click);
			break;
		case 32:
			EGGcheck = (Image)target;
			break;
		case 33:
			((UIElement)(Button)target).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 34:
			((UIElement)(Button)target).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 35:
			OpenMainFolderButton = (Button)target;
			((UIElement)OpenMainFolderButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)OpenMainFolderButton).Click += new RoutedEventHandler(OpenMainFolderButton_Click);
			break;
		case 36:
			ResetSettingsButton = (Button)target;
			((UIElement)ResetSettingsButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)ResetSettingsButton).Click += new RoutedEventHandler(ResetSettingsButton_Click);
			break;
		case 37:
			DebugInfoButton = (Button)target;
			((UIElement)DebugInfoButton).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			((ButtonBase)DebugInfoButton).Click += new RoutedEventHandler(DebugInfoButton_Click);
			break;
		case 38:
			((UIElement)(Button)target).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 39:
			((UIElement)(Button)target).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 40:
			((UIElement)(Button)target).PreviewKeyDown += new KeyEventHandler(Button_KeyDown);
			break;
		case 41:
			SplashBackgroundOrSomethingIDontFuckingKnow = (Border)target;
			break;
		case 42:
			SplashLogo = (Image)target;
			break;
		case 43:
			ClientsList = (Border)target;
			break;
		case 44:
			ClientListContainer = (StackPanel)target;
			break;
		case 45:
			ClientsText = (Label)target;
			break;
		case 46:
			ClientsMenuLabel1 = (Label)target;
			break;
		case 47:
			ClientsMenuLabel2 = (Label)target;
			break;
		case 48:
			ClientsListCloseHitbox = (Border)target;
			((UIElement)ClientsListCloseHitbox).MouseDown += new MouseButtonEventHandler(ClientsListHitbox_Click);
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
