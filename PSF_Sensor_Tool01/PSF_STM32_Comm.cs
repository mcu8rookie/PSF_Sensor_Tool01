
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LibUsbDotNet;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using LibUsbDotNet.LudnMonoLibUsb;
// using LibUsbDotNet.Main.ErrorCode;


using System.Threading;

namespace PSF_STM32_Comm
{
    class Comm
    {
        private bool rtn = false;

        private int ErrorCount = 0;

        private const int USB_DEVICE_VID = 1515;
        private const int USB_DEVICE_PID = 1000;

        private UsbDeviceFinder MyUsbDeviceFinder;
        private UsbDevice MyUsbDevice;
        private UsbEndpointReader MyUsbEpReader;
        private UsbEndpointWriter MyUsbEpWriter;

        public bool Close()
        {
            if(MyUsbDevice != null)
            {
                if(MyUsbDevice.IsOpen)
                {
                    if(MyUsbEpReader != null)
                    {
                        MyUsbEpReader.DataReceivedEnabled = false;
                        // MyEpReader.DataReceived -= mEp_DataReceived;
                        MyUsbEpReader.Dispose();
                        MyUsbEpReader = null;

                    }
                    if(MyUsbEpWriter != null)
                    {
                        MyUsbEpWriter.Abort();
                        MyUsbEpWriter.Dispose();
                        MyUsbEpWriter = null;
                    }
                    // If this is a "whole" usb device (libusb-win32, linux libusb)
                    // it will have an IUsbDevice interface. If not (WinUSB) the 
                    // variable will be null indicating this is an interface of a 
                    // device.
                    IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    if(!ReferenceEquals(wholeUsbDevice,null))
                    {
                        // Release interface #0
                        wholeUsbDevice.ReleaseInterface(0);
                    }

                    MyUsbDevice.Close();
                    MyUsbDevice = null;

                }
                UsbDevice.Exit();
            }

            return true;
        }

        public bool Open()
        {

            rtn = false;

            Close();

            // MyUsbFinder = new UsbDeviceFinder(USB_DEVICE_VID,USB_DEVICE_PID);
            MyUsbDeviceFinder = new UsbDeviceFinder(1515, 1000);
            MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbDeviceFinder);


            if(MyUsbDevice != null)
            {
                rtn = true;
                ErrorCount = 0;

                // If this is a "whole" usb device (libusb-win32, linux libusb)
                // it will have an IUsbDevice interface. If not (WinUSB) the 
                // variable will be null indicating this is an interface of a 
                // device.
                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if(!ReferenceEquals(wholeUsbDevice,null))
                {
                    // This is a "whole" USB device. Before it can be used, 
                    // the desired configuration and interface must be selected.

                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);
                    // Claim interface #0
                    wholeUsbDevice.ClaimInterface(0);
                }
            }

            if(rtn == true)
            {
                MyUsbEpReader = MyUsbDevice.OpenEndpointReader((ReadEndpointID)(1|0x80));
                MyUsbEpWriter = MyUsbDevice.OpenEndpointWriter((WriteEndpointID)1);
                // MyUsbReader.DataReceived += mEp_DataReceived;
                // MyUsbReader.Flush();
            }
            else
            {
                if(!ReferenceEquals(MyUsbDevice,null))
                {
                    if(MyUsbDevice.IsOpen)
                    {
                        MyUsbDevice.Close();
                        MyUsbDevice = null;
                    }
                }
            }

            return rtn;
        }

        public byte[] i2c_Read(ushort i2c_no,byte address,byte cmd,int numBytes)
        {
            byte[] writeBuffer = new byte[64];
            byte[] readBuffer = new byte[64];
            byte[] i2cData = new byte[64];

            int uiTransmitted;
            ErrorCode eReturn = ErrorCode.None;

            writeBuffer[0] = 0; // type: i2c = 0; uart =1;
            writeBuffer[1] = 1; // isRead: read = 1; write = 0;
            writeBuffer[2] = (byte)i2c_no;
            writeBuffer[3] = address;
            writeBuffer[4] = cmd;
            writeBuffer[5] = 1;
            writeBuffer[6] = (byte)numBytes;
            if(MyUsbEpWriter != null)
            {
                eReturn = MyUsbEpWriter.Write(writeBuffer, 0, 7, 1000, out uiTransmitted);
            }
            if(MyUsbEpReader != null)
            {
                eReturn = MyUsbEpReader.Read(readBuffer, 1000, out uiTransmitted);
            }
            if (eReturn != ErrorCode.None)
            {
                if(ErrorCount++ > 200)
                {
                    // i2cErrro();
                }
            }
            if(readBuffer[0] == 0)
            {
                Buffer.BlockCopy(readBuffer, 1, i2cData, 0, numBytes);
            }

            return i2cData;
        }

        public byte[] i2c_Read(ushort i2c_no,byte address,byte cmd,byte cmd_len,int numBytes)
        {
            byte[] writeBuffer = new byte[64];
            byte[] readBuffer = new byte[64];
            byte[] i2cData = new byte[64];

            int uiTransmitted;
            ErrorCode eReturn = ErrorCode.None;

            writeBuffer[0] = 0; // type: i2c=0;uart=1;
            writeBuffer[1] = 1; // isRead; read=1;write=0;
            writeBuffer[2] = (byte)i2c_no;
            writeBuffer[3] = address;
            writeBuffer[4] = cmd;
            writeBuffer[5] = cmd_len;
            writeBuffer[6] = (byte)numBytes;
            if(MyUsbEpWriter != null)
            {
                eReturn = MyUsbEpWriter.Write(writeBuffer, 0, 7, 1000, out uiTransmitted);

            }
            Thread.Sleep(1);
            if(MyUsbEpReader != null)
            {
                eReturn = MyUsbEpReader.Read(readBuffer, 1000, out uiTransmitted);
            }
            for (int i = 0;i < readBuffer.Length;i++)
            {
                Console.WriteLine("MyUsbEpReader.Read()" + readBuffer[i]);
            }
            if(eReturn != ErrorCode.None)
            {
                Console.WriteLine("eReturn != ErrorCode.None");
                if(ErrorCount++>200)
                {
                    // i2cError();
                }
            }

            if(readBuffer[0] == 0)
            {
                Buffer.BlockCopy(readBuffer, 1, i2cData, 0, numBytes);
            }
            return i2cData;
        }

        public bool i2c_Write(ushort i2c_no,byte address,byte cmd, byte[] buffer,int numBytes)
        {
            int uiTransmitted;
            ErrorCode eReturn = ErrorCode.None;
            byte[] writeBuffer = new byte[64];
            byte[] readBuffer = new byte[64];

            writeBuffer[0] = 0; // type: i2c=0; uart=1;
            writeBuffer[1] = 0; // isRead: read=1; write=0;
            writeBuffer[2] = (byte)i2c_no;
            writeBuffer[3] = address;
            writeBuffer[4] = cmd;
            writeBuffer[5] = 1;
            writeBuffer[6] = (byte)numBytes;
            if(numBytes > 0)
            {
                Buffer.BlockCopy(buffer, 0, writeBuffer, 7, numBytes);

            }
            if(MyUsbEpWriter != null)
            {
                eReturn = MyUsbEpWriter.Write(writeBuffer, 0, 7 + numBytes, 1000, out uiTransmitted);
            }
            if(eReturn != ErrorCode.None)
            {
                return false;
            }
            if(MyUsbEpReader != null)
            {
                eReturn = MyUsbEpReader.Read(readBuffer, 1000, out uiTransmitted);
            }
            if(eReturn != ErrorCode.None)
            {
                return false;
            }
            if(readBuffer[0] != 0)
            {
                return false;
            }

            return true;
        }

        public bool i2c_Write(ushort i2c_no,byte address,byte cmd,byte cmd_len,byte[] buffer,int numBytes)
        {
            int uiTransmitted;
            ErrorCode eReturn = ErrorCode.None;
            byte[] writeBuffer = new byte[64];
            byte[] readBuffer = new byte[64];

            writeBuffer[0] = 0; // type:i2c=0;uart=1;
            writeBuffer[1] = 0; // is Read: read=1;write=0;
            writeBuffer[2] = (byte)i2c_no;
            writeBuffer[3] = address;
            writeBuffer[4] = cmd;
            writeBuffer[5] = cmd_len;
            writeBuffer[6] = (byte)numBytes;
            Buffer.BlockCopy(buffer, 0, writeBuffer, 7, numBytes);

            if(MyUsbEpWriter != null)
            {
                eReturn = MyUsbEpWriter.Write(writeBuffer, 0, 7 + numBytes, 1000, out uiTransmitted); 
            }
            if(eReturn != ErrorCode.None)
            {
                return false;
            }
            if(MyUsbEpReader != null)
            {
                eReturn = MyUsbEpReader.Read(readBuffer, 1000, out uiTransmitted);
            }
            if(eReturn != ErrorCode.None)
            {
                return false;
            }
            if(readBuffer[0] != 0)
            {
                return false;
            }

            return true;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("\r\nPSF_STM32_Comm; Main()");
        }
    }
    

}