using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.Foundation;
using Windows.Win32;

namespace SiegeCharmSearcher.Shared {
    internal sealed class WindowsWrapper {
        internal static Process FindProcessOfNames(string[] names) {
            Process? foundProcess = null;
            foreach (string name in names) {
                Process[] processes = Process.GetProcessesByName(name);
                if (processes.Length > 0) {
                    foundProcess = processes[0];
                    break;
                }
            }

            if (foundProcess == null) {
                StringBuilder stringBuilder = new();
                for (int i = 0; i < names.Length; ++i) {
                    stringBuilder.Append(names[i]);
                    if (i < (names.Length - 1)) {
                        stringBuilder.Append(", ");
                    }
                }

                throw new ProcessNotFoundException($"Process of names {stringBuilder} has not been found.");
            }

            return foundProcess;
        }

        internal static Resolution GetResolution() {
            DEVMODEW devmode = default;
            devmode.dmSize = (ushort)(Marshal.SizeOf(devmode));
            if (!PInvoke.EnumDisplaySettings(null, ENUM_DISPLAY_SETTINGS_MODE.ENUM_CURRENT_SETTINGS, ref devmode)) {
                throw new ResolutionDetectionFailException();
            }
            return new Resolution(new Vector2Int((int)(devmode.dmPelsWidth), (int)(devmode.dmPelsHeight)), AspectRatio._169);
        }

        internal static void BringWindowUpFront(nint windowHandle) =>
            PInvoke.SetForegroundWindow((HWND)(windowHandle));
    }
}