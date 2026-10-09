List<Account> accounts = new List<Account>();
List<Customer> customers = new List<Customer>();

while (true)
{
    Console.WriteLine("================ Banking Application ================");
    Console.WriteLine();
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Check Balance");
    Console.WriteLine("5. Exit");

    Console.Write("Enter your choice: ");
    Console.WriteLine();

    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            CreateAccount(accounts, customers);
    
            break;

        case "2":
            Deposit(accounts, customers);
            break;
        case "3":
            Withdraw(accounts, customers);
            break;
        case "4":
            CheckBalance(accounts, customers);
            break;
        case "5":
            Console.WriteLine("Thank you for using the Banking Application.");
            return;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    Console.WriteLine();
    Console.WriteLine("Press ENTER to continue...");
    Console.ReadLine();

}
//Methods 
static void CreateAccount(List<Account> accounts, List<Customer> customers)
{
            Console.WriteLine("You chose to create an account.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter your fullname: ");

            // Set variable names
            string? name = Console.ReadLine();
            int age;
            decimal deposit;

            // Get info to open the account
            Console.WriteLine("To proceed, we need to collect more personal data");
            Console.WriteLine("Enter your age: ");
            
            // Loop while age isn't written in numbers
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Invalid input. Please enter a valid age.");
            }  

            // Create new objects in the classes Account and Customer
            Account account = new Account();
            account.Owner = name!;

            Customer customer = new Customer();
            customer.Name = name!;
            customer.Age = age;

            // Add the new account and customer to their respective lists
            accounts.Add(account);
            customers.Add(customer);

            Console.WriteLine();
            Console.WriteLine($"Account info registered successfully for {account.Owner})."); 
            Console.WriteLine($"Now please Mr(s) {customer.Name}, insert the amount you want to deposit to open your account: ");

            while (!decimal.TryParse(Console.ReadLine(), out deposit))
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
            }

            account.Balance = deposit;

            Console.WriteLine();
            Console.WriteLine("Thank you for your trust! Your account has been created successfully.");           
            Console.WriteLine($"Your account has been created successfully with a balance of {account.Balance:C}.");
}

static void Deposit (List<Account> accounts, List<Customer> customers)
{
               // Set variable for deposit
            decimal depositAmount = 0;
            string? accHolder;

            Console.WriteLine("You chose to deposit money.");
            Console.WriteLine("To deposit money, please enter your account holder fullname: ");
            accHolder = Console.ReadLine();

            // Check if holder exists in the list of accounts
            bool accountFound = false;

            foreach (var acc in accounts)
            {
                if (acc.Owner.Equals(accHolder, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Current balance for {acc.Owner}: {acc.Balance:C}");
                    accountFound = true;    
                    break;
                }
            }

            if (!accountFound)
            {
                Console.WriteLine("Account holder not found. Please check the name and try again.");
                return;
            }
            else
            {
                Console.WriteLine($"Account holder {accHolder} found.");
                Console.WriteLine("To proceed, please enter your age to confirm your identity: ");

                int accAge;
                while (!int.TryParse(Console.ReadLine(), out accAge))
                {
                    Console.WriteLine("Invalid input. Please enter a valid age.");
                }

                // Verify age matches the account holder
                Customer? customer1 = customers.FirstOrDefault(c => c.Name.Equals(accHolder, StringComparison.OrdinalIgnoreCase) && c.Age == accAge);
                if (customer1 == null)
                {
                    Console.WriteLine("Age does not match the account holder's records. Access denied.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Identity confirmed for {customer1.Name}.");
                }

                
            }
            
            Console.WriteLine("Enter how much do you wish to deposit: ");
            Console.WriteLine();

            while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Invalid input. Please enter a valid amount.");
            }


            foreach (var acc in accounts)
            {
                if (acc.Owner.Equals(accHolder, StringComparison.OrdinalIgnoreCase))
                {
                    acc.Balance += depositAmount;
                    Console.WriteLine($"Deposit successful. New balance for {acc.Owner}: {acc.Balance:C}");
                    return;
                }
            }
}

static void Withdraw (List<Account> accounts, List<Customer> customers)
{
            Console.WriteLine("You chose to withdraw money.");

            Console.WriteLine("To withdraw money, please enter your account holder fullname: ");
            string? accHolderWithdraw = Console.ReadLine();

            // Check if holder exists in the list of accounts
            bool accountFoundWithdraw = false;

            foreach (var acc in accounts)
            {
                if (acc.Owner.Equals(accHolderWithdraw, StringComparison.OrdinalIgnoreCase))
                {
                    accountFoundWithdraw = true;    
                }
            }

            if (!accountFoundWithdraw)
            {
                Console.WriteLine("Account holder not found. Please check the name and try again.");
                return;
            }
            else
            {
                Console.WriteLine($"Account holder {accHolderWithdraw} found.");
                Console.WriteLine("To proceed, please enter your age to confirm your identity: ");

                int accAgeWithdraw;
                while (!int.TryParse(Console.ReadLine(), out accAgeWithdraw))
                {
                    Console.WriteLine("Invalid input. Please enter a valid age.");
                }

                // Verify age matches the account holder
                Customer? customer2 = customers.FirstOrDefault(c => c.Name.Equals(accHolderWithdraw, StringComparison.OrdinalIgnoreCase) && c.Age == accAgeWithdraw);
                if (customer2 == null)
                {
                    Console.WriteLine("Age does not match the account holder's records. Access denied.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Identity confirmed for {customer2.Name}.");
                }

                decimal withdrawAmount = 0;
                Console.WriteLine("Enter how much do you wish to withdraw: ");
                while (!decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount.");
                }

                foreach (var acc in accounts)
                {
                    if (acc.Owner.Equals(accHolderWithdraw, StringComparison.OrdinalIgnoreCase))
                    {
                        if (withdrawAmount > acc.Balance)
                        {
                            Console.WriteLine("Insufficient funds. Withdrawal failed.");
                        }
                        else
                        {
                            acc.Balance -= withdrawAmount;
                            Console.WriteLine($"Withdrawal successful. New balance for {acc.Owner}: {acc.Balance:C}");
                        }
                        break;
                    }
                }



                
            }
}

static void CheckBalance(List<Account> accounts, List<Customer> customers)
{
                Console.WriteLine("You chose to check your balance.");

            Console.WriteLine("To check your balance, please enter your account holder fullname: ");
            string? accHolderBalance = Console.ReadLine();

            // Check if holder exists in the list of accounts
            bool accountFoundBalance = false;

            foreach (var acc in accounts)
            {
                if (acc.Owner.Equals(accHolderBalance, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Current balance for {acc.Owner}: {acc.Balance:C}");
                    accountFoundBalance = true;    
                    return;
                }
            }

            if (!accountFoundBalance)
            {
                Console.WriteLine("Account holder not found. Please check the name and try again.");
                return;
            }
            else
            {
                Console.WriteLine($"Account holder {accHolderBalance} found.");
                Console.WriteLine("To proceed, please enter your age to confirm your identity: ");

                int accAgeBalance;
                while (!int.TryParse(Console.ReadLine(), out accAgeBalance))
                {
                    Console.WriteLine("Invalid input. Please enter a valid age.");
                }

                // Verify age matches the account holder
                Customer? customer3 = customers.FirstOrDefault(c => c.Name.Equals(accHolderBalance, StringComparison.OrdinalIgnoreCase) && c.Age == accAgeBalance);
                if (customer3 == null)
                {
                    Console.WriteLine("Age does not match the account holder's records. Access denied.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Identity confirmed for {customer3.Name}.");
                    Console.WriteLine($"Your current balance is: {accounts.First(acc => acc.Owner.Equals(accHolderBalance, StringComparison.OrdinalIgnoreCase)).Balance:C}");
                    
                }

                
            }



}


// Classes
            public class Account
            {
                public string Owner { get; set; } = null!;
                public decimal Balance {get; set; } = 0;
            }

            public class Customer
            {
                public string Name { get; set; } = null!;
                public int Age { get; set; } = 0;
            }

