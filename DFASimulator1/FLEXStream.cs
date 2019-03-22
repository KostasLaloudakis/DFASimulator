using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFASimulator1
{
    class FLEXStream
    {
        private StreamReader stream;

        private char[] c = new char[1];
        //ftiaxno pinaka me ena stoixeio

        public FLEXStream(StreamReader stream)
        {
            this.stream = stream;
        }


        public char NextChar(int position)
        {
            stream.BaseStream.Position = position;
            stream.Read(c, 0, c.Length);
            //Console.WriteLine(c);
            stream.DiscardBufferedData();
            return c[0];

        }
    }
}
