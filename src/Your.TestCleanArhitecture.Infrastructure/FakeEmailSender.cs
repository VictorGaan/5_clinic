using Your.TestCleanArhitecture.Core.Interfaces;

namespace Your.TestCleanArhitecture.Infrastructure;

public class FakeEmailSender : IEmailSender
{
  public Task SendEmailAsync(string to, string from, string subject, string body)
  {
    return Task.CompletedTask;
  }
}
