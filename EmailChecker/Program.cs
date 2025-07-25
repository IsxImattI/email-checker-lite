using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmailChecker;

var disposableDomains = new HashSet<string>(
    File.ReadAllLines("disposable_domains.txt")
        .Select(d => d.Trim().ToLower())
        .Where(d => !string.IsNullOrEmpty(d))
);

Console.WriteLine("Email Checker");
Console.Write("Enter path to CSV file with emails: ");
string? path = Console.ReadLine();

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

string outputPath = Path.Combine(Path.GetDirectoryName(path)!, "results.csv");
File.WriteAllLines(outputPath, results);

Console.WriteLine($"\n Results saved to: {outputPath}");
