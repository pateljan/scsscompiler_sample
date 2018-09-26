//using LibSassHost;
//using LibSassHost.Helpers;
using System;
using System.IO;
using SharpScss;
namespace LibsassSample
{
    class Program
    {
        private static string _filesDirectoryPath;
        static void Main(string[] args)
        {
            _filesDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            //_filesDirectoryPath = Path.GetFullPath(Path.Combine(_filesDirectoryPath, "Files"));
            Console.WriteLine($"Include File Directory : {_filesDirectoryPath}");
            CompileIncludeFile();
            //CompileContent();
            //CompileFile();
        }

        protected static void CompileIncludeFile()
        {
            WriteHeader("Compilation of SCSS code");

            string inputContent = @"@import ""heera""; " + Environment.NewLine +
                                        @"@import ""heera_variables"";";

            try
            {
                var options = new ScssOptions
                {
                    IncludePaths = {
                        Path.GetFullPath(Path.Combine(_filesDirectoryPath, "common")),
                        Path.GetFullPath(Path.Combine(_filesDirectoryPath, "Files"))
                    }

                };

                ScssResult result = Scss.ConvertToCss(inputContent, options: options);
                Console.WriteLine("Compiled content:{1}{1}{0}{1}", result.Css, Environment.NewLine);
                Console.WriteLine("Source map:{1}{1}{0}{1}", result.SourceMap, Environment.NewLine);
                Console.WriteLine("Included file paths: {0}", string.Join(", ", result.IncludedFiles));
                Console.WriteLine();
            }
            catch (ScssException e)
            {
                Console.WriteLine("During compilation of SCSS code an error occurred.", e);
            }
        }

        //protected static void CompileIncludeFile()
        //{
        //    WriteHeader("Compilation of SCSS code");

        //    string inputContent = @"@import ""heera""; " + Environment.NewLine +
        //                                @"@import ""heera_variables"";";

        //    try
        //    {                
        //        var options = new CompilationOptions {
        //            IncludePaths = {
        //                FileManager.Instance.ToAbsolutePath(Path.Combine(_filesDirectoryPath, "common")),
        //                FileManager.Instance.ToAbsolutePath(Path.Combine(_filesDirectoryPath, "Files"))
        //            }

        //        };

        //        CompilationResult result = SassCompiler.Compile(inputContent, options: options);
        //        WriteOutput(result);
        //    }
        //    catch (SassСompilationException e)
        //    {
        //        WriteError("During compilation of SCSS code an error occurred.", e);
        //    }
        //}

        //protected static void CompileContent()
        //{
        //    WriteHeader("Compilation of SCSS code");

        //    const string inputContent = @"$font-stack: Helvetica, sans-serif;
        //                        $primary-color: #333;
        //                        body {
        //                          font: 100% $font-stack;
        //                          color: $primary-color;
        //                        }                                
        //                        .down-arrow:before {
        //                          content: ""▼"";
        //                        }";

        //    try
        //    {
        //        var options = new CompilationOptions { SourceMap = true };
        //        CompilationResult result = SassCompiler.Compile(inputContent, "input.scss", "output.css",
        //            options: options);
        //        WriteOutput(result);
        //    }
        //    catch (SassСompilationException e)
        //    {
        //        WriteError("During compilation of SCSS code an error occurred.", e);
        //    }
        //}

        //protected static void CompileFile()
        //{
        //    WriteHeader("Compilation of SCSS file");

        //    string inputFilePath = Path.Combine(_filesDirectoryPath, "style.scss");
        //    string outputFilePath = Path.Combine(_filesDirectoryPath, "style.css");

        //    try
        //    {
        //        var options = new CompilationOptions { SourceMap = true, SourceMapFileUrls = true };
        //        CompilationResult result = SassCompiler.CompileFile(inputFilePath, outputFilePath, options: options);
        //        WriteOutput(result);
        //    }
        //    catch (SassСompilationException e)
        //    {
        //        WriteError("During compilation of SCSS file an error occurred.", e);
        //    }
        //}

        private static void WriteHeader(string text)
        {
            string separator = new string('-', 80);

            Console.WriteLine(separator);
            Console.WriteLine(text);
            Console.WriteLine(separator);
            Console.WriteLine();
        }

        //private static void WriteOutput(CompilationResult result)
        //{
        //    Console.WriteLine("Version: {0}", SassCompiler.Version);
        //    Console.WriteLine("Language version: {0}", SassCompiler.LanguageVersion);
        //    Console.WriteLine("Compiled content:{1}{1}{0}{1}", result.CompiledContent, Environment.NewLine);
        //    Console.WriteLine("Source map:{1}{1}{0}{1}", result.SourceMap, Environment.NewLine);
        //    Console.WriteLine("Included file paths: {0}", string.Join(", ", result.IncludedFilePaths));
        //    Console.WriteLine();
        //}

        //private static void WriteError(string title, SassСompilationException exception)
        //{
        //    Console.WriteLine("{0} See details:", title);
        //    Console.WriteLine();
        //    Console.WriteLine(SassErrorHelpers.Format(exception));
        //    Console.WriteLine();
        //}
    }
}
