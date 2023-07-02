using Antheap_1_task_net_react.Enums;
using System.ComponentModel;

namespace Antheap_1_task_net_react.Data.Entities
{
    public class CompanyEntity : BaseEntity
    {
        [Description("Firma (nazwa) lub imię i nazwisko")]
        public string Name { get; set; }

        [Description("NIP")]
        public string? Nip { get; set; }
        
        [Description("Status podatnika VAT")]
        public string? StatusVat { get; set; }

        [Description("Numer identyfikacyjny REGON")]
        public string? Regon { get; set; }

        [Description("PESEL")]
        public string? Pesel { get; set; }

        [Description("Adres siedziby działalności gospodarczej (Adres siedziby OSOBY FIZYCZNEJ prowadzącej działalność gospodarczą)")]
        public string? ResidenceAddress { get; set; }

        [Description("Adres rejestracyjny (Adres zamieszkania OSOBY FIZYCZNEJ lub adres siedziby ORGANIZACJI)")]
        public string? WorkingAddress { get; set; }

        [Description("Imiona i nazwiska osób wchodzących w skład organu uprawnionego do reprezentowania podmiotu oraz ich numery NIP i/lub PESEL")]
        public virtual IList<RepresentativeEntity>? Representatives { get; set; }

        [Description("Data rejestracji jako podatnika VAT format: date")]
        public DateTime? RegistrationLegalDate { get; set; }
    }
}
