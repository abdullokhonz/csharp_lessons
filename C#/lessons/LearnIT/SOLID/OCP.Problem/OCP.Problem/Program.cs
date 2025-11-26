// See https://aka.ms/new-console-template for more information
using OCP.Problem.Classes;

Console.WriteLine("Hello, World!");

// Sending an Email
var emailSender = new MessageSender(new EmailSender());
var result1 = emailSender.Send("Email", "This is an email message.");
Console.WriteLine(result1);

// Sending a Telegram message
var telegramSender = new MessageSender(new TelegramSender());
var result3 = telegramSender.Send("Telegram", "This is a Telegram message.");
Console.WriteLine(result3);

// Sending an SMS
var smsSender = new MessageSender(new SMSSender());
var result2 = smsSender.Send("SMS", "This is an SMS message.");
Console.WriteLine(result2);
