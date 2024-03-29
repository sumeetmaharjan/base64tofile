﻿

if (!File.Exists("encoded.txt"))
{
    File.Create("encoded.txt");
}

Console.WriteLine("Content Added to encoded.txt? (Y/N)");
var answer = Console.ReadLine();
if (answer.ToLower().Equals("y"))
{
    var fileContent = File.ReadAllText("encoded.txt");

    var extension = GetFileExtension(fileContent);
    if (!string.IsNullOrEmpty(extension))
    {
        Console.WriteLine($"Possible File Extension {extension}");
        Console.WriteLine("Want to add your own? (Y/N)");
        answer = Console.ReadLine();
        if (answer.ToLower().Equals("y"))
        {
            Console.WriteLine("Extension");
            extension = Console.ReadLine();
        }
    }
    else
    {
        Console.WriteLine($"Added Extension");
        extension = Console.ReadLine();
    }

    

    File.WriteAllBytes($"decoded.{extension}", Convert.FromBase64String(fileContent));
}

// Apparently this is how you decode the extension from the base64string
string GetFileExtension(string base64String)
{
    var data = base64String[..5];

    switch (data.ToUpper())
    {
        case "IVBOR":
            return "png";
        case "/9J/4":
            return "jpg";
        case "AAAAF":
            return "mp4";
        case "JVBER":
            return "pdf";
        case "AAABA":
            return "ico";
        case "UMFYI":
            return "rar";
        case "E1XYD":
            return "rtf";
        case "U1PKC":
            return "txt";
        case "MQOWM":
        case "77U/M":
            return "srt";
        default:
            return string.Empty;
    }
}
