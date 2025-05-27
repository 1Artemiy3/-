using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        new SongManager().Run();
    }
}