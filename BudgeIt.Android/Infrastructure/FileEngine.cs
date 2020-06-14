﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BudgeIt.Infrastructure;
using Xamarin.Forms;

[assembly: Dependency(typeof(BudgeIt.Droid.Infrastructure.FileEngine))]

namespace BudgeIt.Droid.Infrastructure
{
    public class FileEngine : IFileEngine
    {
        public Task<IEnumerable<string>> GetFilesAsync()
        {
            IEnumerable<string> storedTexts =
                from filePath in Directory.EnumerateFiles(DocsPath())
                select Path.GetFileName(filePath);
            return Task<IEnumerable<string>>.FromResult(storedTexts);
        }

        public async Task<string> ReadTextAsync(string storedText)
        {
            string filePath = FilePath(storedText);
            using (StreamReader reader = File.OpenText(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task WriteTextAsync(string storedText, string text)
        {
            string filePath = FilePath(storedText);
            using (StreamWriter writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(text);
            }
        }

        private string FilePath(string storedText)
        {
            return Path.Combine(DocsPath(), storedText);
        }

        private string DocsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
