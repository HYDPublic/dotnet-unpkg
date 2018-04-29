using System;

namespace dotnet_unpkg
{
    public static class Help
    {
        public static void Empty()
        {
            Console.WriteLine("Usage: dotnet unpkg [command] [options] [arguments]");
            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("  add            Add a package");
            Console.WriteLine("  restore        Restore packages");
        }

        public static void Add()
        {
            Console.WriteLine("Usage: dotnet unpkg add [OPTIONS] <PACKAGE> [...<PACKAGE>]");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("  <PACKAGE>    The name of a package on unpkg.com.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("  --wwwroot    Name of your static files directory");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("    dotnet unpkg add --wwwroot=public jquery bootstrap popper.js");
            Console.WriteLine("    dotnet unpkg add bootswatch/yeti");
            Console.WriteLine("    dotnet unpkg add @aspnet/signalr/browser");
            Console.WriteLine();
        }

        public static void Restore()
        {
            Console.WriteLine("Usage: dotnet unpkg restore");
            Console.WriteLine();
        }

        public static void Upgrade()
        {
            Console.WriteLine("Usage: dotnet unpkg upgrade [<PACKAGE> [...<PACKAGE>]]");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("  <PACKAGE>    (Optional) The name of an installed package.");
            Console.WriteLine("               If omitted, all packages will be upgraded.");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine("    dotnet unpkg upgrade");
            Console.WriteLine("    dotnet unpkg upgrade jquery bootstrap popper.js");
            Console.WriteLine("    dotnet unpkg upgrade @aspnet/signalr/browser");
            Console.WriteLine();
        }
    }
}