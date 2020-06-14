using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BudgeIt.Infrastructure
{
    public class FileEngine : IFileEngine
    {
        // Which ever runtime is being used, this gets
        // its implementation.
        IFileEngine fileEngine = DependencyService.Get<IFileEngine>();


        public Task<IEnumerable<string>> GetFilesAsync()
        {
            return fileEngine.GetFilesAsync();
        }

        public Task<string> ReadTextAsync(string storedText)
        {
            return fileEngine.ReadTextAsync(storedText);
        }

        public Task WriteTextAsync(string storedText, string text)
        {
            return fileEngine.WriteTextAsync(storedText, text);
        }
    }
}
