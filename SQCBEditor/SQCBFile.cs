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

        public struct FileEntry
        {
            public string Name;
            public int Offset;
            public int Length;
        }

        public struct Header
        {
            public string Version;
            public List<FileEntry> Entries; 
        }

        internal static Header LoadHeader(string filename)
        {
            Header header = default(Header);

            //TODO: Use more native/unmanaged stuff :) look much better that way :D

            using (FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                string h = stream.ReadText16(4); // 8 bit
                if(h != SQCB_IDENTIFIER)
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
                    header.Entries.Add(new FileEntry { Name = name, Offset = offset, Length = length });
                }
            }
            return header;
        }
    }
}
