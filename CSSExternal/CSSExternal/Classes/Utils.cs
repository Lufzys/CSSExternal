using LFOverlay.Classes.Variables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LFOverlay.Classes
{
    class Utils
    {
        public static void SetDoubleBuffering(System.Windows.Forms.Control control, bool value)
        {
            System.Reflection.PropertyInfo controlProperty = typeof(System.Windows.Forms.Control)
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            controlProperty.SetValue(control, value, null);
        }

        public static Process ForegroundProcess()
        {
            uint processID = 0;
            IntPtr hWnd = WinAPI.GetForegroundWindow(); // Get foreground window handle
            uint threadID = WinAPI.GetWindowThreadProcessId(hWnd, out processID); // Get PID from window handle
            Process fgProc = Process.GetProcessById(Convert.ToInt32(processID)); // Get it as a C# obj.
            // NOTE: In some rare cases ProcessID will be NULL. Handle this how you want. 
            return fgProc;
        }

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                WinAPI.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

		public static bool GetWindowClientInternal(IntPtr hwnd, out Structs.RECT rect)
		{
			// calculates the window bounds based on the difference of the client and the window rect

			if (!WinAPI.GetWindowRect(hwnd, out rect)) return false;
			if (!WinAPI.GetClientRect(hwnd, out var clientRect)) return true;

			int clientWidth = clientRect.right - clientRect.left;
			int clientHeight = clientRect.bottom - clientRect.top;

			int windowWidth = rect.right - rect.left;
			int windowHeight = rect.bottom - rect.top;

			if (clientWidth == windowWidth && clientHeight == windowHeight) return true;

			if (clientWidth != windowWidth)
			{
				int difX = clientWidth > windowWidth ? clientWidth - windowWidth : windowWidth - clientWidth;
				difX /= 2;

				rect.right -= difX;
				rect.left += difX;

				if (clientHeight != windowHeight)
				{
					int difY = clientHeight > windowHeight ? clientHeight - windowHeight : windowHeight - clientHeight;

					rect.top += difY - difX;
					rect.bottom -= difX;
				}
			}
			else if (clientHeight != windowHeight)
			{
				int difY = clientHeight > windowHeight ? clientHeight - windowHeight : windowHeight - clientHeight;
				difY /= 2;

				rect.bottom -= difY;
				rect.top += difY;
			}

			return true;
		}

		public static bool IsKeyPushedDown(System.Windows.Forms.Keys vKey)
		{
			return 0 != (WinAPI.GetAsyncKeyState(vKey) & 0x8000);
		}

		public static void move_to(float x, float y, float smooth, int screenWidth, float screenHeight)
		{
			float center_x = screenWidth / 2;
			float center_y = screenHeight / 2;

			float target_x = 0f;
			float target_y = 0f;

			if (x != 0f)
			{
				if (x > center_x)
				{
					target_x = -(center_x - x);
					target_x /= smooth;
					if (target_x + center_x > center_x * 2f) target_x = 0f;
				}

				if (x < center_x)
				{
					target_x = x - center_x;
					target_x /= smooth;
					if (target_x + center_x < 0f) target_x = 0f;
				}
			}

			if (y != 0f)
			{
				if (y > center_y)
				{
					target_y = -(center_y - y);
					target_y /= smooth;
					if (target_y + center_y > center_y * 2f) target_y = 0f;
				}

				if (y < center_y)
				{
					target_y = y - center_y;
					target_y /= smooth;
					if (target_y + center_y < 0f) target_y = 0f;
				}
			}

			WinAPI.mouse_event(0x0001, (int)target_x, (int)target_y, 0, 0);
		}

		public static void SendCommand(string command)
        {
			IntPtr hWnd = WinAPI.FindWindowA("Valve001", string.Empty);
			if(hWnd != null)
            {
				IntPtr commandPtr = Marshal.StringToHGlobalUni(command);
				Structs.COPYDATASTRUCT m_cData;
				m_cData.cbData = command.Length + 1;
				m_cData.dwData = IntPtr.Zero;
				m_cData.lpData = commandPtr;

				IntPtr lparam = IntPtr.Zero;
				lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(m_cData));
				Marshal.StructureToPtr(m_cData, lparam, false);
				WinAPI.SendMessageA(hWnd, 0x004A, 0, (int)lparam);
				Marshal.FreeCoTaskMem(lparam);
				Marshal.FreeHGlobal(commandPtr);
			}
		}
	}
}
