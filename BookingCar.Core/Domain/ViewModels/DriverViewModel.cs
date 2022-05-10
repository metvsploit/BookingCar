using System;

namespace BookingCar.Core.Domain.ViewModels
{
    public struct DriverViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public bool IsBusy { get; set; }

        public override string ToString()
        {
            var str = string.Join(" ", LastName?.Trim(), FirstName?.Trim(), Patronymic?.Trim()).Trim();
            return str;
        }

        public override bool Equals(object obj)
        {
            return obj is DriverViewModel name
            && FirstName == name.FirstName
            && LastName == name.LastName
            && Patronymic == name.Patronymic;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            if (FirstName != null)
                hash = hash * 23 + FirstName.GetHashCode();
            if (LastName != null)
                hash = hash * 23 + LastName.GetHashCode();
            if (Patronymic != null)
                hash = hash * 23 + Patronymic.GetHashCode();
            return hash;
        }
    }
}
