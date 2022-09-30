
namespace PDSA_System.Server.Models
{
    public class Bruker
    {
        public int BrukerId { get; set; }

        public string Navn { get; set; }

        public string Email { get; set; }

        private string PassordHash { get; set; } //Trenger rettninglinsjer her.

        public string Rolle { get; set; }

        // public List<Lag> Lag{ get; set; }

        /*
         Er List den beste datastrukturen? Kanskje HashMap <K,V>.
         */


        public Bruker(int BrukerId, string Navn,string Email, string PassordHash, string Rolle)
        {
            this.BrukerId = BrukerId;
            this.Navn = Navn;
            this.Email = Email;
            this.PassordHash = PassordHash;
            this.Rolle = Rolle;
        }



    }
}