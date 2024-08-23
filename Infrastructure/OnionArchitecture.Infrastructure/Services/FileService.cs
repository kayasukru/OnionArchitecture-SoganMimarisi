﻿using OnionArchitecture.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task SaveTextAsync(string text, string path)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(path))
                    throw new ArgumentNullException(nameof(path));

                await File.WriteAllTextAsync(path, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dosyaya kayıt sırasında bir hata oluştu: {ex.Message}");
            }
        }
    }
}
