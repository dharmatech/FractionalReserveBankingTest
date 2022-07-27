namespace Bank
{
    public class Bank
    {
        // Assets
        public decimal Reserves { get; set; }
        public decimal Loans { get; set; }
        public decimal Securities { get; set; }

        // Liabilities and Bank capital
        public decimal Deposits { get; set; }

        public decimal Debt { get; set; }

        public decimal Capital { get; set; }

        public decimal ExcessReserves() => (0.9m * (Deposits + Debt + Capital) - (Loans + Securities));

        //public decimal LeverageRatio() => (Reserves + Loans + Securities) / Capital;

        public decimal? LeverageRatio() => 
            Capital == 0m ? null : (Reserves + Loans + Securities) / Capital;

        public void Deposit(decimal amount)
        {
            //Console.WriteLine("> Deposit({0})\n", amount);
            Deposits = Deposits + amount;
            Reserves = Reserves + amount;
        }

        public void Withdraw(decimal amount)
        {
            Deposits = Deposits - amount;
            Reserves = Reserves - amount;
        }


        public void AddCapital(decimal amount)
        {
            Capital = Capital + amount;
            Reserves = Reserves + amount;
        }

        public void RemoveCapital(decimal amount)
        {
            Capital = Capital - amount;
            Reserves = Reserves - amount;
        }

        public void AddDebt(decimal amount)
        {
            Debt = Debt + amount;
            Reserves = Reserves + amount;
        }

        public void PayDebt(decimal amount)
        {
            Debt = Debt - amount;
            Reserves = Reserves - amount;
        }


        public void Loan(decimal amount)
        {
            if (amount > ExcessReserves())
                throw new Exception("amount > ExcessReserves");

            Reserves = Reserves - amount;

            Loans = Loans + amount;
        }

        public void PayLoan(decimal amount)
        {
            Reserves = Reserves + amount;

            Loans = Loans - amount;
        }

        public void BuySecurity(decimal amount)
        {
            if (amount > ExcessReserves())
                throw new Exception("amount > ExcessReserves");

            Reserves = Reserves - amount;

            Securities = Securities + amount;
        }

        public void SellSecurity(decimal amount)
        {
            Reserves = Reserves + amount;

            Securities = Securities - amount;
        }

        public void SecuritiesProfit(decimal amount)
        {
            Securities = Securities + amount;
            Capital = Capital + amount;
        }

        public void LoanDefault(decimal amount)
        {
            Loans = Loans - amount;
            Capital = Capital - amount;
        }

        public void Info()
        {
            Console.WriteLine("Reserves: {0} Excess Reserves: {3} Loans: {1} Securities: {4} Deposits: {2} Debt: {5} Capital: {6}",
                Reserves, Loans, Deposits, ExcessReserves());
        }

        public void TAccount()
        {
            Console.WriteLine("ASSETS                  LIABILITIES AND OWNERS' EQUITY");
            Console.WriteLine("Reserves:   {0,7:N2}     Deposits: {1,7:N2}", Reserves, Deposits);
            Console.WriteLine("Loans:      {0,7:N2}     Debt:     {1,7:N2}", Loans, Debt);
            Console.WriteLine("Securities: {0,7:N2}     Capital:  {1,7:N2}", Securities, Capital);

            Console.WriteLine();
            Console.WriteLine("Totals:     {0,7:N2}               {1,7:N2}", Reserves + Loans + Securities, Deposits + Debt + Capital);

            Console.WriteLine();
            Console.WriteLine("Excess reserves: {0:N2}", ExcessReserves());
            Console.WriteLine();
        }
    }

    public class Economy
    {
        public decimal Cash { get; set; }
        public Bank Bank { get; set; } = new Bank();

        public void AddCash(decimal amount)
        {
            Cash = Cash + amount;
        }

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
                Bank.Reserves, Bank.Loans, Bank.Deposits, Bank.ExcessReserves(), Cash, MoneySupply());
        }
    }
}