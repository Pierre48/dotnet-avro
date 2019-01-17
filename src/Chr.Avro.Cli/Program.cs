﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Chr.Avro.Cli
{
    public static class Program
    {
        private static Parser _parser = new Parser(settings =>
        {
            settings.HelpWriter = Console.Error;
        });

        public static int Main(string[] args)
        {
            return _parser
                .ParseArguments<CreateSchemaVerb, GenerateCodeVerb, GetSchemaVerb, TestSchemaVerb>(args)
                .MapResult(
                    (CreateSchemaVerb create) => create.Execute(),
                    (GenerateCodeVerb generate) => generate.Execute(),
                    (GetSchemaVerb get) => get.Execute(),
                    (TestSchemaVerb verify) => verify.Execute(),
                    errors => 1
                );
        }
    }

    [Serializable]
    public sealed class ProgramException : Exception
    {
        public int Code { get; private set; }

        public ProgramException(int code = 1, string message = null, Exception inner = null) : base(message, inner)
        {
            Code = code;
        }
    }
}