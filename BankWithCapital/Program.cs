namespace BankWithCapital
{
    //public class Bank
    //{
    //    // Assets
    //    public decimal Reserves { get; set; }
    //    public decimal Loans { get; set; }
    //    public decimal Securities { get; set; }

    //    // Liabilities and Bank capital
    //    public decimal Deposits { get; set; }

    //    public decimal Debt { get; set; }

    //    public decimal Capital { get; set; }

    //    public decimal ExcessReserves { get; set; }

    //    public decimal ExcessReservesValue()
    //    {
    //        return (0.9m * (Deposits + Debt + Capital) - (Loans + Securities));
    //    }

    //    public void Deposit(decimal amount)
    //    {
    //        Deposits = Deposits + amount;
    //        Reserves = Reserves + amount;
    //        ExcessReserves = ExcessReserves + amount * 0.9m;
    //    }

    //    public void Withdraw(decimal amount)
    //    {
    //        Deposits = Deposits - amount;
    //        Reserves = Reserves - amount;
    //        ExcessReserves = ExcessReserves - amount * 0.9m;
    //    }


    //    public void AddCapital(decimal amount)
    //    {
    //        Capital = Capital + amount;
    //        Reserves = Reserves + amount;
    //        ExcessReserves = ExcessReserves + amount * 0.9m;
    //    }

    //    public void RemoveCapital(decimal amount)
    //    {
    //        Capital = Capital - amount;
    //        Reserves = Reserves - amount;
    //        ExcessReserves = ExcessReserves - amount * 0.9m;
    //    }


    //    public void AddDebt(decimal amount)
    //    {
    //        Debt = Debt + amount;
    //        Reserves = Reserves + amount;
    //        ExcessReserves = ExcessReserves + amount * 0.9m;
    //    }

    //    public void PayDebt(decimal amount)
    //    {
    //        Debt = Debt - amount;
    //        Reserves = Reserves - amount;
    //        ExcessReserves = ExcessReserves - amount * 0.9m;
    //    }


    //    public void Loan(decimal amount)
    //    {
    //        if (amount > ExcessReserves)
    //            throw new Exception("amount > ExcessReserves");

    //        Reserves = Reserves - amount;

    //        ExcessReserves = ExcessReserves - amount;

    //        Loans = Loans + amount;
    //    }

    //    public void PayLoan(decimal amount)
    //    {
    //        Reserves = Reserves + amount;

    //        Loans = Loans - amount;

    //        ExcessReserves = ExcessReserves + amount;
    //    }

    //    public void BuySecurity(decimal amount)
    //    {
    //        if (amount > ExcessReserves)
    //            throw new Exception("amount > ExcessReserves");

    //        Reserves = Reserves - amount;

    //        ExcessReserves = ExcessReserves - amount;

    //        Securities = Securities + amount;
    //    }

    //    public void SellSecurity(decimal amount)
    //    {
    //        Reserves = Reserves + amount;

    //        ExcessReserves = ExcessReserves + amount;

    //        Securities = Securities - amount;
    //    }

    //    public void SecuritiesProfit(decimal amount)
    //    {
    //        Securities = Securities + amount;
    //        Capital = Capital + amount;

    //        ExcessReserves = ExcessReserves + amount * 0.9m;
    //        ExcessReserves = ExcessReserves - amount;
    //    }

    //    public void LoanDefault(decimal amount)
    //    {
    //        Loans = Loans - amount;
    //        Capital = Capital - amount;

    //        // if capital goes up   by N, excess reserves go up   by 0.9*N
    //        // if capital goes down by N, excess reserves go down by 

    //        ExcessReserves = ExcessReserves + amount;        // loans   change
    //        ExcessReserves = ExcessReserves - amount * 0.9m; // capital change
    //    }

    //    public void Info()
    //    {
    //        Console.WriteLine("Reserves: {0} Excess Reserves: {3} Loans: {1} Securities: {4} Deposits: {2} Debt: {5} Capital: {6}",
    //            Reserves, Loans, Deposits, ExcessReserves);
    //    }

    //    public void TAccount()
    //    {
    //        Console.WriteLine("ASSETS                  LIABILITIES AND OWNERS' EQUITY");
    //        Console.WriteLine("Reserves:   {0,7}     Deposits: {1,7}", Reserves, Deposits);
    //        Console.WriteLine("Loans:      {0,7}     Debt:     {1,7}", Loans, Debt);
    //        Console.WriteLine("Securities: {0,7}     Capital:  {1,7}", Securities, Capital);

    //        Console.WriteLine();
    //        Console.WriteLine("Totals:     {0,7}               {1,7}", Reserves + Loans + Securities, Deposits + Debt + Capital);

    //        Console.WriteLine();
    //        Console.WriteLine("Excess reserves: {0}   {1}", ExcessReserves, ExcessReservesValue());
    //    }
    //}


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
                
        public decimal ExcessReserves()
        {
            return (0.9m * (Deposits + Debt + Capital) - (Loans + Securities));
        }

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

        public void Deposit(decimal amount)
        {
            //Console.WriteLine("Deposit({0})", amount);

            if (amount > Cash) throw new Exception("amount > Cash");

            Cash = Cash - amount;

            Bank.Deposit(amount);
        }

        public void Loan(decimal amount)
        {
            //Console.WriteLine("Loan({0})", amount);

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

    internal class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();

            //                        bank.TAccount();
            //bank.Deposit(800);      bank.TAccount();
            //bank.AddDebt(150);      bank.TAccount();
            //bank.AddCapital(50);    bank.TAccount();
            //bank.Loan(700);         bank.TAccount();
            //bank.BuySecurity(100);  bank.TAccount();

            //bank.SecuritiesProfit(50);
            //bank.TAccount();

            //bank.LoanDefault(50);
            //bank.TAccount();

            //bank.LoanDefault(10);
            //bank.TAccount();

            //bank.PayLoan(700);

            //bank.TAccount();

            //bank.Withdraw(100);

            //bank.TAccount();

            var cash = 100m;

            bank.TAccount();

            bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves();
            bank.Loan(cash);
            bank.TAccount();

            bank.Deposit(cash); bank.TAccount();

            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();
            cash = bank.ExcessReserves(); bank.Loan(cash); bank.TAccount(); bank.Deposit(cash); bank.TAccount();

            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);
            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);

            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);


            //bank.TAccount();

            //bank.Deposit(cash); cash = bank.ExcessReserves(); bank.Loan(cash);

            //bank.TAccount();

            //Console.WriteLine(bank.ExcessReserves());


            //bank.PayDebt(50);
            //bank.TAccount();

            //bank.PayDebt(50);
            //bank.RemoveCapital(50);
            //bank.TAccount();

            //bank.Deposit(100);

            //bank.TAccount();

            //bank.Withdraw(100);

            //bank.TAccount();



            //bank.Deposit(100);

            //bank.Info();

            //bank.Loan(90);

            //bank.Info();

            //var economy = new Economy() { Cash = 100 };

            //economic_system.Info();

            //economic_system.Deposit(100); economic_system.Info();

            //economic_system.Loan(90); economic_system.Info();

            //economic_system.Deposit(90); economic_system.Info();

            //economic_system
        }
    }
}