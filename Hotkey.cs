using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ScreenCapturer
{
    /// <summary>
    /// 热键类
    /// </summary>
    public class Hotkey : IMessageFilter
    {
        [DllImport("user32.dll")]
        public static extern UInt32 RegisterHotKey(IntPtr hWnd, UInt32 id, UInt32 fsModifiers, UInt32 vk);
        [DllImport("user32.dll")]
        public static extern UInt32 UnregisterHotKey(IntPtr hWnd, UInt32 id);
        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalAddAtom(String lpString);
        [DllImport("kernel32.dll")]
        public static extern UInt32 GlobalDeleteAtom(UInt32 nAtom);
        /// <summary>
        /// 热键触发事件
        /// </summary>
        public event EventHandler OnHits;
        public enum KeyFlags
        {
            MOD_ALT = 0x0001,
            MOD_CONTROL = 0x0002,
            MOD_NOREPEAT = 0x4000,
            MOD_SHIFT = 0x0004,
            MOD_WIN = 0x0008
        }
        /// <summary>
        /// Register ID
        /// </summary>
        private uint _KeyID = 0;

        public Keys Modifiers { get; set; }

        public Keys Key { get; set; }
        /// <summary>
        /// Form Handle
        /// </summary>
        public IntPtr Handle { get; set; }
        /// <summary>
        /// 启动热键注册接收
        /// </summary>
        public void Start()
        {
            if (_KeyID == 0)
            {
                RegisterHotkey(Modifiers, Key);
            }
        }
        /// <summary>
        /// 注销热键
        /// </summary>
        public void Stop()
        {
            UnregisterHotkeys();
            Handle = IntPtr.Zero;
        }
        private UInt32 getModifiersKeyValue(Keys modifiers)
        {
            UInt32 n = 0;
            if ((modifiers & Keys.Alt) != 0)
            {
                n |= (UInt32)KeyFlags.MOD_ALT;
            }
            if ((modifiers & Keys.Control) != 0)
            {
                n |= (UInt32)KeyFlags.MOD_CONTROL;
            }
            if ((modifiers & Keys.Shift) != 0)
            {
                n |= (UInt32)KeyFlags.MOD_SHIFT;
            }
            return n;
        }
        private int RegisterHotkey(Keys modifiers, Keys key)
        {
            Application.AddMessageFilter(this);
            _KeyID = GlobalAddAtom(System.Guid.NewGuid().ToString());
            RegisterHotKey(Handle, _KeyID, getModifiersKeyValue(modifiers), (UInt32)key);
            return (int)_KeyID;
        }
        private void UnregisterHotkeys()
        {
            Application.RemoveMessageFilter(this);
            UnregisterHotKey(Handle, _KeyID);
            GlobalDeleteAtom(_KeyID);
            _KeyID = 0;
        }
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x312)
            {
                OnHits?.Invoke(this, null);
            }
            return false;
        }
    }
}