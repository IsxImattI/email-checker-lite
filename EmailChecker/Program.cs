using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmailChecker;

string? inputPath = null;
string? outputPath = null;

var argsDict = args
    .Where(a => a.StartsWith("--"))
    .Select(a => a.Split('='))
    .ToDictionary(a => a[0], a => a.Length > 1 ? a[1] : null);

argsDict.TryGetValue("--input", out inputPath);
argsDict.TryGetValue("--output", out outputPath);


var disposableDomains = new HashSet<string>(
    File.ReadAllLines("disposable_domains.txt")
        .Select(d => d.Trim().ToLower())
        .Where(d => !string.IsNullOrEmpty(d))
);

Console.WriteLine("Email Checker");
string? path = inputPath;
if (string.IsNullOrWhiteSpace(path))
{
    Console.Write("Enter path to CSV file with emails: ");
    path = Console.ReadLine();
}


if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
{
    Console.WriteLine(" Invalid path or file does not exist.");
    return;
}

var emails = File.ReadAllLines(path)
    .Where(e => !string.IsNullOrWhiteSpace(e))
    .ToList();

Console.WriteLine($"\n Checking {emails.Count} emails...\n");

var results = new List<string> { "Email,ValidSyntax,DomainExists,HasMX,IsDisposable" };

foreach (var email in emails)
{
    bool valid = EmailValidator.IsValidSyntax(email);
    bool domain = valid && EmailValidator.DomainExists(email);
    bool mx = domain && EmailValidator.HasMXRecord(email);
    bool isDisposable = valid && EmailValidator.IsDisposable(email, disposableDomains);

    Console.WriteLine($" {email} => Syntax: {valid}, Domain: {domain}, MX: {mx}, Disposable: {isDisposable}");
    results.Add($"{email},{valid},{domain},{mx},{isDisposable}");
}

outputPath ??= Path.Combine(Path.GetDirectoryName(path)!, "results.csv");
File.WriteAllLines(outputPath, results);

Console.WriteLine($"\n Results saved to: {outputPath}");
