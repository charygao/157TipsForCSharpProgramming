using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Tip118
{
    class Program
    {
        static System.Security.SecureString secureString = new System.Security.SecureString();

        static void Main(string[] args)
        {
            Method2();      //在此处打上断点
            Console.ReadKey();
        }

        static void Method1()
        {
            string str = "luminji";
            Console.WriteLine(str);
        }

        static void Method2()
        {
            secureString.AppendChar('l');
            secureString.AppendChar('u');
            secureString.AppendChar('m');
            secureString.AppendChar('i');
            secureString.AppendChar('n');
            secureString.AppendChar('j');
            secureString.AppendChar('i');
        }

        static void Method3()
        {
            secureString.AppendChar('l');
            secureString.AppendChar('u');
            secureString.AppendChar('m');
            secureString.AppendChar('i');
            secureString.AppendChar('n');
            secureString.AppendChar('j');
            secureString.AppendChar('i');
            IntPtr addr = Marshal.SecureStringToBSTR(secureString);
            string temp = Marshal.PtrToStringBSTR(addr);
            //使用该机密文本做一些事情
            ///=======开始清理内存
            //清理掉非托管代码中对应的内存的值
            Marshal.ZeroFreeBSTR(addr);
            //清理托管代码对应的内存的值（采用重写的方法）
            int id = GetProcessID();
            byte[] writeBytes = Encoding.Unicode.GetBytes("xxxxxx");
            IntPtr intPtr = Open(id);
            unsafe
            {
                fixed (char* c = temp)
                {
                    WriteMemory((IntPtr)c, writeBytes, writeBytes.Length);
                }
            }
            ///=======清理完毕
        }

        static PROCESS_INFORMATION processInfo = new PROCESS_INFORMATION();

        public static int GetProcessID()
        {
            Process p = Process.GetCurrentProcess();
            return p.Id;
        }

        public static IntPtr Open(int processId)
        {
            IntPtr hProcess = IntPtr.Zero;
            hProcess = ProcessAPIHelper.OpenProcess(ProcessAccessFlags.All, false, processId);
            if (hProcess == IntPtr.Zero)
                throw new Exception("OpenProcess失º¡ì败ã¨¹");
            processInfo.hProcess = hProcess;
            processInfo.dwProcessId = processId;
            return hProcess;
        }

        static int WriteMemory(IntPtr addressBase, byte[] writeBytes, int writeLength)
        {
            int reallyWriteLength = 0;
            if (!ProcessAPIHelper.WriteProcessMemory(processInfo.hProcess, addressBase, writeBytes, writeLength, out reallyWriteLength))
            {
                throw new Exception();
            }
            return reallyWriteLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [Flags]
        enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        static class ProcessAPIHelper
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out uint lpNumberOfBytesRead);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseHandle(IntPtr hObject);
        }

    }
}
