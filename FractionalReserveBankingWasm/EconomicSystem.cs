namespace FractionalReserveBankingWasm
{
    public class Bank
    {
        public decimal Reserves { get; set; }
        public decimal Loans { get; set; }
        public decimal Deposits { get; set; }

        public decimal ExcessReserves { get; set; }

        public void Deposit(decimal amount)
        {
            Deposits = Deposits + amount;

            Reserves = Reserves + amount;

            ExcessReserves = ExcessReserves + amount * 0.9m;
        }

        public void Loan(decimal amount)
        {
            if (amount > ExcessReserves)
                throw new Exception("amount > ExcessReserves");

            Reserves = Reserves - amount;

            ExcessReserves = ExcessReserves - amount;

            Loans = Loans + amount;
        }

        public void Info()
        {
            Console.WriteLine("Reserves: {0} Excess Reserves: {3} Loans: {1} Deposits: {2}", Reserves, Loans, Deposits, ExcessReserves);
        }
    }

    public class Economy
    {
        public decimal Cash { get; set; }
        public Bank Bank { get; set; } = new Bank();

        public void Deposit(decimal amount)
        {
            Console.WriteLine("Deposit({0})", amount);

            if (amount > Cash) throw new Exception("amount > Cash");

            Cash = Cash - amount;

            Bank.Deposit(amount);
        }

        public void Loan(decimal amount)
        {
            Console.WriteLine("Loan({0})", amount);

            Bank.Loan(amount);

            Cash = Cash + amount;
        }

        public decimal MoneySupply() => Bank.Deposits + Cash;

        public void Info()
        {
            Console.WriteLine("Cash: {4,7:N2} Reserves: {0,7:N2} Excess Reserves: {3,7:N2} Loans: {1,7:N2} Deposits: {2,7:N2}    Money supply: {5,7:N2}",
                Bank.Reserves, Bank.Loans, Bank.Deposits, Bank.ExcessReserves, Cash, MoneySupply());
        }
    }
}
