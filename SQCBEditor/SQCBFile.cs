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
        private const string SQCB_VERSION = "1.00";

        private Header _header;
        public List<FileEntry> Entries
        {
            get => _header.Entries;
            set => _header.Entries = value;
        }

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

        public static SQCBFile LoadFile(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return LoadFile(fs);
            }
        }

        public static SQCBFile LoadFile(Stream stream) => LoadFile(ref stream);

        public static SQCBFile LoadFile(ref Stream stream)
        {
            SQCBFile file = new SQCBFile
            {
                _header = LoadHeader(ref stream)
            };

            stream.Position = 0;

            for (int i = 0; i < file._header.Entries.Count; i++)
            {
                FileEntry entry = file._header.Entries[i];
                entry.Data = new byte[entry.Length];
                stream.Position = entry.Offset;
                stream.Read(entry.Data, 0, entry.Length);
                file._header.Entries[i] = entry;
            }

            string checksum = stream.ReadText16(4);

            if (checksum != SQCB_CHECKSUM)
                throw new DataLeakException();

            return file;
        }

        public static void SaveFile(string path, SQCBFile file)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                SaveFile(fs, file);
            }
        }

        public static void SaveFile(Stream stream, SQCBFile file) => SaveFile(ref stream, file);

        public static void SaveFile(ref Stream stream, SQCBFile file)
        {
            stream.Position = 0;
            stream.Write16(SQCB_IDENTIFIER, false);
            stream.Write16(SQCB_VERSION, false);
            stream.Write(file.Entries.Count);

            int dataOffset = 20; //Identifier, Version, entries.Count (Int)
            for (int i = 0; i < file.Entries.Count; i++)
            {
                dataOffset += file.Entries[i].Name.Length * 2 + 2 + 4 + 4; //2 bytes per char + 2 null terminator, offset (int), length (int)
            }

            stream.Position = 20;
            for (int i = 0; i < file.Entries.Count; i++)
            {
                stream.Write16(file.Entries[i].Name);
                stream.Write(dataOffset);
                stream.Write(file.Entries[i].Data.Length);

                dataOffset += file.Entries[i].Data.Length;
            }
            for (int i = 0; i < file.Entries.Count; i++)
            {
                stream.Write(file.Entries[i].Data, 0 , file.Entries[i].Data.Length);
            }
            stream.Write16(SQCB_CHECKSUM, false);
        }
    }
}
