using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQCBEditor
{
    public sealed class SQCBFile
    {
        private const string SQCB_IDENTIFIER = "SQCB";
        private const string SQCB_CHECKSUM = "RDBP";

        public struct FileEntry
        {
            public string Name;
            public int Offset;
            public int Length;
            public byte[] Data;
        }

        public struct Header
        {
            public string Version;
            public List<FileEntry> Entries; 
        }

        public static Header LoadHeader(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return LoadHeader(fs);
            }
        }

        public static Header LoadHeader(Stream stream) => LoadHeader(ref stream);

        public static Header LoadHeader(ref Stream stream)
        {
            Header header = default(Header);

            //TODO: Use more native/unmanaged stuff :) looks much better that way :D

            string h = stream.ReadText16(4); // 8 bit
            if (h != SQCB_IDENTIFIER)
            {
                throw new DataLeakException();
            }
            header.Version = stream.ReadText16(4); // 8 bit
            int fileCount = stream.ReadInt();
            header.Entries = new List<FileEntry>(fileCount);
            for (int i = 0; i < fileCount; i++)
            {
                string name = stream.ReadText16();
                int offset = stream.ReadInt();
                int length = stream.ReadInt();
                header.Entries.Add(new FileEntry { Name = name, Offset = offset, Length = length, Data = null });
            }

            return header;
        }

        public static Header LoadFile(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return LoadFile(fs);
            }
        }

        public static Header LoadFile(Stream stream) => LoadFile(ref stream);

        public static Header LoadFile(ref Stream stream)
        {
            Header header = LoadHeader(ref stream);

            stream.Position = 0;

            for (int i = 0; i < header.Entries.Count; i++)
            {
                FileEntry file = header.Entries[i];
                file.Data = new byte[file.Length + 1];
                stream.Position = file.Offset;
                stream.Read(file.Data, 0, file.Length);
                header.Entries[i] = file;
            }

            string checksum = stream.ReadText16(4);

            if (checksum != SQCB_CHECKSUM)
                throw new DataLeakException();

            return header;
        }
    }
}
