using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmailChecker;


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

var results = new List<string> { "Email,ValidSyntax,DomainExists,HasMX" };

foreach (var email in emails)
{
    bool valid = EmailValidator.IsValidSyntax(email);
    bool domain = valid && EmailValidator.DomainExists(email);
    bool mx = domain && EmailValidator.HasMXRecord(email);

    Console.WriteLine($" {email} => Syntax: {valid}, Domain: {domain}, MX: {mx}");
    results.Add($"{email},{valid},{domain},{mx}");
}

string outputPath = Path.Combine(Path.GetDirectoryName(path)!, "results.csv");
File.WriteAllLines(outputPath, results);

Console.WriteLine($"\n Results saved to: {outputPath}");
