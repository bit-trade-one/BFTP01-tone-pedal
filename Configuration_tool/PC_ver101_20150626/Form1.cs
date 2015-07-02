//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
//-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
/********************************************************************
 FileName:		Form1.cs
 Dependencies:	When compiled, needs .NET framework 2.0 redistributable to run.
 Hardware:		Need a free USB port to connect USB peripheral device
				programmed with appropriate Generic HID firmware.  VID and
				PID in firmware must match the VID and PID in this
				program.
 Compiler:  	Microsoft Visual C# 2005 Express Edition (or better)
 Company:		Microchip Technology, Inc.

 Software License Agreement:

 The software supplied herewith by Microchip Technology Incorporated
 (the 鼎ompany・ for its PICｮ Microcontroller is intended and
 supplied to you, the Company痴 customer, for use solely and
 exclusively with Microchip PIC Microcontroller products. The
 software is owned by the Company and/or its supplier, and is
 protected under applicable copyright laws. All rights are reserved.
 Any use in violation of the foregoing restrictions may subject the
 user to criminal sanctions under applicable laws, as well as to
 civil liability for the breach of the terms and conditions of this
 license.

 THIS SOFTWARE IS PROVIDED IN AN 鄭S IS・CONDITION. NO WARRANTIES,
 WHETHER EXPRESS, IMPLIED OR STATUTORY, INCLUDING, BUT NOT LIMITED
 TO, IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 PARTICULAR PURPOSE APPLY TO THIS SOFTWARE. THE COMPANY SHALL NOT,
 IN ANY CIRCUMSTANCES, BE LIABLE FOR SPECIAL, INCIDENTAL OR
 CONSEQUENTIAL DAMAGES, FOR ANY REASON WHATSOEVER.

********************************************************************
 File Description:

 Change History:
  Rev   Date         Description
  2.5a	07/17/2009	 Initial Release.  Ported from HID PnP Demo
                     application source, which was originally 
                     written in MSVC++ 2005 Express Edition.
********************************************************************
NOTE:	All user made code contained in this project is in the Form1.cs file.
		All other code and files were generated automatically by either the
		new project wizard, or by the development environment (ex: code is
		automatically generated if you create a new button on the form, and
		then double click on it, which creates a click event handler
		function).  User developed code (code not developed by the IDE) has
        been marked in "cut and paste blocks" to make it easier to identify.
********************************************************************/

//NOTE: In order for this program to "find" a USB device with a given VID and PID, 
//both the VID and PID in the USB device descriptor (in the USB firmware on the 
//microcontroller), as well as in this PC application source code, must match.
//To change the VID/PID in this PC application source code, scroll down to the 
//CheckIfPresentAndGetUSBDevicePath() function, and change the line that currently
//reads:

//   String DeviceIDToFind = "Vid_04d8&Pid_003f";


//NOTE 2: This C# program makes use of several functions in setupapi.dll and
//other Win32 DLLs.  However, one cannot call the functions directly in a 
//32-bit DLL if the project is built in "Any CPU" mode, when run on a 64-bit OS.
//When configured to build an "Any CPU" executable, the executable will "become"
//a 64-bit executable when run on a 64-bit OS.  On a 32-bit OS, it will run as 
//a 32-bit executable, and the pointer sizes and other aspects of this 
//application will be compatible with calling 32-bit DLLs.

//Therefore, on a 64-bit OS, this application will not work unless it is built in
//"x86" mode.  When built in this mode, the exectuable always runs in 32-bit mode
//even on a 64-bit OS.  This allows this application to make 32-bit DLL function 
//calls, when run on either a 32-bit or 64-bit OS.

//By default, on a new project, C# normally wants to build in "Any CPU" mode.  
//To switch to "x86" mode, open the "Configuration Manager" window.  In the 
//"Active solution platform:" drop down box, select "x86".  If this option does
//not appear, select: "<New...>" and then select the x86 option in the 
//"Type or select the new platform:" drop down box.  

//-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------



using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;


namespace HID_PnP_Demo
{
    public partial class Form1 : Form
    {
#if DEBUG
        internal const bool __DEBUG_FLAG__ = true;    // デバッグ時
#else
        internal const bool __DEBUG_FLAG__ = false;     // リリース時
#endif

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //Constant definitions from setupapi.h, which we aren't allowed to include directly since this is C#
        internal const uint DIGCF_PRESENT = 0x02;
        internal const uint DIGCF_DEVICEINTERFACE = 0x10;
        //Constants for CreateFile() and other file I/O functions
        internal const short FILE_ATTRIBUTE_NORMAL = 0x80;
        internal const short INVALID_HANDLE_VALUE = -1;
        internal const uint GENERIC_READ = 0x80000000;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint CREATE_NEW = 1;
        internal const uint CREATE_ALWAYS = 2;
        internal const uint OPEN_EXISTING = 3;
        internal const uint FILE_SHARE_READ = 0x00000001;
        internal const uint FILE_SHARE_WRITE = 0x00000002;
        //Constant definitions for certain WM_DEVICECHANGE messages
        internal const uint WM_DEVICECHANGE = 0x0219;
        internal const uint DBT_DEVICEARRIVAL = 0x8000;
        internal const uint DBT_DEVICEREMOVEPENDING = 0x8003;
        internal const uint DBT_DEVICEREMOVECOMPLETE = 0x8004;
        internal const uint DBT_CONFIGCHANGED = 0x0018;
        //Other constant definitions
        internal const uint DBT_DEVTYP_DEVICEINTERFACE = 0x05;
        internal const uint DEVICE_NOTIFY_WINDOW_HANDLE = 0x00;
        internal const uint ERROR_SUCCESS = 0x00;
        internal const uint ERROR_NO_MORE_ITEMS = 0x00000103;
        internal const uint SPDRP_HARDWAREID = 0x00000001;

        //Various structure definitions for structures that this code will be using
        internal struct SP_DEVICE_INTERFACE_DATA
        {
            internal uint cbSize;               //DWORD
            internal Guid InterfaceClassGuid;   //GUID
            internal uint Flags;                //DWORD
            internal uint Reserved;             //ULONG_PTR MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  
        }

        internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            internal uint cbSize;               //DWORD
            internal char[] DevicePath;         //TCHAR array of any size
        }
        
        internal struct SP_DEVINFO_DATA
        {
            internal uint cbSize;       //DWORD
            internal Guid ClassGuid;    //GUID
            internal uint DevInst;      //DWORD
            internal uint Reserved;     //ULONG_PTR  MSDN says ULONG_PTR is "typedef unsigned __int3264 ULONG_PTR;"  
        }

        internal struct DEV_BROADCAST_DEVICEINTERFACE
        {
            internal uint dbcc_size;            //DWORD
            internal uint dbcc_devicetype;      //DWORD
            internal uint dbcc_reserved;        //DWORD
            internal Guid dbcc_classguid;       //GUID
            internal char[] dbcc_name;          //TCHAR array
        }

        //DLL Imports.  Need these to access various C style unmanaged functions contained in their respective DLL files.
        //--------------------------------------------------------------------------------------------------------------
        //Returns a HDEVINFO type for a device information set.  We will need the 
        //HDEVINFO as in input parameter for calling many of the other SetupDixxx() functions.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr SetupDiGetClassDevs(
            ref Guid ClassGuid,     //LPGUID    Input: Need to supply the class GUID. 
            IntPtr Enumerator,      //PCTSTR    Input: Use NULL here, not important for our purposes
            IntPtr hwndParent,      //HWND      Input: Use NULL here, not important for our purposes
            uint Flags);            //DWORD     Input: Flags describing what kind of filtering to use.

	    //Gives us "PSP_DEVICE_INTERFACE_DATA" which contains the Interface specific GUID (different
	    //from class GUID).  We need the interface GUID to get the device path.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiEnumDeviceInterfaces(
            IntPtr DeviceInfoSet,           //Input: Give it the HDEVINFO we got from SetupDiGetClassDevs()
            IntPtr DeviceInfoData,          //Input (optional)
            ref Guid InterfaceClassGuid,    //Input 
            uint MemberIndex,               //Input: "Index" of the device you are interested in getting the path for.
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);    //Output: This function fills in an "SP_DEVICE_INTERFACE_DATA" structure.

        //SetupDiDestroyDeviceInfoList() frees up memory by destroying a DeviceInfoList
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiDestroyDeviceInfoList(
            IntPtr DeviceInfoSet);          //Input: Give it a handle to a device info list to deallocate from RAM.

        //SetupDiEnumDeviceInfo() fills in an "SP_DEVINFO_DATA" structure, which we need for SetupDiGetDeviceRegistryProperty()
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiEnumDeviceInfo(
            IntPtr DeviceInfoSet,
            uint MemberIndex,
            ref SP_DEVINFO_DATA DeviceInterfaceData);

        //SetupDiGetDeviceRegistryProperty() gives us the hardware ID, which we use to check to see if it has matching VID/PID
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceRegistryProperty(
            IntPtr DeviceInfoSet,
            ref SP_DEVINFO_DATA DeviceInfoData,
            uint Property,
            ref uint PropertyRegDataType,
            IntPtr PropertyBuffer,
            uint PropertyBufferSize,
            ref uint RequiredSize);

        //SetupDiGetDeviceInterfaceDetail() gives us a device path, which is needed before CreateFile() can be used.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,                    //Input: Pointer to an structure which defines the device interface.  
            IntPtr  DeviceInterfaceDetailData,      //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will receive the device path.
            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.
            ref uint RequiredSize,                  //Output (optional): The number of bytes needed to hold the entire struct 
            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure

        //Overload for SetupDiGetDeviceInterfaceDetail().  Need this one since we can't pass NULL pointers directly in C#.
        [DllImport("setupapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetupDiGetDeviceInterfaceDetail(
            IntPtr DeviceInfoSet,                   //Input: Wants HDEVINFO which can be obtained from SetupDiGetClassDevs()
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,               //Input: Pointer to an structure which defines the device interface.  
            IntPtr DeviceInterfaceDetailData,       //Output: Pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA structure, which will contain the device path.
            uint DeviceInterfaceDetailDataSize,     //Input: Number of bytes to retrieve.
            IntPtr RequiredSize,                    //Output (optional): Pointer to a DWORD to tell you the number of bytes needed to hold the entire struct 
            IntPtr DeviceInfoData);                 //Output (optional): Pointer to a SP_DEVINFO_DATA structure

        //Need this function for receiving all of the WM_DEVICECHANGE messages.  See MSDN documentation for
        //description of what this function does/how to use it. Note: name is remapped "RegisterDeviceNotificationUM" to
        //avoid possible build error conflicts.
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern IntPtr RegisterDeviceNotification(
            IntPtr hRecipient,
            IntPtr NotificationFilter,
            uint Flags);

        //Takes in a device path and opens a handle to the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern SafeFileHandle CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode, 
            IntPtr lpSecurityAttributes, 
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes, 
            IntPtr hTemplateFile);

        //Uses a handle (created with CreateFile()), and lets us write USB data to the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool WriteFile(
            SafeFileHandle hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            ref uint lpNumberOfBytesWritten,
            IntPtr lpOverlapped);

        //Uses a handle (created with CreateFile()), and lets us read USB data from the device.
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool ReadFile(
            SafeFileHandle hFile,
            IntPtr lpBuffer,
            uint nNumberOfBytesToRead,
            ref uint lpNumberOfBytesRead,
            IntPtr lpOverlapped);



	    //--------------- Global Varibles Section ------------------
	    //USB related variables that need to have wide scope.
	    bool AttachedState = false;						//Need to keep track of the USB device attachment status for proper plug and play operation.
	    bool AttachedButBroken = false;
        SafeFileHandle WriteHandleToUSBDevice = null;
        SafeFileHandle ReadHandleToUSBDevice = null;
        String DevicePath = null;   //Need the find the proper device path before you can open file handles.

        const int SETTING_NUM = 8;

	    //Variables used by the application/form updates.
        byte[] eeprom_data = new byte[64]{0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0,0,0,0,0,0,0,
                                          0,0,0,0};
        bool[] ChangeAssign = new bool[SETTING_NUM] { true, true, true, true, true, true, true, true };
        bool ConnectFirstTime = true;
        bool Changevalue_btn_pressed = false;

        const string c_APPLICATION_NAME = "Tone Pedal+ USB Configuration Tool";
        bool VersionReadReq = true;
        bool VersionReadComp = false;
        byte[] version_buff = new byte[64];

        bool DeviceDataReadReq = true;
        bool DeviceDataReadComp = false;
        bool DeviceDataWriteReq = false;
        bool DeviceDataWriteComp = false;
        bool DeviceDataResetReq = false;
        bool DeviceDataResetComp = false;
        bool DeviceDataWriteCompMsgReq = false;

        bool DeviceSoftResetReq = false;
        bool DeviceSoftResetComp = false;
        int device_soft_reset_command_counter = 0;          // ソフトリセットコマンド送信カウンター
        const int DEVICE_SOFT_RESET_COMMAND_SEND_NUM = 10;  // ソフトリセットコマンド送信回数

        ComboBox[] my_cmbbx_set_type;
        Label[] my_lbl_title;
        NumericUpDown[] my_mouse_x;
        NumericUpDown[] my_mouse_y;
        CheckBox[,] my_keyboard_modifier;
        TextBox[,] my_keyboard_key;
        Button[] my_keyboard_key_clr;
        NumericUpDown[] my_joypad_x;
        NumericUpDown[] my_joypad_y;

            
        public SetData my_set_data = new SetData();


        // セットタイプ
        string[] set_type_list = new string[] { "なし", "マウス 左クリック", "マウス 右クリック", "マウス ホイールクリック", "マウス ダブルクリック", "マウス 上下左右移動", "マウス ホイールスクロール", "キーボード 任意キー", "ジョイパッド 左 X-Y軸", "ジョイパッド 右 X-Y軸",
                                            "ジョイパッド ボタン1", "ジョイパッド ボタン2", "ジョイパッド ボタン3", "ジョイパッド ボタン4", "ジョイパッド ボタン5", "ジョイパッド ボタン6", "ジョイパッド ボタン7", "ジョイパッド ボタン8", "ジョイパッド ボタン9", "ジョイパッド ボタン10", "ジョイパッド ボタン11", "ジョイパッド ボタン12", "ジョイパッド ボタン13",
                                            "ジョイパッド ハットスイッチ上","ジョイパッド ハットスイッチ下","ジョイパッド ハットスイッチ左","ジョイパッド ハットスイッチ右"};
        //string[] device_type_disp = new string[] { "", "Mouse", "Keyboard", "Volume" };

        string[] keyboard_modifier_name = new string[] { "Ctrl L", "Shift L", "Alt L", "Ctrl R", "Shift R", "Alt R" };
        byte[] keyboard_modifier_bit = new byte[] { 0x01, 0x02, 0x04, 0x10, 0x20, 0x40 };
        // モディファイ対象キー [左CTRL,左SHIFT,左ALT,左WIN,右CTRL,右SHIFT,右ALT,右WIN]
        byte[,] keyborad_modifier_data = new byte[,] { { 0xE0, 0x01 }, { 0xE1, 0x02 }, { 0xE2, 0x04 }, { 0xE3, 0x08 }, { 0xE4, 0x10 }, { 0xE5, 0x20 }, { 0xE6, 0x40 }, { 0xE7, 0x80 }};

        bool b_eeprom_init_req = false;

        int[] Debug_Array = new int[15];    //DEBUG
        int[] Debug_Arr2 = new int[15] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


        //バーチャルキーコードとUSBキーコードの変換用配列
        byte[] VKtoUSBkey = new byte[256]{
            0x00,   //0
            0x00,   //1
            0x00,   //2
            0x00,   //3
            0x00,   //4
            0x00,   //5
            0x00,   //6
            0x00,   //7
            0x2A,   //8
            0x2B,   //9
            0x00,   //10
            0x00,   //11
            0x00,   //12
            0x28,   //13
            0x00,   //14
            0x00,   //15
            0xE1,   //16
            0xE0,   //17
            0xE2,   //18
            0x48,   //19
            0x39,   //20
            0x88,   //21
            0x00,   //22
            0x00,   //23
            0x00,   //24
            0x35,   //25
            0x00,   //26
            0x29,   //27
            0x8A,   //28
            0x8B,   //29
            0x00,   //30
            0x00,   //31
            0x2C,   //32
            0x4B,   //33
            0x4E,   //34
            0x4D,   //35
            0x4A,   //36
            0x50,   //37
            0x52,   //38
            0x4F,   //39
            0x51,   //40
            0x00,   //41
            0x00,   //42
            0x00,   //43
            0x46,   //44
            0x49,   //45
            0x4C,   //46
            0x00,   //47
            0x27,   //48
            0x1E,   //49
            0x1F,   //50
            0x20,   //51
            0x21,   //52
            0x22,   //53
            0x23,   //54
            0x24,   //55
            0x25,   //56
            0x26,   //57
            0x00,   //58
            0x00,   //59
            0x00,   //60
            0x00,   //61
            0x00,   //62
            0x00,   //63
            0x00,   //64
            0x04,   //65
            0x05,   //66
            0x06,   //67
            0x07,   //68
            0x08,   //69
            0x09,   //70
            0x0A,   //71
            0x0B,   //72
            0x0C,   //73
            0x0D,   //74
            0x0E,   //75
            0x0F,   //76
            0x10,   //77
            0x11,   //78
            0x12,   //79
            0x13,   //80
            0x14,   //81
            0x15,   //82
            0x16,   //83
            0x17,   //84
            0x18,   //85
            0x19,   //86
            0x1A,   //87
            0x1B,   //88
            0x1C,   //89
            0x1D,   //90
            0xE3,   //91
            0xE7,   //92
            0x65,   //93
            0x00,   //94
            0x00,   //95
            0x62,   //96
            0x59,   //97
            0x5A,   //98
            0x5B,   //99
            0x5C,   //100
            0x5D,   //101
            0x5E,   //102
            0x5F,   //103
            0x60,   //104
            0x61,   //105
            0x55,   //106
            0x57,   //107
            0x85,   //108
            0x56,   //109
            0x63,   //110
            0x54,   //111
            0x3A,   //112
            0x3B,   //113
            0x3C,   //114
            0x3D,   //115
            0x3E,   //116
            0x3F,   //117
            0x40,   //118
            0x41,   //119
            0x42,   //120
            0x43,   //121
            0x44,   //122
            0x45,   //123
            0x68,   //124
            0x69,   //125
            0x6A,   //126
            0x6B,   //127
            0x6C,   //128
            0x6D,   //129
            0x6E,   //130
            0x6F,   //131
            0x70,   //132
            0x71,   //133
            0x72,   //134
            0x73,   //135
            0x00,   //136
            0x00,   //137
            0x00,   //138
            0x00,   //139
            0x00,   //140
            0x00,   //141
            0x00,   //142
            0x00,   //143
            0x53,   //144
            0x47,   //145
            0x67,   //146
            0x00,   //147
            0x00,   //148
            0x00,   //149
            0x00,   //150
            0x00,   //151
            0x00,   //152
            0x00,   //153
            0x00,   //154
            0x00,   //155
            0x00,   //156
            0x00,   //157
            0x00,   //158
            0x00,   //159
            0xE1,   //160
            0xE5,   //161
            0xE0,   //162
            0xE4,   //163
            0xE2,   //164
            0xE6,   //165
            0x00,   //166
            0x00,   //167
            0x00,   //168
            0x00,   //169
            0x00,   //170
            0x00,   //171
            0x00,   //172
            0x00,   //173
            0x00,   //174
            0x00,   //175
            0x00,   //176
            0x00,   //177
            0x00,   //178
            0x00,   //179
            0x00,   //180
            0x00,   //181
            0x00,   //182
            0x00,   //183
            0x00,   //184
            0x00,   //185
            0x34,   //186
            0x33,   //187
            0x36,   //188
            0x2D,   //189
            0x37,   //190
            0x38,   //191
            0x2F,   //192
            0x00,   //193
            0x00,   //194
            0x00,   //195
            0x00,   //196
            0x00,   //197
            0x00,   //198
            0x00,   //199
            0x00,   //200
            0x00,   //201
            0x00,   //202
            0x00,   //203
            0x00,   //204
            0x00,   //205
            0x00,   //206
            0x00,   //207
            0x00,   //208
            0x00,   //209
            0x00,   //210
            0x00,   //211
            0x00,   //212
            0x00,   //213
            0x00,   //214
            0x00,   //215
            0x00,   //216
            0x00,   //217
            0x00,   //218
            0x30,   //219
            0x89,   //220
            0x32,   //221
            0x2E,   //222
            0x00,   //223
            0x00,   //224
            0x00,   //225
            0x87,   //226
            0x00,   //227
            0x00,   //228
            0x00,   //229
            0x00,   //230
            0x00,   //231
            0x00,   //232
            0x00,   //233
            0x00,   //234
            0x00,   //235
            0x00,   //236
            0x00,   //237
            0x00,   //238
            0x00,   //239
            0x39,   //240
            0x00,   //241
            0x39,   //242
            0x35,   //243
            0x35,   //244
            0x00,   //245
            0x00,   //246
            0x00,   //247
            0x00,   //248
            0x00,   //249
            0x00,   //250
            0x00,   //251
            0x00,   //252
            0x00,   //253
            0x00,   //254
            0x00,   //255
       };
#if false
        //USBキーコードの名称配列
        public string[] USB_KeyCode_Name = new string[256]{
            "",   //0
            "",   //1
            "",   //2
            "",   //3
            "Ａ",   //4
            "Ｂ",   //5
            "Ｃ",   //6
            "Ｄ",   //7
            "Ｅ",   //8
            "Ｆ",   //9
            "Ｇ",   //10
            "Ｈ",   //11
            "Ｉ",   //12
            "Ｊ",   //13
            "Ｋ",   //14
            "Ｌ",   //15
            "Ｍ",   //16
            "Ｎ",   //17
            "Ｏ",   //18
            "Ｐ",   //19
            "Ｑ",   //20
            "Ｒ",   //21
            "Ｓ",   //22
            "Ｔ",   //23
            "Ｕ",   //24
            "Ｖ",   //25
            "Ｗ",   //26
            "Ｘ",   //27
            "Ｙ",   //28
            "Ｚ",   //29
            "１",   //30
            "２",   //31
            "３",   //32
            "４",   //33
            "５",   //34
            "６",   //35
            "７",   //36
            "８",   //37
            "９",   //38
            "０",   //39
            "Ｅｎｔｅｒ",   //40
            "ＥＳＣ",   //41
            "ＢＳ",   //42
            "Ｔａｂ",   //43
            "Ｓｐａｃｅ",   //44
            "ー",   //45
            "＾",   //46
            "＠",   //47
            "［",   //48
            "",   //49
            "］",   //50
            "；",   //51
            "：",   //52
            "半角／全角",   //53
            "、",   //54
            "。",   //55
            "／",   //56
            "ＣａｐｓＬｏｃｋ",   //57
            "Ｆ１",   //58
            "Ｆ２",   //59
            "Ｆ３",   //60
            "Ｆ４",   //61
            "Ｆ５",   //62
            "Ｆ６",   //63
            "Ｆ７",   //64
            "Ｆ８",   //65
            "Ｆ９",   //66
            "Ｆ１０",   //67
            "Ｆ１１",   //68
            "Ｆ１２",   //69
            "ＰｒｉｎｔＳｃｒｅｅｎ",   //70
            "ＳｃｒｏｌｌＬｏｃｋ",   //71
            "Ｐａｕｓｅ",   //72
            "Ｉｎｓｅｒｔ",   //73
            "Ｈｏｍｅ",   //74
            "ＰａｇｅＵｐ",   //75
            "Ｄｅｌｅｔｅ",   //76
            "Ｅｎｄ",   //77
            "ＰａｇｅＤｏｗｎ",   //78
            "→",   //79
            "←",   //80
            "↓",   //81
            "↑",   //82
            "ＮｕｍＬｏｃｋ",   //83
            "Ｎｕｍ／",   //84
            "Ｎｕｍ＊",   //85
            "Ｎｕｍ－",   //86
            "Ｎｕｍ＋",   //87
            "ＮｕｍＥｎｔｅｒ",   //88
            "Ｎｕｍ１",   //89
            "Ｎｕｍ２",   //90
            "Ｎｕｍ３",   //91
            "Ｎｕｍ４",   //92
            "Ｎｕｍ５",   //93
            "Ｎｕｍ６",   //94
            "Ｎｕｍ７",   //95
            "Ｎｕｍ８",   //96
            "Ｎｕｍ９",   //97
            "Ｎｕｍ０",   //98
            "Ｎｕｍ．",   //99
            "",   //100
            "Ｍｅｎｕ",   //101
            "",   //102
            "",   //103
            "",   //104
            "",   //105
            "",   //106
            "",   //107
            "",   //108
            "",   //109
            "",   //110
            "",   //111
            "",   //112
            "",   //113
            "",   //114
            "",   //115
            "",   //116
            "",   //117
            "",   //118
            "",   //119
            "",   //120
            "",   //121
            "",   //122
            "",   //123
            "",   //124
            "",   //125
            "",   //126
            "",   //127
            "",   //128
            "",   //129
            "",   //130
            "",   //131
            "",   //132
            "",   //133
            "",   //134
            "ＢａｃｋＳｌａｓｈ",   //135
            "カナ／ひら",   //136
            "￥",   //137
            "変換",   //138
            "無変換",   //139
            "",   //140
            "",   //141
            "",   //142
            "",   //143
            "",   //144
            "",   //145
            "",   //146
            "",   //147
            "",   //148
            "",   //149
            "",   //150
            "",   //151
            "",   //152
            "",   //153
            "",   //154
            "",   //155
            "",   //156
            "",   //157
            "",   //158
            "",   //159
            "",   //160
            "",   //161
            "",   //162
            "",   //163
            "",   //164
            "",   //165
            "",   //166
            "",   //167
            "",   //168
            "",   //169
            "",   //170
            "",   //171
            "",   //172
            "",   //173
            "",   //174
            "",   //175
            "",   //176
            "",   //177
            "",   //178
            "",   //179
            "",   //180
            "",   //181
            "",   //182
            "",   //183
            "",   //184
            "",   //185
            "",   //186
            "",   //187
            "",   //188
            "",   //189
            "",   //190
            "",   //191
            "",   //192
            "",   //193
            "",   //194
            "",   //195
            "",   //196
            "",   //197
            "",   //198
            "",   //199
            "",   //200
            "",   //201
            "",   //202
            "",   //203
            "",   //204
            "",   //205
            "",   //206
            "",   //207
            "",   //208
            "",   //209
            "",   //210
            "",   //211
            "",   //212
            "",   //213
            "",   //214
            "",   //215
            "",   //216
            "",   //217
            "",   //218
            "",   //219
            "",   //220
            "",   //221
            "",   //222
            "",   //223
            "ＬｅｆｔＣｔｒｌ",   //224
            "ＬｅｆｔＳｈｉｆｔ",   //225
            "ＬｅｆｔＡｌｔ",   //226
            "ＬｅｆｔＷｉｎ",   //227
            "ＲｉｇｈｔＣｔｒｌ",   //228
            "ＲｉｇｈｔＳｈｉｆｔ",   //229
            "ＲｉｇｈｔＡｌｔ",   //230
            "ＲｉｇｈｔＷｉｎ",   //231
            "",   //232
            "",   //233
            "",   //234
            "",   //235
            "",   //236
            "",   //237
            "",   //238
            "",   //239
            "",   //240
            "",   //241
            "",   //242
            "",   //243
            "",   //244
            "",   //245
            "",   //246
            "",   //247
            "",   //248
            "",   //249
            "",   //250
            "",   //251
            "",   //252
            "",   //253
            "",   //254
            "",   //255
       };
#endif
#if true
        //USBキーコードの名称配列
        public string[] USB_KeyCode_Name = new string[256]{
            "",   //0
            "",   //1
            "",   //2
            "",   //3
            "A",   //4
            "B",   //5
            "C",   //6
            "D",   //7
            "E",   //8
            "F",   //9
            "G",   //10
            "H",   //11
            "I",   //12
            "J",   //13
            "K",   //14
            "L",   //15
            "M",   //16
            "N",   //17
            "O",   //18
            "P",   //19
            "Q",   //20
            "R",   //21
            "S",   //22
            "T",   //23
            "U",   //24
            "V",   //25
            "W",   //26
            "X",   //27
            "Y",   //28
            "Z",   //29
            "1",   //30
            "2",   //31
            "3",   //32
            "4",   //33
            "5",   //34
            "6",   //35
            "7",   //36
            "8",   //37
            "9",   //38
            "0",   //39
            "Enter",   //40
            "ESC",   //41
            "BS",   //42
            "Tab",   //43
            "Space",   //44
            "-",   //45
            "^",   //46
            "@",   //47
            "[",   //48
            "",   //49
            "]",   //50
            ";",   //51
            ":",   //52
            "ZenHan",   //53
            ",",   //54
            ".",   //55
            "/",   //56
            "CapsLK",   //57
            "F1",   //58
            "F2",   //59
            "F3",   //60
            "F4",   //61
            "F5",   //62
            "F6",   //63
            "F7",   //64
            "F8",   //65
            "F9",   //66
            "F10",   //67
            "F11",   //68
            "F12",   //69
            "PrtSC",   //70
            "ScLK",   //71
            "Pause",   //72
            "Insert",   //73
            "Home",   //74
            "pgUp",   //75
            "Delete",   //76
            "End",   //77
            "pgDown",   //78
            "→",   //79
            "←",   //80
            "↓",   //81
            "↑",   //82
            "NumLK",   //83
            "Num/",   //84
            "Num*",   //85
            "Num-",   //86
            "Num+",   //87
            "NumENT",   //88
            "Num1",   //89
            "Num2",   //90
            "Num3",   //91
            "Num4",   //92
            "Num5",   //93
            "Num6",   //94
            "Num7",   //95
            "Num8",   //96
            "Num9",   //97
            "Num0",   //98
            "Num.",   //99
            "",   //100
            "Menu",   //101
            "",   //102
            "",   //103
            "",   //104
            "",   //105
            "",   //106
            "",   //107
            "",   //108
            "",   //109
            "",   //110
            "",   //111
            "",   //112
            "",   //113
            "",   //114
            "",   //115
            "",   //116
            "",   //117
            "",   //118
            "",   //119
            "",   //120
            "",   //121
            "",   //122
            "",   //123
            "",   //124
            "",   //125
            "",   //126
            "",   //127
            "",   //128
            "",   //129
            "",   //130
            "",   //131
            "",   //132
            "",   //133
            "",   //134
            "BackSL",   //135
            "k/Hira",   //136
            "￥",   //137
            "変換",   //138
            "無変換",   //139
            "",   //140
            "",   //141
            "",   //142
            "",   //143
            "",   //144
            "",   //145
            "",   //146
            "",   //147
            "",   //148
            "",   //149
            "",   //150
            "",   //151
            "",   //152
            "",   //153
            "",   //154
            "",   //155
            "",   //156
            "",   //157
            "",   //158
            "",   //159
            "",   //160
            "",   //161
            "",   //162
            "",   //163
            "",   //164
            "",   //165
            "",   //166
            "",   //167
            "",   //168
            "",   //169
            "",   //170
            "",   //171
            "",   //172
            "",   //173
            "",   //174
            "",   //175
            "",   //176
            "",   //177
            "",   //178
            "",   //179
            "",   //180
            "",   //181
            "",   //182
            "",   //183
            "",   //184
            "",   //185
            "",   //186
            "",   //187
            "",   //188
            "",   //189
            "",   //190
            "",   //191
            "",   //192
            "",   //193
            "",   //194
            "",   //195
            "",   //196
            "",   //197
            "",   //198
            "",   //199
            "",   //200
            "",   //201
            "",   //202
            "",   //203
            "",   //204
            "",   //205
            "",   //206
            "",   //207
            "",   //208
            "",   //209
            "",   //210
            "",   //211
            "",   //212
            "",   //213
            "",   //214
            "",   //215
            "",   //216
            "",   //217
            "",   //218
            "",   //219
            "",   //220
            "",   //221
            "",   //222
            "",   //223
            "Ctrl L",   //224
            "Shift L",   //225
            "Alt L",   //226
            "Win L",   //227
            "Ctrl R",   //228
            "Shift R",   //229
            "Alt R",   //230
            "Win R",   //231
            "",   //232
            "",   //233
            "",   //234
            "",   //235
            "",   //236
            "",   //237
            "",   //238
            "",   //239
            "",   //240
            "",   //241
            "",   //242
            "",   //243
            "",   //244
            "",   //245
            "",   //246
            "",   //247
            "",   //248
            "",   //249
            "",   //250
            "",   //251
            "",   //252
            "",   //253
            "",   //254
            "",   //255
       };
#endif


        //Globally Unique Identifier (GUID) for HID class devices.  Windows uses GUIDs to identify things.
        Guid InterfaceClassGuid = new Guid(0x4d1e55b2, 0xf16f, 0x11cf, 0x88, 0xcb, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30); 
	    //--------------- End of Global Varibles ------------------

        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //Need to check "Allow unsafe code" checkbox in build properties to use unsafe keyword.  Unsafe is needed to
        //properly interact with the unmanged C++ style APIs used to find and connect with the USB device.
        public unsafe Form1()
        {
            InitializeComponent();

            if (__DEBUG_FLAG__ == false)
            {
                // リリース時の画面サイズ
                this.Size = new System.Drawing.Size(888, 517);

                groupBox1.Visible = false;
                btn_soft_reset.Visible = false;
                btn_eeprom_init.Visible = false;
            }
            lbl_FW_Version.Location = new System.Drawing.Point(499, 472);
            StatusBox_lbl.Location = new System.Drawing.Point(756, 472);
            Status_NC_pb.Location = new System.Drawing.Point(843, 474);
            Status_C_pb.Location = new System.Drawing.Point(843, 474);

            //自分自身のバージョン情報を取得する
            System.Diagnostics.FileVersionInfo fver = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.Text += fver.FileMajorPart.ToString() + "." + fver.FileMinorPart.ToString() + "." + fver.FileBuildPart.ToString();
            //this.Text += fver.FileVersion;

            my_cmbbx_set_type = new ComboBox[] { cmbbx_Set_01, cmbbx_Set_02, cmbbx_Set_03, cmbbx_Set_04, cmbbx_Set_05, cmbbx_Set_06, cmbbx_Set_07, cmbbx_Set_08 };
            my_lbl_title = new Label[] { lbl_title_01, lbl_title_02, lbl_title_03, lbl_title_04, lbl_title_05, lbl_title_06, lbl_title_07, lbl_title_08};
            my_mouse_x = new NumericUpDown[] { nud_Set_Val_01, nud_Set_Val_03, nud_Set_Val_05, nud_Set_Val_07, nud_Set_Val_09, nud_Set_Val_11, nud_Set_Val_13, nud_Set_Val_15 };
            my_mouse_y = new NumericUpDown[] { nud_Set_Val_02, nud_Set_Val_04, nud_Set_Val_06, nud_Set_Val_08, nud_Set_Val_10, nud_Set_Val_12, nud_Set_Val_14, nud_Set_Val_16 };
            my_keyboard_modifier = new CheckBox[,] {{chkbx_key_modifier_01,chkbx_key_modifier_02,chkbx_key_modifier_03,chkbx_key_modifier_04,chkbx_key_modifier_05,chkbx_key_modifier_06},
                                                    {chkbx_key_modifier_07,chkbx_key_modifier_08,chkbx_key_modifier_09,chkbx_key_modifier_10,chkbx_key_modifier_11,chkbx_key_modifier_12},
                                                    {chkbx_key_modifier_13,chkbx_key_modifier_14,chkbx_key_modifier_15,chkbx_key_modifier_16,chkbx_key_modifier_17,chkbx_key_modifier_18},
                                                    {chkbx_key_modifier_19,chkbx_key_modifier_20,chkbx_key_modifier_21,chkbx_key_modifier_22,chkbx_key_modifier_23,chkbx_key_modifier_24},
                                                    {chkbx_key_modifier_25,chkbx_key_modifier_26,chkbx_key_modifier_27,chkbx_key_modifier_28,chkbx_key_modifier_29,chkbx_key_modifier_30},
                                                    {chkbx_key_modifier_31,chkbx_key_modifier_32,chkbx_key_modifier_33,chkbx_key_modifier_34,chkbx_key_modifier_35,chkbx_key_modifier_36},
                                                    {chkbx_key_modifier_37,chkbx_key_modifier_38,chkbx_key_modifier_39,chkbx_key_modifier_40,chkbx_key_modifier_41,chkbx_key_modifier_42},
                                                    {chkbx_key_modifier_43,chkbx_key_modifier_44,chkbx_key_modifier_45,chkbx_key_modifier_46,chkbx_key_modifier_47,chkbx_key_modifier_48}};
            my_keyboard_key = new TextBox[,] { { txtbx_KB_Val_01, txtbx_KB_Val_02, txtbx_KB_Val_03 }, { txtbx_KB_Val_04, txtbx_KB_Val_05, txtbx_KB_Val_06 },
                                                { txtbx_KB_Val_07, txtbx_KB_Val_08, txtbx_KB_Val_09 }, { txtbx_KB_Val_10, txtbx_KB_Val_11, txtbx_KB_Val_12 },
                                                { txtbx_KB_Val_13, txtbx_KB_Val_14, txtbx_KB_Val_15 }, { txtbx_KB_Val_16, txtbx_KB_Val_17, txtbx_KB_Val_18 },
                                                { txtbx_KB_Val_19, txtbx_KB_Val_20, txtbx_KB_Val_21 }, { txtbx_KB_Val_22, txtbx_KB_Val_23, txtbx_KB_Val_24 }};
            my_keyboard_key_clr = new Button[] { btn_key_clr_01, btn_key_clr_02, btn_key_clr_03, btn_key_clr_04, btn_key_clr_05, btn_key_clr_06, btn_key_clr_07, btn_key_clr_08 };
            my_joypad_x = new NumericUpDown[] { nud_Set_Val_01, nud_Set_Val_03, nud_Set_Val_05, nud_Set_Val_07, nud_Set_Val_09, nud_Set_Val_11, nud_Set_Val_13, nud_Set_Val_15 };
            my_joypad_y = new NumericUpDown[] { nud_Set_Val_02, nud_Set_Val_04, nud_Set_Val_06, nud_Set_Val_08, nud_Set_Val_10, nud_Set_Val_12, nud_Set_Val_14, nud_Set_Val_16 };
            //for (int fi = 0; fi < Constants.IR_DATA_REC_NUM; fi++)
            //{
            //    my_select_button[fi].TabIndex = tmp_tabidx++;
            //    my_select_button[fi].Tag = fi;
            //    my_select_button[fi].Text = string.Format("No.{0:00}", fi + 1);
            //    my_set_data_textbox[fi].TabIndex = tmp_tabidx++;
            //    my_set_data_textbox[fi].Tag = fi;
            //    my_set_data_textbox[fi].TabStop = false;
            //    my_memo_textbox[fi].TabIndex = tmp_tabidx++;
            //    my_memo_textbox[fi].Tag = fi;
            //    my_memo_textbox[fi].TabStop = false;
            //}
            // 設定タイプ選択肢設定
            for (int fi = 0; fi < my_cmbbx_set_type.Length; fi++)
            {
                my_cmbbx_set_type[fi].Items.AddRange(set_type_list);
                my_cmbbx_set_type[fi].Tag = fi;
                my_cmbbx_set_type[fi].SelectedIndex = 0;
                my_cmbbx_set_type[fi].Parent = BackGround_pb;
            }
            // label
            for (int fi = 0; fi < my_lbl_title.Length; fi++)
            {
                my_lbl_title[fi].Parent = BackGround_pb;
            }
            // Mouse
            for (int fi = 0; fi < my_mouse_x.Length; fi++)
            {
                my_mouse_x[fi].Minimum = -127;
                my_mouse_x[fi].Maximum = 128;
                my_mouse_x[fi].Tag = fi;
                my_mouse_x[fi].Parent = BackGround_pb;
            }
            for (int fi = 0; fi < my_mouse_y.Length; fi++)
            {
                my_mouse_y[fi].Minimum = -127;
                my_mouse_y[fi].Maximum = 128;
                my_mouse_y[fi].Tag = fi;
                my_mouse_y[fi].Parent = BackGround_pb;
            }
            // Keyboard
            for (int fi = 0; fi < my_keyboard_modifier.GetLength(0); fi++)
            {
                for (int fj = 0; fj < my_keyboard_modifier.GetLength(1); fj++)
                {
                    my_keyboard_modifier[fi, fj].Text = keyboard_modifier_name[fj];
                    my_keyboard_modifier[fi, fj].Tag = (fi * my_keyboard_modifier.GetLength(1)) + fj;
                    my_keyboard_modifier[fi, fj].Parent = BackGround_pb;
                }
            }
            for (int fi = 0; fi < my_keyboard_key.GetLength(0); fi++ )
            {
                for (int fj = 0; fj < my_keyboard_key.GetLength(1); fj++)
                {
                    my_keyboard_key[fi, fj].Text = "";
                    my_keyboard_key[fi, fj].Tag = (fi * my_keyboard_key.GetLength(1)) + fj;
                    my_keyboard_key[fi, fj].Parent = BackGround_pb;
                }
            }
            for (int fi = 0; fi < my_keyboard_key_clr.GetLength(0); fi++)
            {
                my_keyboard_key_clr[fi].Tag = fi;
                my_keyboard_key_clr[fi].Parent = BackGround_pb;
            }
            // Joypad
            for (int fi = 0; fi < my_joypad_x.Length; fi++)
            {
                my_joypad_x[fi].Minimum = -127;
                my_joypad_x[fi].Maximum = 128;
                my_joypad_x[fi].Tag = fi;
                my_joypad_x[fi].Parent = BackGround_pb;
            }
            for (int fi = 0; fi < my_mouse_y.Length; fi++)
            {
                my_joypad_y[fi].Minimum = -127;
                my_joypad_y[fi].Maximum = 128;
                my_joypad_y[fi].Tag = fi;
                my_joypad_y[fi].Parent = BackGround_pb;
            }

            // 透過のための親設定
            lbl_FW_Version.Parent = BackGround_pb;
            StatusBox_lbl.Parent = BackGround_pb;
            Status_NC_pb.Parent = BackGround_pb;
            Status_C_pb.Parent = BackGround_pb;


            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
			//Additional constructor code

            //Register for WM_DEVICECHANGE notifications.  This code uses these messages to detect plug and play connection/disconnection events for USB devices
            DEV_BROADCAST_DEVICEINTERFACE DeviceBroadcastHeader = new DEV_BROADCAST_DEVICEINTERFACE();
            DeviceBroadcastHeader.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
            DeviceBroadcastHeader.dbcc_size = (uint)Marshal.SizeOf(DeviceBroadcastHeader);
            DeviceBroadcastHeader.dbcc_reserved = 0;	//Reserved says not to use...
            DeviceBroadcastHeader.dbcc_classguid = InterfaceClassGuid;

            //Need to get the address of the DeviceBroadcastHeader to call RegisterDeviceNotification(), but
            //can't use "&DeviceBroadcastHeader".  Instead, using a roundabout means to get the address by 
            //making a duplicate copy using Marshal.StructureToPtr().
            IntPtr pDeviceBroadcastHeader = IntPtr.Zero;  //Make a pointer.
            pDeviceBroadcastHeader = Marshal.AllocHGlobal(Marshal.SizeOf(DeviceBroadcastHeader)); //allocate memory for a new DEV_BROADCAST_DEVICEINTERFACE structure, and return the address 
            Marshal.StructureToPtr(DeviceBroadcastHeader, pDeviceBroadcastHeader, false);  //Copies the DeviceBroadcastHeader structure into the memory already allocated at DeviceBroadcastHeaderWithPointer
            RegisterDeviceNotification(this.Handle, pDeviceBroadcastHeader, DEVICE_NOTIFY_WINDOW_HANDLE);
 

			//Now make an initial attempt to find the USB device, if it was already connected to the PC and enumerated prior to launching the application.
			//If it is connected and present, we should open read and write handles to the device so we can communicate with it later.
			//If it was not connected, we will have to wait until the user plugs the device in, and the WM_DEVICECHANGE callback function can process
			//the message and again search for the device.
			if(CheckIfPresentAndGetUSBDevicePath())	//Check and make sure at least one device with matching VID/PID is attached
			{
				uint ErrorStatusWrite;
				uint ErrorStatusRead;


				//We now have the proper device path, and we can finally open read and write handles to the device.
                WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();
                ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                ErrorStatusRead = (uint)Marshal.GetLastWin32Error();

				if((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))
				{
					AttachedState = true;		//Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it
					AttachedButBroken = false;
                    StatusBox_lbl.Text = "デバイス検出済";
				}
				else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...
				{
					AttachedState = false;		//Let the rest of this application known not to read/write to the device.
					AttachedButBroken = true;	//Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes
					if(ErrorStatusWrite == ERROR_SUCCESS)
						WriteHandleToUSBDevice.Close();
					if(ErrorStatusRead == ERROR_SUCCESS)
						ReadHandleToUSBDevice.Close();
				}
			}
			else	//Device must not be connected (or not programmed with correct firmware)
			{
				AttachedState = false;
				AttachedButBroken = false;
			}

            if (AttachedState == true)
            {
                StatusBox_lbl.Text = "デバイス検出済";
            }
            else
            {
                StatusBox_lbl.Text = "デバイス未検出";
            }

			ReadWriteThread.RunWorkerAsync();	//Recommend performing USB read/write operations in a separate thread.  Otherwise,
												//the Read/Write operations are effectively blocking functions and can lock up the
												//user interface if the I/O operations take a long time to complete.

            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //FUNCTION:	CheckIfPresentAndGetUSBDevicePath()
        //PURPOSE:	Check if a USB device is currently plugged in with a matching VID and PID
        //INPUT:	Uses globally declared String DevicePath, globally declared GUID, and the MY_DEVICE_ID constant.
        //OUTPUT:	Returns BOOL.  TRUE when device with matching VID/PID found.  FALSE if device with VID/PID could not be found.
        //			When returns TRUE, the globally accessable "DetailedInterfaceDataStructure" will contain the device path
        //			to the USB device with the matching VID/PID.

        bool CheckIfPresentAndGetUSBDevicePath()
        {
		    /* 
		    Before we can "connect" our application to our USB embedded device, we must first find the device.
		    A USB bus can have many devices simultaneously connected, so somehow we have to find our device only.
		    This is done with the Vendor ID (VID) and Product ID (PID).  Each USB product line should have
		    a unique combination of VID and PID.  

		    Microsoft has created a number of functions which are useful for finding plug and play devices.  Documentation
		    for each function used can be found in the MSDN library.  We will be using the following functions (unmanaged C functions):

		    SetupDiGetClassDevs()					//provided by setupapi.dll, which comes with Windows
		    SetupDiEnumDeviceInterfaces()			//provided by setupapi.dll, which comes with Windows
		    GetLastError()							//provided by kernel32.dll, which comes with Windows
		    SetupDiDestroyDeviceInfoList()			//provided by setupapi.dll, which comes with Windows
		    SetupDiGetDeviceInterfaceDetail()		//provided by setupapi.dll, which comes with Windows
		    SetupDiGetDeviceRegistryProperty()		//provided by setupapi.dll, which comes with Windows
		    CreateFile()							//provided by kernel32.dll, which comes with Windows

            In order to call these unmanaged functions, the Marshal class is very useful.
             
		    We will also be using the following unusual data types and structures.  Documentation can also be found in
		    the MSDN library:

		    PSP_DEVICE_INTERFACE_DATA
		    PSP_DEVICE_INTERFACE_DETAIL_DATA
		    SP_DEVINFO_DATA
		    HDEVINFO
		    HANDLE
		    GUID

		    The ultimate objective of the following code is to get the device path, which will be used elsewhere for getting
		    read and write handles to the USB device.  Once the read/write handles are opened, only then can this
		    PC application begin reading/writing to the USB device using the WriteFile() and ReadFile() functions.

		    Getting the device path is a multi-step round about process, which requires calling several of the
		    SetupDixxx() functions provided by setupapi.dll.
		    */

            try
            {
		        IntPtr DeviceInfoTable = IntPtr.Zero;
		        SP_DEVICE_INTERFACE_DATA InterfaceDataStructure = new SP_DEVICE_INTERFACE_DATA();
                SP_DEVICE_INTERFACE_DETAIL_DATA DetailedInterfaceDataStructure = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                SP_DEVINFO_DATA DevInfoData = new SP_DEVINFO_DATA();

		        uint InterfaceIndex = 0;
		        uint dwRegType = 0;
		        uint dwRegSize = 0;
                uint dwRegSize2 = 0;
		        uint StructureSize = 0;
		        IntPtr PropertyValueBuffer = IntPtr.Zero;
		        bool MatchFound = false;
                bool MatchFound2 = false;
                uint ErrorStatus;
		        uint LoopCounter = 0;

                //Use the formatting: "Vid_xxxx&Pid_xxxx" where xxxx is a 16-bit hexadecimal number.
                //Make sure the value appearing in the parathesis matches the USB device descriptor
                //of the device that this aplication is intending to find.
                String DeviceIDToFind = "Vid_22ea&Pid_003F";
                String DeviceIDToFind2 = "Mi_03";


		        //First populate a list of plugged in devices (by specifying "DIGCF_PRESENT"), which are of the specified class GUID. 
		        DeviceInfoTable = SetupDiGetClassDevs(ref InterfaceClassGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);

                if(DeviceInfoTable != IntPtr.Zero)
                {
		            //Now look through the list we just populated.  We are trying to see if any of them match our device. 
		            while(true)
		            {
                        InterfaceDataStructure.cbSize = (uint)Marshal.SizeOf(InterfaceDataStructure);
			            if(SetupDiEnumDeviceInterfaces(DeviceInfoTable, IntPtr.Zero, ref InterfaceClassGuid, InterfaceIndex, ref InterfaceDataStructure))
			            {
                            ErrorStatus = (uint)Marshal.GetLastWin32Error();
                            if (ErrorStatus == ERROR_NO_MORE_ITEMS)	//Did we reach the end of the list of matching devices in the DeviceInfoTable?
				            {	//Cound not find the device.  Must not have been attached.
					            SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
					            return false;		
				            }
			            }
			            else	//Else some other kind of unknown error ocurred...
			            {
                            ErrorStatus = (uint)Marshal.GetLastWin32Error();
				            SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
				            return false;	
			            }

			            //Now retrieve the hardware ID from the registry.  The hardware ID contains the VID and PID, which we will then 
			            //check to see if it is the correct device or not.

			            //Initialize an appropriate SP_DEVINFO_DATA structure.  We need this structure for SetupDiGetDeviceRegistryProperty().
                        DevInfoData.cbSize = (uint)Marshal.SizeOf(DevInfoData);
			            SetupDiEnumDeviceInfo(DeviceInfoTable, InterfaceIndex, ref DevInfoData);

			            //First query for the size of the hardware ID, so we can know how big a buffer to allocate for the data.
			            SetupDiGetDeviceRegistryProperty(DeviceInfoTable, ref DevInfoData, SPDRP_HARDWAREID, ref dwRegType, IntPtr.Zero, 0, ref dwRegSize);

			            //Allocate a buffer for the hardware ID.
                        //Should normally work, but could throw exception "OutOfMemoryException" if not enough resources available.
                        PropertyValueBuffer = Marshal.AllocHGlobal((int)dwRegSize);

			            //Retrieve the hardware IDs for the current device we are looking at.  PropertyValueBuffer gets filled with a 
			            //REG_MULTI_SZ (array of null terminated strings).  To find a device, we only care about the very first string in the
			            //buffer, which will be the "device ID".  The device ID is a string which contains the VID and PID, in the example 
			            //format "Vid_04d8&Pid_003f".
                        SetupDiGetDeviceRegistryProperty(DeviceInfoTable, ref DevInfoData, SPDRP_HARDWAREID, ref dwRegType, PropertyValueBuffer, dwRegSize, ref dwRegSize2);

			            //Now check if the first string in the hardware ID matches the device ID of the USB device we are trying to find.
			            String DeviceIDFromRegistry = Marshal.PtrToStringUni(PropertyValueBuffer); //Make a new string, fill it with the contents from the PropertyValueBuffer

			            Marshal.FreeHGlobal(PropertyValueBuffer);		//No longer need the PropertyValueBuffer, free the memory to prevent potential memory leaks

			            //Convert both strings to lower case.  This makes the code more robust/portable accross OS Versions
			            DeviceIDFromRegistry = DeviceIDFromRegistry.ToLowerInvariant();	
			            DeviceIDToFind = DeviceIDToFind.ToLowerInvariant();
                        DeviceIDToFind2 = DeviceIDToFind2.ToLowerInvariant();
                        //Now check if the hardware ID we are looking at contains the correct VID/PID
			            MatchFound = DeviceIDFromRegistry.Contains(DeviceIDToFind);
                        MatchFound2 = DeviceIDFromRegistry.Contains(DeviceIDToFind2);
                        if (MatchFound == true && MatchFound2 == true)
			            {
                            //Device must have been found.  In order to open I/O file handle(s), we will need the actual device path first.
				            //We can get the path by calling SetupDiGetDeviceInterfaceDetail(), however, we have to call this function twice:  The first
				            //time to get the size of the required structure/buffer to hold the detailed interface data, then a second time to actually 
				            //get the structure (after we have allocated enough memory for the structure.)
                            DetailedInterfaceDataStructure.cbSize = (uint)Marshal.SizeOf(DetailedInterfaceDataStructure);
				            //First call populates "StructureSize" with the correct value
				            SetupDiGetDeviceInterfaceDetail(DeviceInfoTable, ref InterfaceDataStructure, IntPtr.Zero, 0, ref StructureSize, IntPtr.Zero);
                            //Need to call SetupDiGetDeviceInterfaceDetail() again, this time specifying a pointer to a SP_DEVICE_INTERFACE_DETAIL_DATA buffer with the correct size of RAM allocated.
                            //First need to allocate the unmanaged buffer and get a pointer to it.
                            IntPtr pUnmanagedDetailedInterfaceDataStructure = IntPtr.Zero;  //Declare a pointer.
                            pUnmanagedDetailedInterfaceDataStructure = Marshal.AllocHGlobal((int)StructureSize);    //Reserve some unmanaged memory for the structure.
                            DetailedInterfaceDataStructure.cbSize = 6; //Initialize the cbSize parameter (4 bytes for DWORD + 2 bytes for unicode null terminator)
                            Marshal.StructureToPtr(DetailedInterfaceDataStructure, pUnmanagedDetailedInterfaceDataStructure, false); //Copy managed structure contents into the unmanaged memory buffer.

                            //Now call SetupDiGetDeviceInterfaceDetail() a second time to receive the device path in the structure at pUnmanagedDetailedInterfaceDataStructure.
                            if (SetupDiGetDeviceInterfaceDetail(DeviceInfoTable, ref InterfaceDataStructure, pUnmanagedDetailedInterfaceDataStructure, StructureSize, IntPtr.Zero, IntPtr.Zero))
                            {
                                //Need to extract the path information from the unmanaged "structure".  The path starts at (pUnmanagedDetailedInterfaceDataStructure + sizeof(DWORD)).
                                IntPtr pToDevicePath = new IntPtr((uint)pUnmanagedDetailedInterfaceDataStructure.ToInt32() + 4);  //Add 4 to the pointer (to get the pointer to point to the path, instead of the DWORD cbSize parameter)
                                DevicePath = Marshal.PtrToStringUni(pToDevicePath); //Now copy the path information into the globally defined DevicePath String.
                                
                                //We now have the proper device path, and we can finally use the path to open I/O handle(s) to the device.
                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure we no longer need.
                                Marshal.FreeHGlobal(pUnmanagedDetailedInterfaceDataStructure);  //No longer need this unmanaged SP_DEVICE_INTERFACE_DETAIL_DATA buffer.  We already extracted the path information.
                                return true;    //Returning the device path in the global DevicePath String
                            }
                            else //Some unknown failure occurred
                            {
                                uint ErrorCode = (uint)Marshal.GetLastWin32Error();
                                SetupDiDestroyDeviceInfoList(DeviceInfoTable);	//Clean up the old structure.
                                Marshal.FreeHGlobal(pUnmanagedDetailedInterfaceDataStructure);  //No longer need this unmanaged SP_DEVICE_INTERFACE_DETAIL_DATA buffer.  We already extracted the path information.
                                return false;    
                            }
                        }

			            InterfaceIndex++;	
			            //Keep looping until we either find a device with matching VID and PID, or until we run out of devices to check.
			            //However, just in case some unexpected error occurs, keep track of the number of loops executed.
			            //If the number of loops exceeds a very large number, exit anyway, to prevent inadvertent infinite looping.
			            LoopCounter++;
			            if(LoopCounter == 10000000)	//Surely there aren't more than 10 million devices attached to any forseeable PC...
			            {
				            return false;
			            }
		            }//end of while(true)
                }
                return false;
            }//end of try
            catch
            {
                //Something went wrong if PC gets here.  Maybe a Marshal.AllocHGlobal() failed due to insufficient resources or something.
			    return false;	
            }
        }
        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
        //This is a callback function that gets called when a Windows message is received by the form.
        //We will receive various different types of messages, but the ones we really want to use are the WM_DEVICECHANGE messages.
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                if (((int)m.WParam == DBT_DEVICEARRIVAL) || ((int)m.WParam == DBT_DEVICEREMOVEPENDING) || ((int)m.WParam == DBT_DEVICEREMOVECOMPLETE) || ((int)m.WParam == DBT_CONFIGCHANGED))
                {
                    //WM_DEVICECHANGE messages by themselves are quite generic, and can be caused by a number of different
                    //sources, not just your USB hardware device.  Therefore, must check to find out if any changes relavant
                    //to your device (with known VID/PID) took place before doing any kind of opening or closing of handles/endpoints.
                    //(the message could have been totally unrelated to your application/USB device)

                    if (CheckIfPresentAndGetUSBDevicePath())	//Check and make sure at least one device with matching VID/PID is attached
                    {
                        //If executes to here, this means the device is currently attached and was found.
                        //This code needs to decide however what to do, based on whether or not the device was previously known to be
                        //attached or not.
                        if ((AttachedState == false) || (AttachedButBroken == true))	//Check the previous attachment state
                        {
                            uint ErrorStatusWrite;
                            uint ErrorStatusRead;

                            //We obtained the proper device path (from CheckIfPresentAndGetUSBDevicePath() function call), and it
                            //is now possible to open read and write handles to the device.
                            WriteHandleToUSBDevice = CreateFile(DevicePath, GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                            ErrorStatusWrite = (uint)Marshal.GetLastWin32Error();
                            ReadHandleToUSBDevice = CreateFile(DevicePath, GENERIC_READ, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                            ErrorStatusRead = (uint)Marshal.GetLastWin32Error();

                            if ((ErrorStatusWrite == ERROR_SUCCESS) && (ErrorStatusRead == ERROR_SUCCESS))
                            {
                                AttachedState = true;		//Let the rest of the PC application know the USB device is connected, and it is safe to read/write to it
                                AttachedButBroken = false;
                                StatusBox_lbl.Text = "デバイス検出済";
                            }
                            else //for some reason the device was physically plugged in, but one or both of the read/write handles didn't open successfully...
                            {
                                AttachedState = false;		//Let the rest of this application known not to read/write to the device.
                                AttachedButBroken = true;	//Flag so that next time a WM_DEVICECHANGE message occurs, can retry to re-open read/write pipes
                                if (ErrorStatusWrite == ERROR_SUCCESS)
                                    WriteHandleToUSBDevice.Close();
                                if (ErrorStatusRead == ERROR_SUCCESS)
                                    ReadHandleToUSBDevice.Close();
                            }
                        }
                        //else we did find the device, but AttachedState was already true.  In this case, don't do anything to the read/write handles,
                        //since the WM_DEVICECHANGE message presumably wasn't caused by our USB device.  
                    }
                    else	//Device must not be connected (or not programmed with correct firmware)
                    {
                        if (AttachedState == true)		//If it is currently set to true, that means the device was just now disconnected
                        {
                            AttachedState = false;
                            WriteHandleToUSBDevice.Close();
                            ReadHandleToUSBDevice.Close();
                        }
                        AttachedState = false;
                        AttachedButBroken = false;
                    }
                }
            } //end of: if(m.Msg == WM_DEVICECHANGE)

            base.WndProc(ref m);
        } //end of: WndProc() function
        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void ReadWriteThread_DoWork(object sender, DoWorkEventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

            /*This thread does the actual USB read/write operations (but only when AttachedState == true) to the USB device.
            It is generally preferrable to write applications so that read and write operations are handled in a separate
            thread from the main form.  This makes it so that the main form can remain responsive, even if the I/O operations
            take a very long time to complete.

            Since this is a separate thread, this code below executes independently from the rest of the
            code in this application.  All this thread does is read and write to the USB device.  It does not update
            the form directly with the new information it obtains (such as the ANxx/POT Voltage or pushbutton state).
            The information that this thread obtains is stored in atomic global variables.
            Form updates are handled by the FormUpdateTimer Tick event handler function.

            This application sends packets to the endpoint buffer on the USB device by using the "WriteFile()" function.
            This application receives packets from the endpoint buffer on the USB device by using the "ReadFile()" function.
            Both of these functions are documented in the MSDN library.  Calling ReadFile() is a not perfectly straight
            foward in C# environment, since one of the input parameters is a pointer to a buffer that gets filled by ReadFile().
            The ReadFile() function is therefore called through a wrapper function ReadFileManagedBuffer().

            All ReadFile() and WriteFile() operations in this example project are synchronous.  They are blocking function
            calls and only return when they are complete, or if they fail because of some event, such as the user unplugging
            the device.  It is possible to call these functions with "overlapped" structures, and use them as non-blocking
            asynchronous I/O function calls.  

            Note:  This code may perform differently on some machines when the USB device is plugged into the host through a
            USB 2.0 hub, as opposed to a direct connection to a root port on the PC.  In some cases the data rate may be slower
            when the device is connected through a USB 2.0 hub.  This performance difference is believed to be caused by
            the issue described in Microsoft knowledge base article 940021:
            http://support.microsoft.com/kb/940021/en-us 

            Higher effective bandwidth (up to the maximum offered by interrupt endpoints), both when connected
            directly and through a USB 2.0 hub, can generally be achieved by queuing up multiple pending read and/or
            write requests simultaneously.  This can be done when using	asynchronous I/O operations (calling ReadFile() and
            WriteFile()	with overlapped structures).  The Microchip	HID USB Bootloader application uses asynchronous I/O
            for some USB operations and the source code can be used	as an example.*/


            Byte[] OUTBuffer = new byte[65];	//Allocate a memory buffer equal to the OUT endpoint size + 1
		    Byte[] INBuffer = new byte[65];		//Allocate a memory buffer equal to the IN endpoint size + 1
		    uint BytesWritten = 0;
		    uint BytesRead = 0;
            byte[,] tmp_device_data;

		    while(true)
		    {
                try
                {
                    if (AttachedState == true)	//Do not try to use the read/write handles unless the USB device is attached and ready
                    {
                        if (DeviceSoftResetReq == true)
                        {
                            device_soft_reset_command_counter++;
                            if (device_soft_reset_command_counter >= DEVICE_SOFT_RESET_COMMAND_SEND_NUM)
                            {
                                DeviceSoftResetReq = false;
                            }


                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }

                            OUTBuffer[0] = 0x0;				//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x55;

                            OUTBuffer[2] = 0x53;
                            OUTBuffer[3] = 0x4F;
                            OUTBuffer[4] = 0x46;
                            OUTBuffer[5] = 0x54;
                            OUTBuffer[6] = 0x52;
                            OUTBuffer[7] = 0x45;
                            OUTBuffer[8] = 0x53;
                            OUTBuffer[9] = 0x45;
                            OUTBuffer[10] = 0x54;
                            OUTBuffer[11] = 0x00;
                            OUTBuffer[12] = 0x5A;
                            OUTBuffer[13] = 0xFF;
                            OUTBuffer[14] = 0xA5;
                            OUTBuffer[15] = 0x00;

                            WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero);	//Blocking function, unless an "overlapped" structure is used
                        }

                        if (VersionReadReq == true)
                        {
                            VersionReadReq = false;

                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x56;		//0x81 is the "Get Pushbutton State" command in the firmware

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x56)
                                        {
                                            for (uint i = 2; i < 65; i++)
                                            {
                                                version_buff[i - 2] = INBuffer[i];
                                            }
                                            VersionReadComp = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }

                        if (DeviceDataReadReq == true)
                        {
                            DeviceDataReadReq = false;

                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x37;		//0x81 is the "Get Pushbutton State" command in the firmware

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x37)
                                        {
                                            tmp_device_data = new byte[Constants.SETTING_NUM, Constants.DEVICE_DATA_LEN];
                                            for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                                            {
                                                for (int fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                                                {
                                                    tmp_device_data[fi, fj] = INBuffer[2 + (fi * Constants.DEVICE_DATA_LEN) + fj];
                                                }
                                            }

                                            my_set_data.device_data_set(0, tmp_device_data);
                                            DeviceDataReadComp = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }

                        if (DeviceDataWriteReq == true)
                        {
                            DeviceDataWriteReq = false;

                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x80;		//0x81 is the "Get Pushbutton State" command in the firmware

                            tmp_device_data = new byte[Constants.SETTING_NUM, Constants.DEVICE_DATA_LEN];
                            my_set_data.device_data_get(0, ref tmp_device_data);
                            for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                            {
                                for (int fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                                {
                                    OUTBuffer[2 + (fi * Constants.DEVICE_DATA_LEN) + fj] = tmp_device_data[fi, fj];
                                }
                            }


                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x80)
                                        {
                                            DeviceDataWriteComp = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }
                        if (DeviceDataResetReq == true)
                        {
                            DeviceDataResetReq = false;

                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x80;		//0x81 is the "Get Pushbutton State" command in the firmware

                            for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                            {
                                for (int fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                                {
                                    OUTBuffer[2 + (fi * Constants.DEVICE_DATA_LEN) + fj] = 0;
                                }
                            }


                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x80)
                                        {
                                            DeviceDataResetComp = true;

                                            // 設定値再読み込み
                                            DeviceDataReadComp = false;
                                            DeviceDataReadReq = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }

                        // EEPROM初期化要求
                        if (b_eeprom_init_req == true)
                        {
                            b_eeprom_init_req = false;

                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x4F;		//0x81 is the "Get Pushbutton State" command in the firmware

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x4F)
                                        {
                                        }
                                    }
                                }
                            }
                            else
                            {
                                AttachedState = false;
                            }
                        }




#pragma warning disable 0162
                        //DEBUG DEBUG DEBUG *****************************************************************************************************
                        if (__DEBUG_FLAG__ == true)
                        {
                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }

                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x40;		//0x81 is the "Get Pushbutton State" command in the firmware

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x40)
                                        {
                                            Debug_Array[0] = (int)(INBuffer[2]);
                                            Debug_Array[1] = (int)(INBuffer[3]);
                                            Debug_Array[2] = (int)(INBuffer[4]);
                                            Debug_Array[3] = (int)(INBuffer[5]);
                                            Debug_Array[4] = (int)(INBuffer[6]);
                                            Debug_Array[5] = (int)(INBuffer[7]);
                                            Debug_Array[6] = (int)(INBuffer[8]);
                                            Debug_Array[7] = (int)(INBuffer[9]);
                                            Debug_Array[8] = (int)(INBuffer[10]);
                                            Debug_Array[9] = (int)(INBuffer[11]);
                                            Debug_Array[10] = (int)(INBuffer[12]);
                                            Debug_Array[11] = (int)(INBuffer[13]);
                                            Debug_Array[12] = (int)(INBuffer[14]);
                                            Debug_Array[13] = (int)(INBuffer[15]);
                                            Debug_Array[14] = (int)(INBuffer[16]);
                                            //Debug_3++;
                                        }
                                    }
                                }
                            }

                            for (uint i = 0; i < 65; i++)	//This loop is not strictly necessary.  Simply initializes unused bytes to
                            {
                                OUTBuffer[i] = 0xFF;				//0xFF for lower EMI and power consumption when driving the USB cable.
                            }
                            //Get the pushbutton state from the microcontroller firmware.
                            OUTBuffer[0] = 0;			//The first byte is the "Report ID" and does not get sent over the USB bus.  Always set = 0.
                            OUTBuffer[1] = 0x41;		//0x81 is the "Get Pushbutton State" command in the firmware

                            //To get the pushbutton state, first, we send a packet with our "Get Pushbutton State" command in it.
                            if (WriteFile(WriteHandleToUSBDevice, OUTBuffer, 65, ref BytesWritten, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                            {
                                //Now get the response packet from the firmware.
                                INBuffer[0] = 0;
                                {
                                    if (ReadFileManagedBuffer(ReadHandleToUSBDevice, INBuffer, 65, ref BytesRead, IntPtr.Zero))	//Blocking function, unless an "overlapped" structure is used
                                    {
                                        //INBuffer[0] is the report ID, which we don't care about.
                                        //INBuffer[1] is an echo back of the command (see microcontroller firmware).
                                        //INBuffer[2] contains the I/O port pin value for the pushbutton (see microcontroller firmware).  
                                        if (INBuffer[1] == 0x41)
                                        {
                                            Debug_Arr2[0] = (int)(INBuffer[2]);
                                            Debug_Arr2[1] = (int)(INBuffer[3]);
                                            Debug_Arr2[2] = (int)(INBuffer[4]);
                                            Debug_Arr2[3] = (int)(INBuffer[5]);
                                            Debug_Arr2[4] = (int)(INBuffer[6]);
                                            Debug_Arr2[5] = (int)(INBuffer[7]);
                                            Debug_Arr2[6] = (int)(INBuffer[8]);
                                            Debug_Arr2[7] = (int)(INBuffer[9]);
                                            Debug_Arr2[8] = (int)(INBuffer[10]);
                                            Debug_Arr2[9] = (int)(INBuffer[11]);
                                            Debug_Arr2[10] = (int)(INBuffer[12]);
                                            Debug_Arr2[11] = (int)(INBuffer[13]);
                                            Debug_Arr2[12] = (int)(INBuffer[14]);
                                            Debug_Arr2[13] = (int)(INBuffer[15]);
                                            Debug_Arr2[14] = (int)(INBuffer[16]);
                                        }
                                    }
                                }
                            }
                        }
                        //DEBUG DEBUG DEBUG *****************************************************************************************************
#pragma warning restore 0162

                    } //end of: if(AttachedState == true)
                    else
                    {
                        Thread.Sleep(5);	//Add a small delay.  Otherwise, this while(true) loop can execute very fast and cause 
                                            //high CPU utilization, with no particular benefit to the application.
                    }
                }
                catch
                {
                    //Exceptions can occur during the read or write operations.  For example,
                    //exceptions may occur if for instance the USB device is physically unplugged
                    //from the host while the above read/write functions are executing.

                    //Don't need to do anything special in this case.  The application will automatically
                    //re-establish communications based on the global AttachedState boolean variable used
                    //in conjunction with the WM_DEVICECHANGE messages to dyanmically respond to Plug and Play
                    //USB connection events.
                }

		    } //end of while(true) loop
            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }



        private void FormUpdateTimer_Tick(object sender, EventArgs e)
        {
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------
            //This timer tick event handler function is used to update the user interface on the form, based on data
            //obtained asynchronously by the ReadWriteThread and the WM_DEVICECHANGE event handler functions.

            //Check if user interface on the form should be enabled or not, based on the attachment state of the USB device.
            if (AttachedState == true)
            {
                //Device is connected and ready to communicate, enable user interface on the form 
                StatusBox_lbl.Text = "デバイス検出済";
                Status_C_pb.Visible = true;
                Status_NC_pb.Visible = false;

                if (ConnectFirstTime == true)
                {
                    ConnectFirstTime = false;

                }
            }
            if ((AttachedState == false) || (AttachedButBroken == true))
            {
                //Device not available to communicate. Disable user interface on the form.
                StatusBox_lbl.Text = "デバイス未検出";
                Status_NC_pb.Visible = true;
                Status_C_pb.Visible = false;

                ConnectFirstTime = true;

                // バージョン読み込み要求を設定
                VersionReadReq = true;
                VersionReadComp = false;
                DeviceDataReadReq = true;
                DeviceDataReadComp = false;

                btn_set.Enabled = false;
                btn_reset.Enabled = false;
            }


            //Update the various status indicators on the form with the latest info obtained from the ReadWriteThread()
            if (AttachedState == true)
            {
                // ファームウェアバージョン表示
                if (VersionReadComp == true)
                {
                    VersionReadComp = false;

                    lbl_FW_Version.Text = "FW Version " + Encoding.Default.GetString(version_buff);
                }

                btn_set.Enabled = true;
                btn_reset.Enabled = true;

                // デバイスデータ取得完了
                if (DeviceDataReadComp == true)
                {
                    DeviceDataReadComp = false;


                    // デバイスデータをコピー
                    my_device_data_get();
                    // 表示
                    my_setting_disp_all(true);

                }

                // デバイスデータ書き込み完了
                if (DeviceDataWriteComp == true)
                {
                    DeviceDataWriteComp = false;

                    if(DeviceDataWriteCompMsgReq == true)
                    {
                        DeviceDataWriteCompMsgReq = false;

                        MessageBox.Show(Constants.SET_WRITE_COMP_MSG, c_APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }









                //DEBUG
                string debug_str = "";
                colum_lbl.Text = string.Format("{0:000} : {1:000} : {2:000} : {3:000} : {4:000} : {5:000} : {6:000} : {7:000} : {8:000} : {9:000} : {10:000} : {11:000} : {12:000} : {13:000} : {14:000}",
                                                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14);

                debug01_lbl.Text = string.Format("{0:000} : {1:000} : {2:000} : {3:000} : {4:000} : {5:000} : {6:000} : {7:000} : {8:000} : {9:000} : {10:000} : {11:000} : {12:000} : {13:000} : {14:000}",
                    Debug_Array[0], Debug_Array[1], Debug_Array[2], Debug_Array[3], Debug_Array[4], Debug_Array[5], Debug_Array[6], Debug_Array[7], Debug_Array[8], Debug_Array[9], Debug_Array[10], Debug_Array[11], Debug_Array[12], Debug_Array[13], Debug_Array[14]);
                debug_str = "";
                for (int fi = 0; fi < 15; fi++)
                {
                    debug_str += string.Format(" {0:X2} : ", Debug_Array[fi]);
                }
                debug02_lbl.Text = debug_str;
                debug_str = "";
                for (int fi = 0; fi < 15; fi++)
                {
                    debug_str += string.Format(" {0:X2} : ", Debug_Arr2[fi]);
                }
                debug03_lbl.Text = debug_str;
            }
 
            //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------BEGIN CUT AND PASTE BLOCK-----------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------------------------------------------------
        //FUNCTION:	ReadFileManagedBuffer()
        //PURPOSE:	Wrapper function to call ReadFile()
        //
        //INPUT:	Uses managed versions of the same input parameters as ReadFile() uses.
        //
        //OUTPUT:	Returns boolean indicating if the function call was successful or not.
        //          Also returns data in the byte[] INBuffer, and the number of bytes read. 
        //
        //Notes:    Wrapper function used to call the ReadFile() function.  ReadFile() takes a pointer to an unmanaged buffer and deposits
        //          the bytes read into the buffer.  However, can't pass a pointer to a managed buffer directly to ReadFile().
        //          This ReadFileManagedBuffer() is a wrapper function to make it so application code can call ReadFile() easier
        //          by specifying a managed buffer.
        //--------------------------------------------------------------------------------------------------------------------------
        public unsafe bool ReadFileManagedBuffer(SafeFileHandle hFile, byte[] INBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped)
        {
            IntPtr pINBuffer = IntPtr.Zero;

            try
            {
                pINBuffer = Marshal.AllocHGlobal((int)nNumberOfBytesToRead);    //Allocate some unmanged RAM for the receive data buffer.

                if (ReadFile(hFile, pINBuffer, nNumberOfBytesToRead, ref lpNumberOfBytesRead, lpOverlapped))
                {
                    Marshal.Copy(pINBuffer, INBuffer, 0, (int)lpNumberOfBytesRead);    //Copy over the data from unmanged memory into the managed byte[] INBuffer
                    Marshal.FreeHGlobal(pINBuffer);
                    return true;
                }
                else
                {
                    Marshal.FreeHGlobal(pINBuffer);
                    return false;
                }

            }
            catch
            {
                if (pINBuffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pINBuffer);
                }
                return false;
            }
        }

        private void txtbx_KeyboardValue_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                int idx = int.Parse(((System.Windows.Forms.TextBox)sender).Tag.ToString());
                if (0 <= idx && idx < (Constants.SETTING_NUM * Constants.KEYBOARD_SET_KEY_NUM))
                {
                    if (e.KeyCode == Keys.Tab)
                    {
                        if (my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text != e.KeyValue.ToString())
                        {
                            //my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = e.KeyValue.ToString();
                            my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = USB_KeyCode_Name[VKtoUSBkey[e.KeyValue.GetHashCode()]];
                            my_set_data.keyboard_data[idx / Constants.KEYBOARD_SET_KEY_NUM, Constants.KEYBOARD_DATA_KEY1_IDX + (idx % Constants.KEYBOARD_SET_KEY_NUM)] = VKtoUSBkey[e.KeyValue.GetHashCode()];
                            e.IsInputKey = true;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void txtbx_KeyboardValue_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int idx = int.Parse(((System.Windows.Forms.TextBox)sender).Tag.ToString());
                if (0 <= idx && idx < (Constants.SETTING_NUM * Constants.KEYBOARD_SET_KEY_NUM))
                {
                    if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Alt)
                    //if ((e.KeyCode & Keys.ControlKey) == Keys.ControlKey || (e.KeyCode & Keys.ShiftKey) == Keys.ShiftKey || (e.KeyCode & Keys.Alt) == Keys.Alt)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        //my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = e.KeyValue.ToString();
                        my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = USB_KeyCode_Name[VKtoUSBkey[e.KeyValue.GetHashCode()]];
                        my_set_data.keyboard_data[idx / Constants.KEYBOARD_SET_KEY_NUM, Constants.KEYBOARD_DATA_KEY1_IDX + (idx % Constants.KEYBOARD_SET_KEY_NUM)] = VKtoUSBkey[e.KeyValue.GetHashCode()];
                        e.SuppressKeyPress = true;
                    }
                    ////my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = e.KeyValue.ToString();
                    //my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = USB_KeyCode_Name[VKtoUSBkey[e.KeyValue.GetHashCode()]];
                    //my_set_data.keyboard_data[idx / Constants.KEYBOARD_SET_KEY_NUM, Constants.KEYBOARD_DATA_KEY1_IDX + (idx % Constants.KEYBOARD_SET_KEY_NUM)] = VKtoUSBkey[e.KeyValue.GetHashCode()];
                    //e.SuppressKeyPress = true;
                }
            }
            catch
            {
            }
        }

        private void txtbx_KeyboardValue_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {
                int idx = int.Parse(((System.Windows.Forms.TextBox)sender).Tag.ToString());
                if (0 <= idx && idx < (Constants.SETTING_NUM * Constants.KEYBOARD_SET_KEY_NUM))
                {
                    if (e.KeyCode == Keys.PrintScreen)
                    {
                        //my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = e.KeyValue.ToString();
                        my_keyboard_key[idx / Constants.KEYBOARD_SET_KEY_NUM, idx % Constants.KEYBOARD_SET_KEY_NUM].Text = USB_KeyCode_Name[VKtoUSBkey[e.KeyValue.GetHashCode()]];
                        my_set_data.keyboard_data[idx / Constants.KEYBOARD_SET_KEY_NUM, Constants.KEYBOARD_DATA_KEY1_IDX + (idx % Constants.KEYBOARD_SET_KEY_NUM)] = VKtoUSBkey[e.KeyValue.GetHashCode()];
                        e.SuppressKeyPress = true;
                    }
                }
            }
            catch
            {
            }
        }

        private void cmbbx_Set_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((System.Windows.Forms.ComboBox)sender).Tag.ToString());
                if(0 <= idx && idx < Constants.SETTING_NUM)
                {
                    my_set_data.set_type[idx] = (byte)(my_cmbbx_set_type[idx].SelectedIndex & 0xFF);
                    my_setting_disp(idx, true);
                }
            }
            catch
            {
            }
        }

        // 全設定データの画面表示
        private void my_setting_disp_all(bool p_visible)
        {
            try
            {
                for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    my_setting_disp(fi, p_visible);
                }
            }
            catch
            {
            }
        }

        // 指定設定データの画面表示
        private void my_setting_disp(int p_idx, bool p_visible)
        {
            sbyte tmp_sbyte;
            decimal tmp_dec;
            try
            {
                if(0 <= p_idx && p_idx < Constants.SETTING_NUM)
                {
                    if (0 <= my_set_data.set_type[p_idx] && my_set_data.set_type[p_idx] < my_cmbbx_set_type[p_idx].Items.Count)
                    {
                        my_cmbbx_set_type[p_idx].SelectedIndex = my_set_data.set_type[p_idx];
                    }

                    switch (my_set_data.set_type[p_idx])
                    {
                        case Constants.SET_TYPE_NONE:
                            my_lbl_title[p_idx].Visible = false;
                            my_mouse_x[p_idx].Visible = false;
                            my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            //my_joypad_x[p_idx].Visible = false;
                            //my_joypad_y[p_idx].Visible = false;
                            break;
                        case Constants.SET_TYPE_MOUSE_LCLICK:
                        case Constants.SET_TYPE_MOUSE_RCLICK:
                        case Constants.SET_TYPE_MOUSE_WHCLICK:
                        case Constants.SET_TYPE_MOUSE_DCLICK:
                            my_lbl_title[p_idx].Visible = false;
                            my_mouse_x[p_idx].Visible = false;
                            my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            //my_joypad_x[p_idx].Visible = false;
                            //my_joypad_y[p_idx].Visible = false;
                            break;
                        case Constants.SET_TYPE_MOUSE_MOVE:
                            my_lbl_title[p_idx].Text = Constants.MOUSE_MOVE_TEXT;
                            my_lbl_title[p_idx].Visible = p_visible;
                            my_mouse_x[p_idx].Visible = p_visible;
                            my_mouse_x[p_idx].Minimum = Constants.MOUSE_MOVE_MIN;
                            my_mouse_x[p_idx].Maximum = Constants.MOUSE_MOVE_MAX;
                            if (my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_X_MOVE_IDX] > 0x7F)
                            {
                                tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_X_MOVE_IDX] - 0x100);
                            }
                            else
                            {
                                tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_X_MOVE_IDX]);
                            }
                            //tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_X_MOVE_IDX]);
                            tmp_dec = tmp_sbyte;
                            my_mouse_x[p_idx].Value = tmp_dec;
                            my_mouse_y[p_idx].Visible = p_visible;
                            my_mouse_y[p_idx].Minimum = Constants.MOUSE_MOVE_MIN;
                            my_mouse_y[p_idx].Maximum = Constants.MOUSE_MOVE_MAX;
                            if (my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_Y_MOVE_IDX] > 0x7F)
                            {
                                tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_Y_MOVE_IDX] - 0x100);
                            }
                            else
                            {
                                tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_Y_MOVE_IDX]);
                            }
                            //tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_Y_MOVE_IDX]);
                            tmp_dec = tmp_sbyte;
                            my_mouse_y[p_idx].Value = tmp_dec;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            //my_joypad_x[p_idx].Visible = false;
                            //my_joypad_y[p_idx].Visible = false;
                            break;
                        case Constants.SET_TYPE_MOUSE_WHSCROLL:
                            my_lbl_title[p_idx].Text = Constants.MOUSE_SCROLL_TEXT;
                            my_lbl_title[p_idx].Visible = p_visible;
                            my_mouse_x[p_idx].Visible = p_visible;
                            my_mouse_x[p_idx].Minimum = Constants.MOUSE_SCROLL_MIN;
                            my_mouse_x[p_idx].Maximum = Constants.MOUSE_SCROLL_MAX;
                            if (my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_WHEEL_IDX] > 0x7F)
                            {
                                tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_WHEEL_IDX] - 0x100);
                            }
                            else
                            {
                                tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_WHEEL_IDX]);
                            }
                            //tmp_sbyte = (sbyte)(my_set_data.mouse_data[p_idx, Constants.MOUSE_DATA_WHEEL_IDX]);
                            tmp_dec = tmp_sbyte;
                            my_mouse_x[p_idx].Value = tmp_dec;
                            my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            //my_joypad_x[p_idx].Visible = false;
                            //my_joypad_y[p_idx].Visible = false;
                            break;
                        case Constants.SET_TYPE_KEYBOARD_KEY:
                            my_lbl_title[p_idx].Text = Constants.KEYBOARD_INPUTKEY_TEXT;
                            my_lbl_title[p_idx].Visible = p_visible;
                            my_mouse_x[p_idx].Visible = false;
                            my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = p_visible;
                                if ((my_set_data.keyboard_data[p_idx, Constants.KEYBOARD_DATA_MODIFIER_IDX] & keyboard_modifier_bit[fi]) != 0)
                                {
                                    my_keyboard_modifier[p_idx, fi].Checked = true;
                                }
                                else
                                {
                                    my_keyboard_modifier[p_idx, fi].Checked = false;
                                }
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = p_visible;
                                if (my_set_data.keyboard_data[p_idx, Constants.KEYBOARD_DATA_KEY1_IDX+fi] == 0)
                                {
                                    my_keyboard_key[p_idx, fi].Text = Constants.KEYBOARD_SET_KEY_EMPTY;
                                }
                                else
                                {
                                    my_keyboard_key[p_idx, fi].Text = USB_KeyCode_Name[my_set_data.keyboard_data[p_idx, Constants.KEYBOARD_DATA_KEY1_IDX + fi]];
                                    //for (int fj = 0; fj < VKtoUSBkey.Length; fj++)
                                    //{
                                    //    if (my_set_data.keyboard_data[p_idx, Constants.KEYBOARD_DATA_KEY1_IDX + fi] == VKtoUSBkey[fj])
                                    //    {
                                    //        my_keyboard_key[p_idx, fi].Text = ((Keys)fj).ToString();
                                    //        break;
                                    //    }
                                    //}
                                }
                            }
                            my_keyboard_key_clr[p_idx].Visible = p_visible;
                            //my_joypad_x[p_idx].Visible = false;
                            //my_joypad_y[p_idx].Visible = false;
                            break;
                        case Constants.SET_TYPE_JOYPAD_XY:
                        case Constants.SET_TYPE_JOYPAD_ZRZ:
                            my_lbl_title[p_idx].Text = Constants.JOYPAD_MOVE_TEXT;
                            my_lbl_title[p_idx].Visible = p_visible;
                            //my_mouse_x[p_idx].Visible = false;
                            //my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            my_joypad_x[p_idx].Visible = p_visible;
                            my_joypad_x[p_idx].Minimum = Constants.JOYPAD_MOVE_MIN;
                            my_joypad_x[p_idx].Maximum = Constants.JOYPAD_MOVE_MAX;
                            if (my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_X_MOVE_IDX] > 0x7F)
                            {
                                tmp_sbyte = (sbyte)(my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_X_MOVE_IDX] - 0x100);
                            }
                            else
                            {
                                tmp_sbyte = (sbyte)(my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_X_MOVE_IDX]);
                            }
                            //tmp_sbyte = (sbyte)(my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_X_MOVE_IDX]);
                            tmp_dec = tmp_sbyte;
                            my_joypad_x[p_idx].Value = tmp_dec;
                            my_joypad_y[p_idx].Visible = p_visible;
                            my_joypad_y[p_idx].Minimum = Constants.JOYPAD_MOVE_MIN;
                            my_joypad_y[p_idx].Maximum = Constants.JOYPAD_MOVE_MAX;
                            if (my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_Y_MOVE_IDX] > 0x7F)
                            {
                                tmp_sbyte = (sbyte)(my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_Y_MOVE_IDX] - 0x100);
                            }
                            else
                            {
                                tmp_sbyte = (sbyte)(my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_Y_MOVE_IDX]);
                            }
                            //tmp_sbyte = (sbyte)(my_set_data.joypad_data[p_idx, Constants.JOYPAD_DATA_Y_MOVE_IDX]);
                            tmp_dec = tmp_sbyte;
                            my_joypad_y[p_idx].Value = tmp_dec;
                            break;
                        case Constants.SET_TYPE_JOYPAD_B01:
                        case Constants.SET_TYPE_JOYPAD_B02:
                        case Constants.SET_TYPE_JOYPAD_B03:
                        case Constants.SET_TYPE_JOYPAD_B04:
                        case Constants.SET_TYPE_JOYPAD_B05:
                        case Constants.SET_TYPE_JOYPAD_B06:
                        case Constants.SET_TYPE_JOYPAD_B07:
                        case Constants.SET_TYPE_JOYPAD_B08:
                        case Constants.SET_TYPE_JOYPAD_B09:
                        case Constants.SET_TYPE_JOYPAD_B10:
                        case Constants.SET_TYPE_JOYPAD_B11:
                        case Constants.SET_TYPE_JOYPAD_B12:
                        case Constants.SET_TYPE_JOYPAD_B13:
                            my_lbl_title[p_idx].Visible = false;
                            //my_mouse_x[p_idx].Visible = false;
                            //my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            my_joypad_x[p_idx].Visible = false;
                            my_joypad_y[p_idx].Visible = false;
                            break;
                        case Constants.SET_TYPE_JOYPAD_HSW_NORTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_EAST:
                        case Constants.SET_TYPE_JOYPAD_HSW_SOUTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_WEST:
                            my_lbl_title[p_idx].Visible = false;
                            //my_mouse_x[p_idx].Visible = false;
                            //my_mouse_y[p_idx].Visible = false;
                            for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                            {
                                my_keyboard_modifier[p_idx, fi].Visible = false;
                            }
                            for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                            {
                                my_keyboard_key[p_idx, fi].Visible = false;
                            }
                            my_keyboard_key_clr[p_idx].Visible = false;
                            my_joypad_x[p_idx].Visible = false;
                            my_joypad_y[p_idx].Visible = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        // 画面表示内容を取得して設定データバッファに格納する
        private void my_display_data_get()
        {
            int move_val = 0;
            try
            {
                for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    switch (my_cmbbx_set_type[fi].SelectedIndex)
                    {
                        case Constants.SET_TYPE_MOUSE_LCLICK:
                        case Constants.SET_TYPE_MOUSE_RCLICK:
                        case Constants.SET_TYPE_MOUSE_WHCLICK:
                        case Constants.SET_TYPE_MOUSE_DCLICK:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            for (int fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                            {
                                my_set_data.mouse_data[fi, fj] = 0;
                            }
                            switch (my_cmbbx_set_type[fi].SelectedIndex)
                            {
                                case Constants.SET_TYPE_MOUSE_LCLICK:
                                    my_set_data.mouse_data[fi, Constants.MOUSE_DATA_CLICK_IDX] = Constants.MOUSE_DATA_LEFT_CLICK;
                                    break;
                                case Constants.SET_TYPE_MOUSE_RCLICK:
                                    my_set_data.mouse_data[fi, Constants.MOUSE_DATA_CLICK_IDX] = Constants.MOUSE_DATA_RIGHT_CLICK;
                                    break;
                                case Constants.SET_TYPE_MOUSE_WHCLICK:
                                    my_set_data.mouse_data[fi, Constants.MOUSE_DATA_CLICK_IDX] = Constants.MOUSE_DATA_WHEEL_CLICK;
                                    break;
                                case Constants.SET_TYPE_MOUSE_DCLICK:
                                    my_set_data.mouse_data[fi, Constants.MOUSE_DATA_CLICK_IDX] = Constants.MOUSE_DATA_LEFT_CLICK;
                                    break;
                            }
                            break;
                        case Constants.SET_TYPE_MOUSE_MOVE:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            for (int fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                            {
                                my_set_data.mouse_data[fi, fj] = 0;
                            }
                            move_val = 0;
                            try
                            {
                                move_val = int.Parse(my_mouse_x[fi].Value.ToString());
                            }
                            catch
                            {
                            }
                            my_set_data.mouse_data[fi, Constants.MOUSE_DATA_X_MOVE_IDX] = (byte)(move_val & 0xFF);
                            move_val = 0;
                            try
                            {
                                move_val = int.Parse(my_mouse_y[fi].Value.ToString());
                            }
                            catch
                            {
                            }
                            my_set_data.mouse_data[fi, Constants.MOUSE_DATA_Y_MOVE_IDX] = (byte)(move_val & 0xFF);
                            break;
                        case Constants.SET_TYPE_MOUSE_WHSCROLL:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            for (int fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                            {
                                my_set_data.mouse_data[fi, fj] = 0;
                            }
                            move_val = 0;
                            try
                            {
                                move_val = int.Parse(my_mouse_x[fi].Value.ToString());
                            }
                            catch
                            {
                            }
                            my_set_data.mouse_data[fi, Constants.MOUSE_DATA_WHEEL_IDX] = (byte)(move_val & 0xFF);
                            break;
                        case Constants.SET_TYPE_KEYBOARD_KEY:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            // モディファイビットをクリア
                            for (int fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                            {
                                if (fj == Constants.KEYBOARD_DATA_MODIFIER_IDX)
                                {
                                    my_set_data.keyboard_data[fi, fj] = 0;
                                    break;
                                }
                            }
                            // モディファイがセットされているかチェックして、ビットセット
                            for (int fj = 0; fj < my_keyboard_modifier.GetLength(1); fj++)
                            {
                                if (my_keyboard_modifier[fi, fj].Checked == true)
                                {
                                    my_set_data.keyboard_data[fi, Constants.KEYBOARD_DATA_MODIFIER_IDX] |= keyboard_modifier_bit[fj];
                                }
                            }

                            // キーがモディファイ対象キーなら、モディファイビットをセットする
                            //for (int fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                            //{
                            //    if (fj != Constants.KEYBOARD_DATA_MODIFIER_IDX)
                            //    {
                            //        for (int fk = 0; fk < keyborad_modifier_data.GetLength(0); fk++)
                            //        {
                            //            if (my_set_data.keyboard_data[fi, fj] == keyborad_modifier_data[fk, 0])
                            //            {
                            //                //my_set_data.keyboard_data[fi, fj] = 0;
                            //                my_set_data.keyboard_data[fi, Constants.KEYBOARD_DATA_MODIFIER_IDX] |= keyborad_modifier_data[fk, 1];
                            //                break;
                            //            }
                            //        }
                            //    }
                            //}
                            break;
                        case Constants.SET_TYPE_JOYPAD_XY:
                        case Constants.SET_TYPE_JOYPAD_ZRZ:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            for (int fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                            {
                                my_set_data.joypad_data[fi, fj] = 0;
                            }
                            my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_NULL;
                            move_val = 0;
                            try
                            {
                                move_val = int.Parse(my_joypad_x[fi].Value.ToString());
                            }
                            catch
                            {
                            }
                            my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_X_MOVE_IDX] = (byte)(move_val & 0xFF);
                            move_val = 0;
                            try
                            {
                                move_val = int.Parse(my_joypad_y[fi].Value.ToString());
                            }
                            catch
                            {
                            }
                            my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_Y_MOVE_IDX] = (byte)(move_val & 0xFF);
                            break;
                        case Constants.SET_TYPE_JOYPAD_B01:
                        case Constants.SET_TYPE_JOYPAD_B02:
                        case Constants.SET_TYPE_JOYPAD_B03:
                        case Constants.SET_TYPE_JOYPAD_B04:
                        case Constants.SET_TYPE_JOYPAD_B05:
                        case Constants.SET_TYPE_JOYPAD_B06:
                        case Constants.SET_TYPE_JOYPAD_B07:
                        case Constants.SET_TYPE_JOYPAD_B08:
                        case Constants.SET_TYPE_JOYPAD_B09:
                        case Constants.SET_TYPE_JOYPAD_B10:
                        case Constants.SET_TYPE_JOYPAD_B11:
                        case Constants.SET_TYPE_JOYPAD_B12:
                        case Constants.SET_TYPE_JOYPAD_B13:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            for (int fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                            {
                                my_set_data.joypad_data[fi, fj] = 0;
                            }
                            my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_NULL;
                            int tmp_byte_pos = (my_cmbbx_set_type[fi].SelectedIndex - Constants.SET_TYPE_JOYPAD_B01) / 8;
                            int tmp_bit_pos = (my_cmbbx_set_type[fi].SelectedIndex - Constants.SET_TYPE_JOYPAD_B01) % 8;
                            int tmp_bit_ope = my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_BUTTON1_IDX + tmp_byte_pos];
                            tmp_bit_ope |= (0x01 << tmp_bit_pos);
                            my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_BUTTON1_IDX + tmp_byte_pos] = (byte)(tmp_bit_ope & 0xFF);
                            break;
                        case Constants.SET_TYPE_JOYPAD_HSW_NORTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_EAST:
                        case Constants.SET_TYPE_JOYPAD_HSW_SOUTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_WEST:
                            my_set_data.set_type[fi] = (byte)(my_cmbbx_set_type[fi].SelectedIndex & 0xFF);
                            for (int fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                            {
                                my_set_data.joypad_data[fi, fj] = 0;
                            }
                            my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_NULL;
                            switch (my_set_data.set_type[fi])
                            {
                                case Constants.SET_TYPE_JOYPAD_HSW_NORTH:
                                    my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_NORTH;
                                    break;
                                case Constants.SET_TYPE_JOYPAD_HSW_EAST:
                                    my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_EAST;
                                    break;
                                case Constants.SET_TYPE_JOYPAD_HSW_SOUTH:
                                    my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_SOUTH;
                                    break;
                                case Constants.SET_TYPE_JOYPAD_HSW_WEST:
                                    my_set_data.joypad_data[fi, Constants.JOYPAD_DATA_HAT_SW_IDX] = Constants.HAT_SWITCH_WEST;
                                    break;
                            }
                            break;
                        case Constants.SET_TYPE_NONE:
                        default:
                            my_set_data.set_type[fi] = (byte)(Constants.SET_TYPE_NONE & 0xFF);
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        // デバイスへセットするデータ形式でデータをセット
        private void my_device_data_set()
        {
            try
            {
                // バッファクリア
                for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    for(int fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                    {
                        my_set_data.setting_data[fi,fj] = 0;
                    }
                }

                for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    switch (my_set_data.set_type[fi])
                    {
                        case Constants.SET_TYPE_MOUSE_LCLICK:
                        case Constants.SET_TYPE_MOUSE_RCLICK:
                        case Constants.SET_TYPE_MOUSE_WHCLICK:
                        case Constants.SET_TYPE_MOUSE_DCLICK:
                        case Constants.SET_TYPE_MOUSE_MOVE:
                        case Constants.SET_TYPE_MOUSE_WHSCROLL:
                            my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX] = my_set_data.set_type[fi];
                            for (int fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                            {
                                my_set_data.setting_data[fi, Constants.DEVICE_DATA_CLICK_IDX + fj] = my_set_data.mouse_data[fi, fj];
                            }
                            break;
                        case Constants.SET_TYPE_KEYBOARD_KEY:
                            my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX] = my_set_data.set_type[fi];
                            for (int fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                            {
                                my_set_data.setting_data[fi, Constants.DEVICE_DATA_MODIFIER_IDX + fj] = my_set_data.keyboard_data[fi, fj];
                            }
                            break;
                        case Constants.SET_TYPE_JOYPAD_XY:
                        case Constants.SET_TYPE_JOYPAD_ZRZ:
                        case Constants.SET_TYPE_JOYPAD_B01:
                        case Constants.SET_TYPE_JOYPAD_B02:
                        case Constants.SET_TYPE_JOYPAD_B03:
                        case Constants.SET_TYPE_JOYPAD_B04:
                        case Constants.SET_TYPE_JOYPAD_B05:
                        case Constants.SET_TYPE_JOYPAD_B06:
                        case Constants.SET_TYPE_JOYPAD_B07:
                        case Constants.SET_TYPE_JOYPAD_B08:
                        case Constants.SET_TYPE_JOYPAD_B09:
                        case Constants.SET_TYPE_JOYPAD_B10:
                        case Constants.SET_TYPE_JOYPAD_B11:
                        case Constants.SET_TYPE_JOYPAD_B12:
                        case Constants.SET_TYPE_JOYPAD_B13:
                        case Constants.SET_TYPE_JOYPAD_HSW_NORTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_EAST:
                        case Constants.SET_TYPE_JOYPAD_HSW_SOUTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_WEST:
                            my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX] = my_set_data.set_type[fi];
                            for (int fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                            {
                                my_set_data.setting_data[fi, Constants.DEVICE_DATA_JOY_BUTTON1_IDX + fj] = my_set_data.joypad_data[fi, fj];
                            }
                            break;
                        case Constants.SET_TYPE_NONE:
                        default:
                            my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX] = my_set_data.set_type[fi];
                            break;
                    }
                }
            }
            catch
            {
            }
        }

        // デバイスのデータ形式から、本アプリ用のデータ形式で取得
        private void my_device_data_get()
        {
            try
            {
                // データクリア
                //my_set_data.Init();

                for (int fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    // 表示データクリア
                    my_set_data.disp_data_clear(fi);

                    switch (my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX])
                    {
                        case Constants.SET_TYPE_MOUSE_LCLICK:
                        case Constants.SET_TYPE_MOUSE_RCLICK:
                        case Constants.SET_TYPE_MOUSE_WHCLICK:
                        case Constants.SET_TYPE_MOUSE_DCLICK:
                        case Constants.SET_TYPE_MOUSE_MOVE:
                        case Constants.SET_TYPE_MOUSE_WHSCROLL:
                            my_set_data.set_type[fi] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX];
                            for (int fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                            {
                                my_set_data.mouse_data[fi, fj] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_CLICK_IDX + fj];
                            }
                            break;
                        case Constants.SET_TYPE_KEYBOARD_KEY:
                            my_set_data.set_type[fi] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX];
                            for (int fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                            {
                                my_set_data.keyboard_data[fi, fj] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_MODIFIER_IDX + fj];
                            }
                            break;
                        case Constants.SET_TYPE_JOYPAD_XY:
                        case Constants.SET_TYPE_JOYPAD_ZRZ:
                        case Constants.SET_TYPE_JOYPAD_B01:
                        case Constants.SET_TYPE_JOYPAD_B02:
                        case Constants.SET_TYPE_JOYPAD_B03:
                        case Constants.SET_TYPE_JOYPAD_B04:
                        case Constants.SET_TYPE_JOYPAD_B05:
                        case Constants.SET_TYPE_JOYPAD_B06:
                        case Constants.SET_TYPE_JOYPAD_B07:
                        case Constants.SET_TYPE_JOYPAD_B08:
                        case Constants.SET_TYPE_JOYPAD_B09:
                        case Constants.SET_TYPE_JOYPAD_B10:
                        case Constants.SET_TYPE_JOYPAD_B11:
                        case Constants.SET_TYPE_JOYPAD_B12:
                        case Constants.SET_TYPE_JOYPAD_B13:
                        case Constants.SET_TYPE_JOYPAD_HSW_NORTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_EAST:
                        case Constants.SET_TYPE_JOYPAD_HSW_SOUTH:
                        case Constants.SET_TYPE_JOYPAD_HSW_WEST:
                            my_set_data.set_type[fi] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX];
                            for (int fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                            {
                                my_set_data.joypad_data[fi, fj] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_JOY_BUTTON1_IDX + fj];
                            }
                            break;
                        case Constants.SET_TYPE_NONE:
                        default:
                            my_set_data.set_type[fi] = my_set_data.setting_data[fi, Constants.DEVICE_DATA_SET_TYPE_IDX];
                            break;
                    }
                }
            }
            catch
            {
            }
        }


        private void btn_set_Click(object sender, EventArgs e)
        {
            try
            {
                my_display_data_get();
                my_device_data_set();

                DeviceDataWriteComp = false;
                DeviceDataWriteReq = true;
                DeviceDataWriteCompMsgReq = true;
            }
            catch
            {
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            int i_ret = 0;
            try
            {
                openFileDialog1.Title = "Open...";
                openFileDialog1.Filter = "XML file(*.xml)|*.xml|All file(*.*)|*.*";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    i_ret = my_File_Load(openFileDialog1.FileName);

                    if (i_ret == 0)
                    {
                        my_setting_disp_all(true);
                    }
                }
            }
            catch
            {
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Title = "Save As...";
                saveFileDialog1.Filter = "XML file(*.xml)|*.xml|All file(*.*)|*.*";

                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    my_display_data_get();
                    my_device_data_set();
                    my_File_Save(saveFileDialog1.FileName, true);
                }
            }
            catch
            {
            }
        }

        private int my_File_Load(string file_name)
        {
            int ret = -1;
            try
            {

#if true   // XML
                Stream stream = null;
                try
                {
                    stream = File.Open(file_name, FileMode.Open, FileAccess.Read);
                    SoapFormatter formatter = new SoapFormatter();

                    my_set_data = (SetData)formatter.Deserialize(stream);

                    ret = 0;
                }
                catch
                {
                    MessageBox.Show(Constants.FILE_LOAD_ERR_MSG, c_APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                        stream.Dispose();
                    }
                }
#endif
            }
            catch
            {
            }
            return ret;
        }

        private int my_File_Save(string file_name, bool save_flag)
        {
            int ret = -1;
            try
            {
#if true   // XML
                Stream stream = null;
                try
                {
                    stream = File.Open(file_name, FileMode.Create, FileAccess.ReadWrite);
                    SoapFormatter formatter = new SoapFormatter();

                    formatter.Serialize(stream, my_set_data);

                    ret = 0;
                }
                catch
                {
                    MessageBox.Show(Constants.FILE_SAVE_ERR_MSG, c_APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                        stream.Dispose();
                    }
                }
#endif
            }
            catch
            {
            }
            return ret;
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Constants.RESET_WARNING_MSG, c_APPLICATION_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    //DeviceDataResetComp = false;
                    //DeviceDataResetReq = true;

                    b_eeprom_init_req = true;

                    if (MessageBox.Show(Constants.RESET_WARNING_MSG2, c_APPLICATION_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void btn_soft_reset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(Constants.SOFT_RESET_WARNING_MSG, c_APPLICATION_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    device_soft_reset_command_counter = 0;
                    DeviceSoftResetComp = false;
                    DeviceSoftResetReq = true;
                }
            }
            catch
            {
            }
        }

        private void btn_key_clr_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = int.Parse(((System.Windows.Forms.Button)sender).Tag.ToString());
                if (0 <= idx && idx < Constants.SETTING_NUM)
                {
                    for (int fi = 0; fi < my_keyboard_modifier.GetLength(1); fi++)
                    {
                        my_keyboard_modifier[idx, fi].Checked = false;
                    }
                    for (int fi = 0; fi < my_keyboard_key.GetLength(1); fi++)
                    {
                        my_keyboard_key[idx, fi].Text = Constants.KEYBOARD_SET_KEY_EMPTY;
                        my_set_data.keyboard_data[idx, Constants.KEYBOARD_DATA_KEY1_IDX + fi] = 0x00;
                    }
                }
            }
            catch
            {
            }
        }

        private void btn_eeprom_init_Click(object sender, EventArgs e)
        {
            try
            {
                b_eeprom_init_req = true;
            }
            catch
            {
            }
        }

        private void btn_set_MouseEnter(object sender, EventArgs e)
        {
            btn_set.ImageIndex = 1;
        }

        private void btn_set_MouseLeave(object sender, EventArgs e)
        {
            btn_set.ImageIndex = 0;
        }

        private void btn_load_MouseEnter(object sender, EventArgs e)
        {
            btn_load.ImageIndex = 1;
        }

        private void btn_load_MouseLeave(object sender, EventArgs e)
        {
            btn_load.ImageIndex = 0;
        }

        private void btn_save_MouseEnter(object sender, EventArgs e)
        {
            btn_save.ImageIndex = 3;
        }

        private void btn_save_MouseLeave(object sender, EventArgs e)
        {
            btn_save.ImageIndex = 2;
        }

        private void btn_reset_MouseEnter(object sender, EventArgs e)
        {
            btn_reset.ImageIndex = 1;
        }

        private void btn_reset_MouseLeave(object sender, EventArgs e)
        {
            btn_reset.ImageIndex = 0;
        }




        //-------------------------------------------------------END CUT AND PASTE BLOCK-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
    } //public partial class Form1 : Form



    static class Constants
    {
        public const int SETTING_NUM = 8;                   // 設定数
        public const int DEVICE_DATA_LEN = 6;               // デバイス設定データ長
        public const int DEVICE_DATA_SET_TYPE_IDX = 0;      // デバイス設定データ 設定タイプ格納位置
        public const int DEVICE_DATA_CLICK_IDX = 1;         // デバイス設定データ　マウスデータ　クリックデータ格納位置
        public const int DEVICE_DATA_X_MOVE_IDX = 2;        // デバイス設定データ　マウスデータ　X移動量格納位置
        public const int DEVICE_DATA_Y_MOVE_IDX = 3;        // デバイス設定データ　マウスデータ　Y移動量格納位置
        public const int DEVICE_DATA_WHEEL_IDX = 4;         // デバイス設定データ　マウスデータ　ホイールスクロール量格納位置
        public const int DEVICE_DATA_MODIFIER_IDX = 1;      // デバイス設定データ　キーボードデータ　モディファイデータ格納位置
        public const int DEVICE_DATA_KEY1_IDX = 2;          // デバイス設定データ　キーボードデータ　キーデータ1格納位置
        public const int DEVICE_DATA_KEY2_IDX = 3;          // デバイス設定データ　キーボードデータ　キーデータ2格納位置
        public const int DEVICE_DATA_KEY3_IDX = 4;          // デバイス設定データ　キーボードデータ　キーデータ3格納位置
        public const int DEVICE_DATA_JOY_BUTTON1_IDX = 1;   // デバイス設定データ　ジョイパッドデータ　ボタンデータ格納位置
        public const int DEVICE_DATA_JOY_BUTTON2_IDX = 2;   // デバイス設定データ　ジョイパッドデータ　ボタンデータ格納位置
        public const int DEVICE_DATA_JOY_HAT_SW_IDX	= 3;	// デバイス設定データ　ジョイパッドデータ　HAT SW格納位置
        public const int DEVICE_DATA_JOY_X_MOVE_IDX	= 4;	// デバイス設定データ　ジョイパッドデータ　X軸移動量格納位置
        public const int DEVICE_DATA_JOY_Y_MOVE_IDX = 5;	// デバイス設定データ　ジョイパッドデータ　Y軸移動量格納位置

        public const int MOUSE_DATA_LEN = 4;                // マウスデータ長
        public const int MOUSE_DATA_CLICK_IDX = 0;          // マウスデータ　クリックデータ格納位置
        public const int MOUSE_DATA_X_MOVE_IDX = 1;         // マウスデータ　X移動量格納位置
        public const int MOUSE_DATA_Y_MOVE_IDX = 2;         // マウスデータ　Y移動量格納位置
        public const int MOUSE_DATA_WHEEL_IDX = 3;          // マウスデータ　ホイールスクロール量格納位置
        public const byte MOUSE_DATA_LEFT_CLICK = 0x01;     // マウスデータ　左クリック
        public const byte MOUSE_DATA_RIGHT_CLICK = 0x02;    // マウスデータ　右クリック
        public const byte MOUSE_DATA_WHEEL_CLICK = 0x04;    // マウスデータ　ホイールクリック
        public const int KEYBOARD_DATA_LEN = 4;             // キーボードデータ長
        public const int KEYBOARD_DATA_MODIFIER_IDX = 0;    // キーボードデータ　モディファイデータ格納位置
        public const int KEYBOARD_DATA_KEY1_IDX = 1;        // キーボードデータ　キーデータ1格納位置
        public const int KEYBOARD_DATA_KEY2_IDX = 2;        // キーボードデータ　キーデータ2格納位置
        public const int KEYBOARD_DATA_KEY3_IDX = 3;        // キーボードデータ　キーデータ3格納位置
        public const int JOYPAD_DATA_LEN = 5;               // ジョイパッドデータ長
        public const int JOYPAD_DATA_BUTTON1_IDX = 0;       // ジョイパッドデータ　ボタンデータ格納位置
        public const int JOYPAD_DATA_BUTTON2_IDX = 1;       // ジョイパッドデータ　ボタンデータ格納位置
        public const int JOYPAD_DATA_HAT_SW_IDX = 2;       // ジョイパッドデータ　ハットスイッチデータ格納位置
        public const int JOYPAD_DATA_X_MOVE_IDX = 3;        // ジョイパッドデータ　X軸移動量格納位置
        public const int JOYPAD_DATA_Y_MOVE_IDX = 4;        // ジョイパッドデータ　Y軸移動量格納位置
        public const byte HAT_SWITCH_NORTH = 0x00;          // ジョイパッドデータ　ハットスイッチ　北
        public const byte HAT_SWITCH_NORTH_EAST = 0x01;     // ジョイパッドデータ　ハットスイッチ　北東
        public const byte HAT_SWITCH_EAST = 0x02;           // ジョイパッドデータ　ハットスイッチ　東
        public const byte HAT_SWITCH_SOUTH_EAST = 0x03;     // ジョイパッドデータ　ハットスイッチ　南東
        public const byte HAT_SWITCH_SOUTH = 0x04;          // ジョイパッドデータ　ハットスイッチ　南
        public const byte HAT_SWITCH_SOUTH_WEST = 0x05;     // ジョイパッドデータ　ハットスイッチ　南西
        public const byte HAT_SWITCH_WEST = 0x06;           // ジョイパッドデータ　ハットスイッチ　西
        public const byte HAT_SWITCH_NORTH_WEST = 0x07;     // ジョイパッドデータ　ハットスイッチ　北西
        public const byte HAT_SWITCH_NULL = 0x08;           // ジョイパッドデータ　ハットスイッチ　なし

        public const int SET_TYPE_NONE = 0;                 // 設定タイプ　なし
        public const int SET_TYPE_MOUSE_LCLICK = 1;         // 設定タイプ　マウス　左クリック
        public const int SET_TYPE_MOUSE_RCLICK = 2;         // 設定タイプ　マウス　右クリック
        public const int SET_TYPE_MOUSE_WHCLICK = 3;        // 設定タイプ　マウス　ホイールクリック
        public const int SET_TYPE_MOUSE_DCLICK = 4;         // 設定タイプ　マウス　ダブルクリック
        public const int SET_TYPE_MOUSE_MOVE = 5;           // 設定タイプ　マウス　上下左右移動
        public const int SET_TYPE_MOUSE_WHSCROLL = 6;       // 設定タイプ　マウス　ホイールスクロール
        public const int SET_TYPE_KEYBOARD_KEY = 7;         // 設定タイプ　キーボード　キー
        public const int SET_TYPE_JOYPAD_XY = 8;            // 設定タイプ　ジョイパッド　左X-Y軸
        public const int SET_TYPE_JOYPAD_ZRZ = 9;           // 設定タイプ　ジョイパッド　右X-Y軸
        public const int SET_TYPE_JOYPAD_B01 = 10;          // 設定タイプ　ジョイパッド　ボタン1
        public const int SET_TYPE_JOYPAD_B02 = 11;          // 設定タイプ　ジョイパッド　ボタン2
        public const int SET_TYPE_JOYPAD_B03 = 12;          // 設定タイプ　ジョイパッド　ボタン3
        public const int SET_TYPE_JOYPAD_B04 = 13;          // 設定タイプ　ジョイパッド　ボタン4
        public const int SET_TYPE_JOYPAD_B05 = 14;          // 設定タイプ　ジョイパッド　ボタン5
        public const int SET_TYPE_JOYPAD_B06 = 15;          // 設定タイプ　ジョイパッド　ボタン6
        public const int SET_TYPE_JOYPAD_B07 = 16;          // 設定タイプ　ジョイパッド　ボタン7
        public const int SET_TYPE_JOYPAD_B08 = 17;          // 設定タイプ　ジョイパッド　ボタン8
        public const int SET_TYPE_JOYPAD_B09 = 18;          // 設定タイプ　ジョイパッド　ボタン9
        public const int SET_TYPE_JOYPAD_B10 = 19;          // 設定タイプ　ジョイパッド　ボタン10
        public const int SET_TYPE_JOYPAD_B11 = 20;          // 設定タイプ　ジョイパッド　ボタン11
        public const int SET_TYPE_JOYPAD_B12 = 21;          // 設定タイプ　ジョイパッド　ボタン12
        public const int SET_TYPE_JOYPAD_B13 = 22;          // 設定タイプ　ジョイパッド　ボタン13
        public const int SET_TYPE_JOYPAD_HSW_NORTH = 23;    // 設定タイプ　ジョイパッド　ハットスイッチ　北
        public const int SET_TYPE_JOYPAD_HSW_SOUTH = 24;    // 設定タイプ　ジョイパッド　ハットスイッチ　南
        public const int SET_TYPE_JOYPAD_HSW_WEST = 25;     // 設定タイプ　ジョイパッド　ハットスイッチ　西
        public const int SET_TYPE_JOYPAD_HSW_EAST = 26;	    // 設定タイプ　ジョイパッド　ハットスイッチ　東

        public const string MOUSE_MOVE_TEXT = "X,Y移動量";
        public const decimal MOUSE_MOVE_MIN = -127;
        public const decimal MOUSE_MOVE_MAX = 127;
        public const string MOUSE_SCROLL_TEXT = "スクロール数";
        public const decimal MOUSE_SCROLL_MIN = -127;
        public const decimal MOUSE_SCROLL_MAX = 127;
        public const int KEYBOARD_SET_KEY_NUM = 3;          // キーボード　設定可能キー数
        public const string KEYBOARD_SET_KEY_EMPTY = "ここに入力";          // 
        public const string KEYBOARD_INPUTKEY_TEXT = "設定キー";
        public const string JOYPAD_MOVE_TEXT = "X,Y軸移動量";
        public const decimal JOYPAD_MOVE_MIN = -127;
        public const decimal JOYPAD_MOVE_MAX = 127;

        public const string RESET_WARNING_MSG = "設定内容を初期化します。よろしいですか？";
        public const string RESET_WARNING_MSG2 = "一旦USBケーブルを抜いて、画面右下のデバイス検出済みからデバイス未検出になってから、USBケーブルを挿し直して下さい。";
        public const string SOFT_RESET_WARNING_MSG = "ファームウェアの書き換えを開始します。よろしいですか？";
        public const string SET_WRITE_COMP_MSG = "設定完了";
        public const string FILE_LOAD_ERR_MSG = "ファイルのLOADに失敗しました。";
        public const string FILE_SAVE_ERR_MSG = "ファイルのSAVEに失敗しました。";
    }


    [Serializable()]
    public class SetData
    {
        [System.Xml.Serialization.XmlElement("INDEX")]
        public int[] index;                     // インデックス
        [System.Xml.Serialization.XmlElement("SETTING_DATA")]
        public byte[,] setting_data;            // 設定データ
        [System.Xml.Serialization.XmlElement("SET_TYPE")]
        public byte[] set_type;                 // 設定タイプ
        [System.Xml.Serialization.XmlElement("MOUSE_DATA")]
        public byte[,] mouse_data;// マウスデータ
        [System.Xml.Serialization.XmlElement("KEYBOARD_DATA")]
        public byte[,] keyboard_data;// マウスデータ
        [System.Xml.Serialization.XmlElement("JOYPAD_DATA")]
        public byte[,] joypad_data;// マウスデータ

        public SetData()
        {
            int fi, fj;
            try
            {
                index = new int[Constants.SETTING_NUM];
                setting_data = new byte[Constants.SETTING_NUM, Constants.DEVICE_DATA_LEN];
                set_type = new byte[Constants.SETTING_NUM];
                mouse_data = new byte[Constants.SETTING_NUM, Constants.MOUSE_DATA_LEN];
                keyboard_data = new byte[Constants.SETTING_NUM, Constants.KEYBOARD_DATA_LEN];
                joypad_data = new byte[Constants.SETTING_NUM, Constants.JOYPAD_DATA_LEN];

                for (fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    index[fi] = fi;
                    for (fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                    {
                        setting_data[fi, fj] = 0;
                    }
                    set_type[fi] = Constants.SET_TYPE_NONE;
                    for (fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                    {
                        mouse_data[fi, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                    {
                        keyboard_data[fi, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                    {
                        joypad_data[fi, fj] = 0;
                    }
                }
            }
            catch
            {
            }
        }

        public int Init()
        {
            int ret = 0;
            int fi, fj;
            try
            {
                for (fi = 0; fi < Constants.SETTING_NUM; fi++)
                {
                    index[fi] = fi;
                    for (fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                    {
                        setting_data[fi, fj] = 0;
                    }
                    set_type[fi] = Constants.SET_TYPE_NONE;
                    for (fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                    {
                        mouse_data[fi, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                    {
                        keyboard_data[fi, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                    {
                        joypad_data[fi, fj] = 0;
                    }
                }
            }
            catch
            {
            }
            return ret;
        }
        public int Dispose()
        {
            int ret = 0;
            try
            {
            }
            catch
            {
            }
            return ret;
        }

        // デバイスデータをセット
        public int device_data_set(int p_idx, byte[,] p_device_data)
        {
            int ret = 0;
            try
            {
                if (setting_data.GetLength(0) == p_device_data.GetLength(0) && setting_data.GetLength(1) == p_device_data.GetLength(1))
                {
                    for (int fi = 0; fi < setting_data.GetLength(0); fi++)
                    {
                        for (int fj = 0; fj < setting_data.GetLength(1); fj++)
                        {
                            if ((fi * setting_data.GetLength(1) + fj) < p_device_data.Length)
                            {
                                setting_data[fi, fj] = p_device_data[fi, fj];
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return ret;
        }

        // デバイスデータを取得
        public int device_data_get(int p_idx, ref byte[,] p_device_data)
        {
            int ret = 0;
            try
            {
                if (setting_data.GetLength(0) == p_device_data.GetLength(0) && setting_data.GetLength(1) == p_device_data.GetLength(1))
                {
                    for (int fi = 0; fi < setting_data.GetLength(0); fi++)
                    {
                        for (int fj = 0; fj < setting_data.GetLength(1); fj++)
                        {
                            if ((fi * setting_data.GetLength(1) + fj) < p_device_data.Length)
                            {
                                p_device_data[fi, fj] = setting_data[fi, fj];
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return ret;
        }

        public int data_clear(int p_idx)
        {
            int ret = 0;
            int fj;
            try
            {
                if (0 <= p_idx && p_idx < Constants.SETTING_NUM)
                {
                    for (fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                    {
                        setting_data[p_idx, fj] = 0;
                    }
                    set_type[p_idx] = Constants.SET_TYPE_NONE;
                    for (fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                    {
                        mouse_data[p_idx, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                    {
                        keyboard_data[p_idx, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                    {
                        joypad_data[p_idx, fj] = 0;
                    }
                }
                else
                {
                    ret = 1;
                }
            }
            catch
            {
            }
            return ret;
        }

        public int device_data_clear(int p_idx)
        {
            int ret = 0;
            int fj;
            try
            {
                if (0 <= p_idx && p_idx < Constants.SETTING_NUM)
                {
                    for (fj = 0; fj < Constants.DEVICE_DATA_LEN; fj++)
                    {
                        setting_data[p_idx, fj] = 0;
                    }
                }
                else
                {
                    ret = 1;
                }
            }
            catch
            {
            }
            return ret;
        }

        public int disp_data_clear(int p_idx)
        {
            int ret = 0;
            int fj;
            try
            {
                if (0 <= p_idx && p_idx < Constants.SETTING_NUM)
                {
                    set_type[p_idx] = Constants.SET_TYPE_NONE;
                    for (fj = 0; fj < Constants.MOUSE_DATA_LEN; fj++)
                    {
                        mouse_data[p_idx, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.KEYBOARD_DATA_LEN; fj++)
                    {
                        keyboard_data[p_idx, fj] = 0;
                    }
                    for (fj = 0; fj < Constants.JOYPAD_DATA_LEN; fj++)
                    {
                        joypad_data[p_idx, fj] = 0;
                    }
                }
                else
                {
                    ret = 1;
                }
            }
            catch
            {
            }
            return ret;
        }

        public int ir_data_all_clear()
        {
            int ret = 0;
            try
            {
                Init();
            }
            catch
            {
            }
            return ret;
        }
    }
} //namespace HID_PnP_Demo