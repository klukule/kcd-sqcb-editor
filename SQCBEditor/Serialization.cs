using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQCBEditor
{
    public static class Serialization
    {

        public static void WriteLine(this Stream fs)
        {
            fs.WriteByte(10);
        }

        public static void WriteUTF8(this Stream fs, string data, byte offset = 0)
        {
            if (string.IsNullOrEmpty(data))
            {
                fs.Write(0);
                return;
            }

            byte[] text = Encoding.UTF8.GetBytes(data);

            fs.Write(text.Length);

            if (offset > 0)
                for (int i = 0; i < text.Length; i++)
                {
                    text[i] += offset;
                }

            fs.Write(text, 0, text.Length);
        }

        public static void Write(this Stream fs, bool value)
        {
            fs.WriteByte(value ? (byte)1 : (byte)0);
        }

        public static void Write(this Stream fs, char value)
        {
            fs.WriteByte((byte)value);
        }

        public static void Write(this Stream fs, short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            fs.Write(bytes, 0, 2);
        }

        public static void Write(this Stream fs, ushort value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            fs.Write(bytes, 0, 2);
        }

        public static void Write(this Stream fs, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            fs.Write(bytes, 0, 4);
        }

        public static void Write(this Stream fs, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            fs.Write(bytes, 0, 4);
        }

        public static void Write(this Stream fs, long value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            fs.Write(bytes, 0, 8);
        }

        public static void Write(this Stream fs, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            fs.Write(bytes, 0, 4);
        }

        public static void Write(this Stream fs, float[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                byte[] bytes = BitConverter.GetBytes(value[i]);
                fs.Write(bytes, 0, 4);
            }
        }

        public static void Write(this Stream fs, Guid value)
        {
            byte[] bytes = value.ToByteArray();
            fs.Write(bytes, 0, 16);
        }

        public static string ReadStringUTF8(this Stream fs, byte offset = 0)
        {
            int length = fs.ReadInt();

            if (length <= 0)
                return string.Empty;

            byte[] text = new byte[length];
            fs.Read(text, 0, text.Length);

            if (offset > 0)
                for (int i = 0; i < length; i++)
                {
                    text[i] -= offset;
                }

            return Encoding.UTF8.GetString(text);
        }

        public static void Write(this Stream fs, double val)
        {
            byte[] bytes = BitConverter.GetBytes(val);
            fs.Write(bytes, 0, 8);
        }

        public static bool ReadBool(this Stream fs)
        {
            return fs.ReadByte() == 1;
        }

        public static short ReadShort(this Stream fs)
        {
            byte[] array = new byte[2];
            fs.Read(array, 0, 2);
            return BitConverter.ToInt16(array, 0);
        }

        public static ushort ReadUShort(this Stream fs)
        {
            byte[] array = new byte[2];
            fs.Read(array, 0, 2);
            return BitConverter.ToUInt16(array, 0);
        }

        public static int ReadInt(this Stream fs)
        {
            byte[] array = new byte[4];
            fs.Read(array, 0, 4);
            return BitConverter.ToInt32(array, 0);
        }

        public static uint ReadUInt(this Stream fs)
        {
            byte[] array = new byte[4];
            fs.Read(array, 0, 4);
            return BitConverter.ToUInt32(array, 0);
        }

        public static long ReadLong(this Stream fs)
        {
            byte[] array = new byte[8];
            fs.Read(array, 0, 8);
            return BitConverter.ToInt64(array, 0);
        }

        public static ulong ReadULong(this Stream fs)
        {
            byte[] array = new byte[8];
            fs.Read(array, 0, 8);
            return BitConverter.ToUInt64(array, 0);
        }

        public static float ReadFloat(this Stream fs)
        {
            byte[] array = new byte[4];
            fs.Read(array, 0, 4);
            return BitConverter.ToSingle(array, 0);
        }

        public static Guid ReadGuid(this Stream fs)
        {
            byte[] array = new byte[16];
            fs.Read(array, 0, 16);
            return new Guid(array);
        }

        public static double ReadDouble(this Stream fs)
        {
            byte[] array = new byte[8];
            fs.Read(array, 0, 8);
            return BitConverter.ToDouble(array, 0);
        }

        public static float[] ReadFloats(this Stream fs, uint size)
        {
            float[] array = new float[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = fs.ReadFloat();
            }
            return array;
        }

        public static string ReadText16(this Stream fs, int length)
        {
            string text = string.Empty;
            length *= 2; //2 bytes per char
            while (fs.CanRead && length > 0)
            {
                int a = fs.ReadByte();
                int b = fs.ReadByte();

                //When null terminator found
                if (a == 0 && b == 0)
                    break;

                text += (char)(a | b << 8);
                length -= 2;
            }
            return text;
        }
        public static string ReadText16(this Stream fs)
        {
            string text = string.Empty;
            while (fs.CanRead)
            {
                int a = fs.ReadByte();
                int b = fs.ReadByte();

                //When null terminator found
                if (a == 0 && b == 0)
                    break;

                text += (char)(a | b << 8);
            }
            return text;
        }

    }
}