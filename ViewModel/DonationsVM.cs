namespace IW7PP.ViewModel
{
    public class DonationsVM
    {
        public double Amount { get; set; } // Monto de la donación
        public string Email { get; set; } // Email del donante
        public string Name { get; set; } // Nombre del donante
        public string Surname { get; set; } // Apellido del donante
        public string Phone { get; set; } // Número de teléfono del donante
        public int ClientId { get; set; } // ID del cliente protésico al que se destina la donación
    }
}
