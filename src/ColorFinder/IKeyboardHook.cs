using System;
using System.Windows.Forms;

namespace ColorFinder
{
    public interface IKeyboardHook : IDisposable
    {
        void RegisterHotKey(ModifierKeys modifier, Keys key);
        event EventHandler<KeyPressedEventArgs> KeyPressed;
    }
}