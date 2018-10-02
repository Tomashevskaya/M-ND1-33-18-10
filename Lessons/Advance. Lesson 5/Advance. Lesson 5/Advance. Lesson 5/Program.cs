using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance.Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            AdultException();
        }

        public static void AdultException()
        {
            const int adult = 18;

            var birthDate = new DateTime(2004, 2, 29);
            var adultDate = new DateTime(birthDate.Year + adult, birthDate.Month, birthDate.Day);

            Console.WriteLine(adultDate);
        }

        public static void ThrowExceptionExample()
        {
            throw new System.Net.Mail.SmtpException();
        }



        //public SmtpException();

        //public SmtpException(SmtpStatusCode statusCode);

        //public SmtpException(string message);

        //public SmtpException(SmtpStatusCode statusCode, string message);

        //public SmtpException(string message, Exception innerException);

        public enum SmtpStatusCode
        {
            GeneralFailure = -1,
            SystemStatus = 211,
            HelpMessage = 214,
            ServiceReady = 220,
            ServiceClosingTransmissionChannel = 221,
            Ok = 250,
            UserNotLocalWillForward = 251,
            CannotVerifyUserWillAttemptDelivery = 252,
            StartMailInput = 354,
            ServiceNotAvailable = 421,
            MailboxBusy = 450,
            LocalErrorInProcessing = 451,
            InsufficientStorage = 452,
            ClientNotPermitted = 454,
            CommandUnrecognized = 500,
            SyntaxError = 501,
            CommandNotImplemented = 502,
            BadCommandSequence = 503,
            CommandParameterNotImplemented = 504,
            MustIssueStartTlsFirst = 530,
            MailboxUnavailable = 550,
            UserNotLocalTryAlternatePath = 551,
            ExceededStorageAllocation = 552,
            MailboxNameNotAllowed = 553,
            TransactionFailed = 554
        }
    }
}
